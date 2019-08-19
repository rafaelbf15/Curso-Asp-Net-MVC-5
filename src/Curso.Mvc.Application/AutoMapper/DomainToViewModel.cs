using AutoMapper;
using Curso.Mvc.Application.ViewModels;
using Curso.Mvc.Domain.Models;

namespace Curso.Mvc.Application.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
        }
        
    }
}
