using AutoMapper;

namespace DatingTime.Infrastructure.Bootstrap.ObjectMappers
{
    public class EntityToDtoMapper : Profile
    {
        public EntityToDtoMapper()
        {
            //CreateMap<Password, PasswordEncryptionDto>();

            //CreateMap<User, UserAuthenticationDTO>()
            //    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            //    .ForMember(dest => dest.PasswordDTO.PasswordString, opt => opt.MapFrom(src => src.Password.PasswordString))
            //    .ForMember(dest => dest.PasswordDTO.PasswordHash, opt => opt.MapFrom(src => src.Password.PasswordHash))
            //    .ForMember(dest => dest.PasswordDTO.PasswordSalt, opt => opt.MapFrom(src => src.Password.PasswordSalt));

            //CreateMap<Password, PasswordDTO>();
        
            
        }
    }
}