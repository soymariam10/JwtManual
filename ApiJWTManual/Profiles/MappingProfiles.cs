using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiJWTManual.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace ApiJWTManual.Profiles
{
    // Perfil de mapeo que hereda de la clase Profile de AutoMapper
    public class MappingProfiles : Profile
    {
        // Constructor donde se definen los perfiles de mapeo
        public MappingProfiles()
        {
            // Crear un mapeo bidireccional entre la entidad Usuario y el DTO RegisterDTO
            CreateMap<Usuario, RegisterDTO>().ReverseMap();
            // Esto significa que puedes mapear de Usuario a RegisterDTO y viceversa automáticamente
        }
    }
}
