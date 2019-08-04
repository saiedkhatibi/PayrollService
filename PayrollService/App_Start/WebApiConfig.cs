using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace PayrollService
{
    public static class WebApiConfig
    {
        public static void Register( HttpConfiguration config )
        {
            // Web API configuration and services
            var container = new UnityContainer( );
            container.RegisterType<PayrollService.Server.PayrollService, PayrollService.Server.PayrollService>( );
            container.RegisterType<PayrollService.Models.PayrollServiceContext, PayrollService.Models.PayrollServiceContext>( );
            config.DependencyResolver = new DIContainer.DIResolver( container );
            // Web API routes
            config.MapHttpAttributeRoutes( );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
