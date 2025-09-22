using MusicEShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Service.Interface
{
    public interface ITrackService
    {
        List<Track> GetAllTracks();
        Track GetTrackById(Guid id);
        void CreateTrack(Track track);
        void UpdateTrack(Track track);
        void DeleteTrack(Guid id);
    }
}
