using MusicEShop.Domain.DomainModels;
using MusicEShop.Repository.Interface;
using MusicEShop.Service.Interface;

namespace MusicEShop.Service.Implementation
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void CreateAlbum(Album album)
        {
            _albumRepository.Insert(album);
        }

        public void DeleteAlbum(Guid id)
        {
            var album = _albumRepository.GetAlbumById(id);
            _albumRepository.DeleteAlbum(album);
        }

        public Album GetAlbumById(Guid id)
        {
            var album = _albumRepository.GetAlbumById(id);
            return album;
        }

        public List<Album> GetAlbumsByArtist(Guid artistId)
        {
            return _albumRepository.GetAlbumsByArtistId(artistId);
        }

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.GetAllAlbums().ToList();
        }

        public void UpdateAlbum(Album album)
        {
            _albumRepository.Update(album);
        }
    }
}
