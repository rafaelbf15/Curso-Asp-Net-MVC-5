using AutoMapper;

namespace Curso.Mvc.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomainToViewModel>();
                i.AddProfile<ViewModelToDomain>();
            });
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
