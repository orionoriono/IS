using MusicEShop.Domain.DomainModels;

namespace MusicEShop.Service.Interface
{
    public interface IArtistService
    {
        List<Artist> GetAllArtists();
        Artist GetArtistById(Guid id);
        void CreateArtist(Artist artist);
        void UpdateArtist(Artist artist);
        void DeleteArtist(Guid id);
    }
}
