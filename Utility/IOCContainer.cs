using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace Utility
{
    public class IOCContainer
    {

        private static Autofac.IContainer _container;

        public static void InitAutofac()
        {


            var config = new ConfigurationBuilder();
            config.AddXmlFile("autofac.xml");
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            _container = builder.Build();

        }

        /// <summary>
        /// 从容器中获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T GetFromFac<T>()
        {
            return _container.Resolve<T>();
            //   return (T)DependencyResolver.Current.GetService(typeof(T));
        }

        public static T GetFromFac<T>(string name)
        {
            return _container.ResolveNamed<T>(name);
        }
    }
}
