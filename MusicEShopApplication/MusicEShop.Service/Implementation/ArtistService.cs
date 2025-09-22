using MusicEShop.Domain.DomainModels;
using MusicEShop.Repository;
using MusicEShop.Repository.Interface;
using MusicEShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Service.Implementation
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void CreateArtist(Artist artist)
        {
            _artistRepository.Insert(artist);
        }

        public void DeleteArtist(Guid id)
        {
            var artist = _artistRepository.GetArtistById(id);
            _artistRepository.Delete(artist);
        }

        public List<Artist> GetAllArtists()
        {
            return _artistRepository.GetAllArtists().ToList();
        }

        public Artist GetArtistById(Guid id)
        {
            var artist = _artistRepository.GetArtistById(id);
            return artist;
        }

        public void UpdateArtist(Artist artist)
        {
            _artistRepository.Update(artist);
        }
    }
}
