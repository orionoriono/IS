using MusicEShop.Domain.DomainModels;
using MusicEShop.Domain.DTO;
using MusicEShop.Repository.Interface;
using MusicEShop.Service.Interface;
using MusicEShop.Domain;
using MusicEShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe.Checkout;

namespace MusicEShop.Service.Implementation
{
    public class CartService : ICartService

    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Domain.DomainModels.OrderItem> _orderItemRepository;
        private readonly IEmailService _emailService;
        private IPaymentService _paymentService;

        public CartService(IRepository<Cart> cartRepository, IRepository<CartItem> cartItemRepository, IUserRepository userRepository, IRepository<Order> orderRepository, IRepository<Domain.DomainModels.OrderItem> orderItemRepository, IEmailService emailService, IPaymentService paymentService)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _emailService = emailService;
            _paymentService = paymentService;   
        }

        public bool AddToShoppingConfirmed(CartItem model, string userId)
        {
            var loggedInUser = _userRepository.Get(userId);
            var userCart = loggedInUser.Cart ?? new Cart { CartItems = new List<CartItem>() };

            userCart.CartItems.Add(model);
            _cartRepository.Update(userCart);
            return true;
        }


        public bool DeleteItemFromShoppingCart(string userId, Guid itemId)
        {
            var user = _userRepository.Get(userId);
            if (user?.Cart?.Id == null)
                return false;

            var cart = _cartRepository.GetById(user.Cart.Id);
            if (cart?.CartItems == null)
                return false;

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.TrackId == itemId || ci.AlbumId == itemId);

            if (cartItem == null)
                return false;

            cart.CartItems.Remove(cartItem);
            _cartItemRepository.Delete(cartItem);
            _cartRepository.Update(cart);

            return true;
        }

        public CartDTO getShoppingCartInfo(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);
            var userCart = loggedInUser?.Cart;
            var allItems = userCart?.CartItems?.ToList() ?? new List<CartItem>();

            var totalPrice = allItems.Sum(x => ((x.Track?.Price ?? x.Album?.Price) ?? 0) * x.Quantity);

            return new CartDTO
            {
                CartItem = allItems.Select(x => new OrderItem
                {
                    OrderId = Guid.NewGuid(),
                    TrackId = x.Track?.Id,
                    AlbumId = x.Album?.Id,
                    Track = x.Track,
                    Album = x.Album,
                    Quantity = x.Quantity,
                    Price = (x.Track?.Price ?? x.Album?.Price) ?? 0
                }).ToList(),
                TotalPrice = totalPrice
            };
        }


        public SessionCreateOptions order(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return null;

            var loggedInUser = _userRepository.Get(userId);
            if (loggedInUser?.Cart?.CartItems == null || !loggedInUser.Cart.CartItems.Any())
                return null;

            var order = new Order { Id = Guid.NewGuid(), UserId = userId, User = loggedInUser };
            _orderRepository.Insert(order);

            var orderedItems = loggedInUser.Cart.CartItems.Select(x => new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Order = order,
                TrackId = x.Track?.Id,
                AlbumId = x.Album?.Id,
                Track = x.Track,
                Album = x.Album,
                Quantity = x.Quantity,
                Price = (x.Track?.Price ?? x.Album?.Price) ?? 0
            }).ToList();

            if (!orderedItems.Any())
                return null;

            var sessionOptions = _paymentService.CreateSessionOptions(orderedItems);

            var totalPrice = orderedItems.Sum(item => item.Price * item.Quantity);
            var message = new EmailMessage
            {
                Subject = "Successful Order",
                MailTo = loggedInUser.Email,
                Content = $"Your order is completed. Total Price: ${totalPrice}. Items:\n" +
                          string.Join("\n", orderedItems.Select((item, i) => $"{i + 1}. {(item.Track != null ? item.Track.Title : item.Album.Title)} - Qty: {item.Quantity}, Price: ${item.Price}"))
            };

            foreach (var orderItem in orderedItems)
                _orderItemRepository.Insert(orderItem);

            loggedInUser.Cart.CartItems.Clear();
            _cartRepository.Update(loggedInUser.Cart);
            _emailService.SendEmailAsync(message);

            return sessionOptions;
        }
    }
}
