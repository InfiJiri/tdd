using System.Web.Mvc;
using Application.Services;
using Application.Services.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DAL.Context;
using DAL.Context.Interfaces;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace INFITDD.Helpers.Windsor {

    public class WindsorContainerInstaller : IWindsorInstaller {

        public void Install(IWindsorContainer container, IConfigurationStore store) {
            // Controllers registeren
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn<IController>()
                                      .LifestyleTransient());

            // Services
            container.Register(Component.For<IAccountService>()
                                        .ImplementedBy<AccountService>()
                                        .LifestyleTransient());

            // Repositories
            container.Register(Component.For<IAccountRepository>()
                                        .ImplementedBy<AccountRepository>()
                                        .LifestyleTransient());

            // UnitOfWork
            container.Register(Component.For<IUnitOfWorkFactory>()
                                        .ImplementedBy<TddUnitOfWorkFactory>()
                                        .LifestyleTransient());

        }

    }

}
