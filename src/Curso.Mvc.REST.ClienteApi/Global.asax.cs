﻿using Curso.Mvc.Application.AutoMapper;
using System.Web.Http;

namespace Curso.Mvc.REST.ClienteApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
