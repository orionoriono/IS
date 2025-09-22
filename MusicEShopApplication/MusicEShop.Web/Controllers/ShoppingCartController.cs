using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MusicEShop.Service.Interface;
using Newtonsoft.Json;

namespace MusicEShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICartService _shoppingCartService;
            public ShoppingCartController(ICartService shoppingCartService)
        {
            this._shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dto=_shoppingCartService.getShoppingCartInfo(userId);
            return View(dto);
        }

        public IActionResult DeleteFromShoppingCart(Guid itemId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _shoppingCartService.DeleteItemFromShoppingCart(userId,itemId);
            return RedirectToAction("Index", "ShoppingCart");

        }

        public IActionResult Order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var options = _shoppingCartService.order(userId);
            if (options == null)
                throw new NullReferenceException();
            TempData["CheckoutOptions"] = JsonConvert.SerializeObject(options);

            return RedirectToAction("Checkout", "Payment");

        }

    }
}
