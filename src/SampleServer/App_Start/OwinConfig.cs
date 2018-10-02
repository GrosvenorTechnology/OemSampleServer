using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Owin;
using SampleServer.Auth;
using SampleServer.Services;
using Unity;

[assembly: OwinStartup(typeof(SampleServer.OwinConfig))]
namespace SampleServer
{
    public class OwinConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<HmacAuthenticationMiddleware>(new HmacAuthenticationOptions(UnityConfig.Container));
        }
    }
}