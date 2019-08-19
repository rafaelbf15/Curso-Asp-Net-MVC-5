using Curso.Mvc.Application.Interfaces;
using Curso.Mvc.Application.Services;
using Curso.Mvc.Domain.Intefaces;
using Curso.Mvc.Domain.Services;
using Curso.Mvc.Infra.Data.Context;
using Curso.Mvc.Infra.Data.Repository;
using Curso.Mvc.Infra.Data.UoW;
using SimpleInjector;

namespace Curso.Mvc.Infra.Crosscutting.IoC
{
    public class SimpleInjectionBootstrapper
    {

        //Lifestyle.Transient => Uma instancia para cada solicitação;
        //Lifestyle.Singleton => Uma instancia unica para a classe (para o servidor)
        //Lifestyle.Scoped => Uma instancia unica para o request


        public static void Register(Container container)
        {
            // APP
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            // Infra
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<CursoMvcEssencialContext>(Lifestyle.Scoped);
        }

    }
}
