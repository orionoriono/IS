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
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Track> entities;

        public TrackRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
            entities = context.Set<Track>();
        }

        public List<Track> GetAllTracks()
        {
            return entities
                .Include(t => t.Album)
                    .ThenInclude(a => a.Artist)
                .ToList();
        }

        public Track? GetTrackById(Guid id)
        {
            return entities
                .Include(t => t.Album)
                    .ThenInclude(a => a.Artist)
                .SingleOrDefault(t => t.Id == id);
        }
    }
}
