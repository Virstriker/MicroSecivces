using AutoMapper;
using GamerManagment.DTO;
using GamerManagment.Models;

namespace GamerManagment.Helper
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<GamerViewModel,Gamer>();
            CreateMap<GamerViewModel,Gamer>().ReverseMap();
            CreateMap<GamerViewModelWithId, Gamer>();
            CreateMap<GamerViewModelWithId, Gamer>().ReverseMap();
            CreateMap<GameViewModel, Game>();
            CreateMap<GameViewModel, Game>().ReverseMap();
            CreateMap<GameWithGamerViewModel, Game>();
            CreateMap<GameWithGamerViewModel, Game>().ReverseMap();
        }
    }
}
