using MusicEShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Repository.Interface
{
    public interface IAlbumRepository : IRepository<Album>
    {
        List<Album> GetAlbumsByArtistId(System.Guid artistId);
        List<Album> GetAllAlbums();
        Album? GetAlbumById(Guid id);
        void DeleteAlbum(Album entity);
    }
}
