using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.ServiceCollection.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceCollection.Concrete
{
    public class EditionServiceModule : Module, IEditionServiceCollection
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<CommunicationManager>().As<ICommunicationService>().SingleInstance();
            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
        }
    }
}
