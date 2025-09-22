using MusicEShop.Domain.DomainModels;
using MusicEShop.Repository.Interface;
using MusicEShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicEShop.Service.Implementation
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public void CreateTrack(Track track)
        {
            _trackRepository.Insert(track);
        }

        public void DeleteTrack(Guid id)
        {
            var track = _trackRepository.GetTrackById(id);
            _trackRepository.Delete(track);
        }

        public List<Track> GetAllTracks()
        {
            return _trackRepository.GetAllTracks().ToList();
        }

        public Track GetTrackById(Guid id)
        {
            var track = _trackRepository.GetTrackById(id);
            return track;
        }

        public void UpdateTrack(Track track)
        {
            _trackRepository.Update(track);
        }
    }
}
