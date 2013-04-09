using Autofac;
using Common.Base;
using Frontend.Notifications;
using Model;
using Model.Repositories;
using Model.Repositories.interfaces;
using Services.Routes.impl;
using Services.Routes.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Framework
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            // Con la opción PropertiesAutowired inyecto a nivel Property
            // Esto lo hago para poder inyectar Log4net sin que afecte al diseño de la clase (evitar la necesidad de agregar un parametro mas en el constructor para el log).
            // El resto de las inyecciones deberían hacerse por constructor.
            builder.Register<ILog>((c, p) => LogManager.GetLogger("LogFile"));

            builder.RegisterType<BaseController>().PropertiesAutowired();
            builder.RegisterType<BaseService>().PropertiesAutowired();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().PropertiesAutowired();
            builder.RegisterType<NotificationHub>().PropertiesAutowired();
            
            builder.RegisterType<DefaultRoutesService>().As<IRoutesService>().PropertiesAutowired();
        }
    }
}