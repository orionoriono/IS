using Microsoft.EntityFrameworkCore;
using MusicEShop.Domain.DomainModels;
using MusicEShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }

        public List<Order> GetAllOrders()
        {
            return entities
                .Include(o => o.User) 
                .Include(o => o.OrderItems!) 
                    .ThenInclude(oi => oi.Track) 
                .Include(o => o.OrderItems!) 
                    .ThenInclude(oi => oi.Album) 
                .ToList();
        }

        public Order? GetDetailsForOrder(BaseEntity id)
        {
            return entities
                .Include(o => o.User)
                .Include(o => o.OrderItems!)
                    .ThenInclude(oi => oi.Track)
                .Include(o => o.OrderItems!)
                    .ThenInclude(oi => oi.Album)
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }

        public List<Order> GetOrdersByUserId(string userId)
        {
            return entities
                .Include(o => o.User)
                .Include(o => o.OrderItems!)
                    .ThenInclude(oi => oi.Track)
                .Include(o => o.OrderItems!)
                    .ThenInclude(oi => oi.Album)
                .Where(o => o.UserId == userId)
                .ToList();
        }
    }
}
