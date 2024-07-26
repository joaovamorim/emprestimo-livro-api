using AutoMapper;
using EMPRESTIMO.LIVROS.DTOs;
using EMPRESTIMO.LIVROS.Models;

namespace EMPRESTIMO.LIVROS.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}