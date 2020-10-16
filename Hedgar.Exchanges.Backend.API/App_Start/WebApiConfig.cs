﻿using Hedgar.Exchanges.Backend.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Hedgar.Exchanges.Backend.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ExceptionHandlingFilter());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
