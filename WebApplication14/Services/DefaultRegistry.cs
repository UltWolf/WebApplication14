using AutoMapper;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Events;
using CQRSlite.Routing;
using StackExchange.Redis;
using System;
using System.Linq;
using WebApplication14.Models;

namespace WebApplication14.Services
{
    public class DefaultRegistry : Registry
    {


        public DefaultRegistry()
        {
            //Commands, Events, Handlers
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<BaseEvent>();
                    scan.Convention<FirstInterfaceConvention>();
                });

            //CQRSLite
            For<InProcessBus>().Singleton().Use<InProcessBus>();
            For<ICommandSender>().Use(y => y.GetInstance<InProcessBus>());
            For<IEventPublisher>().Use(y => y.GetInstance<InProcessBus>());
            For<IHandlerRegistrar>().Use(y => y.GetInstance<InProcessBus>());
            For<ISession>().HybridHttpOrThreadLocalScoped().Use<Session>();
            For<IEventStore>().Singleton().Use<InMemoryEventStore>();
            For<IRepository>().HybridHttpOrThreadLocalScoped().Use(y =>
                    new CacheRepository(new Repository(y.GetInstance<IEventStore>()), y.GetInstance<IEventStore>()));

            var profiles = from t in typeof(DefaultRegistry).Assembly.GetTypes()
                           where typeof(Profile).IsAssignableFrom(t)
                           select (Profile)Activator.CreateInstance(t);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            var mapper = config.CreateMapper();

            For<IMapper>().Use(mapper);

            //StackExchange.Redis
            ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("localhost");
            For<IConnectionMultiplexer>().Use(multiplexer);
        }
    }
}
