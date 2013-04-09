using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using log4net;

namespace Framework
{
    public class LogInjectionModule : Module
    {
        protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
        {
            registration.Preparing += OnComponentPreparing;
        }

        static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            var t = e.Component.Activator.LimitType;
            e.Parameters = e.Parameters.Union(new[]
            {
                // Se utiliza para inyectar una configuración de Log4Net sobre la clase
                // OJO, solo funciona con Constructor Injection
                new ResolvedParameter((p, i) => p.ParameterType == typeof(ILog), (p, i) => LogManager.GetLogger(t))
            });
        }
}
}