﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Gallery.BLL;
using Gallery.DAL;
using Gallery.DAL.Model;
using Gallery.PL.Interfaces;
using Gallery.PL.Services;

namespace Gallery.PL.App_Start
{
    public static class DIConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var connectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString ?? throw new ArgumentException("sql");

            builder.Register(ctx => new UserContext(connectionString))
                .AsSelf();

            builder.RegisterType<UsersRepository>()
                .As<IRepository>();

            builder.RegisterType<UsersService>()
                .As<IUsersService>();

            builder.RegisterType<AuthenticationService>()
                .As<IAuthenticationService>();

            builder.RegisterType<ImageService>()
                .As<IimageService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}