using AutoMapper;
using DatingTime.Applications.Account.Models;
using DatingTime.Domain.Entities;
using System;

namespace DatingTime.Infrastructure.Bootstrap.ObjectMappers
{
    public class DtoToEntityMapper : Profile
    {
        public DtoToEntityMapper()
        {
            //CreateMap<UserAuthenticationDTO, User>()
            //    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            //    .ForMember(dest => dest.Password.PasswordString, opt => opt.MapFrom(src => src.PasswordDTO.PasswordString))
            //    .ForMember(dest => dest.Password.PasswordHash, opt => opt.MapFrom(src => src.PasswordDTO.PasswordHash))
            //    .ForMember(dest => dest.Password.PasswordSalt, opt => opt.MapFrom(src => src.PasswordDTO.PasswordSalt));

            //CreateMap<PasswordDTO, Password>();
        }
    }
}