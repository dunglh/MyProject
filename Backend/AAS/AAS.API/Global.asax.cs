﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AAS.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                Newtonsoft.Json.JsonConvert.DefaultSettings = () => new Newtonsoft.Json.JsonSerializerSettings
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                };
                DungLH.Util.CommonLogging.LogSystem.Info("Application_Start.");

                AreaRegistration.RegisterAllAreas();

                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error("Application_End", ex);
            }
        }

        protected void Application_End()
        {
            DungLH.Util.CommonLogging.LogSystem.Info("Application_End.");
        }
    }
}
