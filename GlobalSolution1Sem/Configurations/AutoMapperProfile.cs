using AutoMapper;
using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EnderecoEntity, EnderecoDto>();
            CreateMap<EnderecoDto, EnderecoEntity>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<PostEntity, PostDto>();
            CreateMap<PostDto, PostEntity>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore());

            CreateMap<UsuarioEntity, UsuarioDto>()
                .ForMember(dest => dest.EnderecoId, opt => opt.MapFrom(src => src.EnderecoId));
            CreateMap<UsuarioDto, UsuarioEntity>()
                .ForMember(dest => dest.Endereco, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore());
        }
    }
}
