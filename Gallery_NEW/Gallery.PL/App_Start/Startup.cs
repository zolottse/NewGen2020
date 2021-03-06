﻿using System;
using System.Web.Http;
using Gallery.MsgQueue.Services;
using Gallery.PL;
using Gallery.PL.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Gallery.PL
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var parseMessageQueueDictionary = MessageQueueParser.ParseMessageQueuePathsDictionary();

            MessageQueueCreator.CreateMSMQMessageQueues(parseMessageQueueDictionary);
            MessageQueueCreator.CreateRabbitMQMessageQueues(parseMessageQueueDictionary);
            MessageQueueCreator.CreateAzureMessageQueues(parseMessageQueueDictionary);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login"),
                SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(60)
            });

            DIConfig.Configure(new HttpConfiguration());
        }
    }
}
