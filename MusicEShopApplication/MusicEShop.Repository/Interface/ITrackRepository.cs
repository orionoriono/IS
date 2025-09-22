using MusicEShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Repository.Interface
{
    public interface ITrackRepository : IRepository<Track>
    {
        List<Track> GetAllTracks();
        Track? GetTrackById(Guid id);
    }
}
