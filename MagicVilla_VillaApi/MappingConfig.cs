using AutoMapper;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.DTO;

namespace MagicVilla_VillaApi;

public class MappingConfig:Profile
{
    public MappingConfig()
    {
        CreateMap<Villa, VillaDTO>().ReverseMap();
        
        CreateMap<Villa,VillaCreateDTO>().ReverseMap();
        
        CreateMap<Villa,VillaUpdateDTO>().ReverseMap();

    }
    
}