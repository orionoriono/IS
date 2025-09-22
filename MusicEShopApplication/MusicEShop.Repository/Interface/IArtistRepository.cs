using MusicEShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Repository.Interface
{
    public interface IArtistRepository : IRepository<Artist>
    {
        List<Artist> GetAllArtists();
        Artist? GetArtistById(Guid id);
    }
}
