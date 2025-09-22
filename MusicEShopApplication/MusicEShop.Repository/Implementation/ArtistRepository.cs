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
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Artist> entities;
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
            entities = context.Set<Artist>();
        }

        public List<Artist> GetAllArtists()
        {
            return entities
                .Include(a => a.Albums) 
                .Include(a => a.ArtistTracks!) 
                .ThenInclude(at => at.Track) 
                .ToList();
        }

        public Artist? GetArtistById(Guid id)
        {
            return entities
                .Include(a => a.Albums)
                .Include(a => a.ArtistTracks!)
                .ThenInclude(at => at.Track)
                .SingleOrDefault(a => a.Id == id);
        }

        //public List<Artist> GetArtistsWithAlbums()
        //{
        //    return context.Artists.Include(a => a.Albums).ToList();
        //}
    }
}
