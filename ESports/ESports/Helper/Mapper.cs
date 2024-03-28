using AutoMapper;
using ESports.Dto;
using ESports.Models;

namespace ESports.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Tournament,EventViewModel>();
            CreateMap<Tournament,EventViewModel>().ReverseMap();
            CreateMap<TournamentPlayer,PlayerViewModel>();
            CreateMap<TournamentPlayer,PlayerViewModel>().ReverseMap();
        }
    }
}
