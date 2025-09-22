using Microsoft.EntityFrameworkCore;
using MusicEShop.Domain.DomainModels;
using MusicEShop.Repository.Interface;

namespace MusicEShop.Repository.Implementation
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Album> entities;

        public AlbumRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
            entities = context.Set<Album>();
        }
        public List<Album> GetAllAlbums()
        {
            return entities
                .Include(a => a.Artist)
                .Include(a => a.Tracks!)
                .ToList();
        }

        public Album? GetAlbumById(Guid id)
        {
            return entities
                .Include(a => a.Artist)
                .Include(a => a.Tracks!)
                .SingleOrDefault(a => a.Id == id);
        }

        public List<Album> GetAlbumsByArtistId(Guid artistId)
        {
            return entities
                .Include(a => a.Artist)  
                .Include(a => a.Tracks!) 
                .Where(a => a.ArtistId == artistId)
                .ToList();
        }
        public  void DeleteAlbum(Album entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var album = context.Albums
                .Include(a => a.Tracks)
                .ThenInclude(t => t.CartItems)  
                .Include(a => a.CartItems) 
                .FirstOrDefault(a => a.Id == entity.Id);

            if (album == null)
            {
                throw new ArgumentException("Album not found.");
            }

            context.CartItems.RemoveRange(album.CartItems);

            foreach (var track in album.Tracks)
            {
                context.CartItems.RemoveRange(track.CartItems);
            }

            context.Tracks.RemoveRange(album.Tracks);

            entities.Remove(album);

            context.SaveChanges();
        }

        public override void Update(Album entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var existingEntity = context.Set<Album>().Local.FirstOrDefault(e => e.Id.Equals(entity.Id));
            if (existingEntity != null)
            {
                context.Entry(existingEntity).State = EntityState.Detached;
            }

            entities.Update(entity);
            context.SaveChanges();
        }

        public override void Delete(Album album)
        {
            if (album is null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            entities
            .Remove(album);
              
        }
    }
}
