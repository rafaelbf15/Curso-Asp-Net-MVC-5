using AutoMapper;
using Curso.Mvc.Application.ViewModels;
using Curso.Mvc.Domain.Models;


namespace Curso.Mvc.Application.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}
