using AutoMapper;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Villa, VillaDTO>();
        CreateMap<VillaDTO, Villa>();

        CreateMap<VillaDTO, CreateVillaDTO>();
        CreateMap<CreateVillaDTO, VillaDTO>();

        CreateMap<VillaDTO, UpdateVillaDTO>();
        CreateMap<UpdateVillaDTO, VillaDTO>();

        CreateMap<Villa, UpdateVillaDTO>();
        CreateMap<UpdateVillaDTO, Villa>();

        CreateMap<Villa, CreateVillaDTO>();
        CreateMap<CreateVillaDTO, Villa>();

        CreateMap<VillaNumber, VillaNumberDTO>();
        CreateMap<VillaNumberDTO, VillaNumber>();

        CreateMap<VillaNumber, CreateVillaNumberDTO>();
        CreateMap<CreateVillaNumberDTO, VillaNumber>();
    }
}