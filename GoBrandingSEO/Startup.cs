﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace GoBrandingSEO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}