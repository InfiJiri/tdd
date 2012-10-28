using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Core;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.Windsor;
using DAL.Entities;
using DAL.Repositories;
using INFITDD.Controllers;
using INFITDD.Helpers.Windsor;
using INFITDD.Tests.Helpers;
using NUnit.Framework;

namespace INFITDD.Tests.IntegrationTests {

    [TestFixture]
    public class WindsorInstallerTests {

        private IWindsorContainer _containerWithControllers;
 
        [TestFixtureSetUp]
        public void WindsorInstallerTestsSetUp() {
            _containerWithControllers = new WindsorContainer().Install(new WindsorContainerInstaller());
        }

        [Test]
        public void AllControllersAreRegistered() {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Is<IController>());
            var registeredControllers = GetImplementationTypesFor(typeof(IController), _containerWithControllers);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        private static Type[] GetPublicClassesFromApplicationAssembly(Predicate<Type> where) {
            return typeof(AccountController).Assembly
                                            .GetExportedTypes()
                                            .Where(t => t.IsClass)
                                            .Where(t => t.IsAbstract == false)
                                            .Where(where.Invoke)
                                            .OrderBy(t => t.Name)
                                            .ToArray();
        }

        private static Type[] GetImplementationTypesFor(Type type, IWindsorContainer container) {
            return GetHandlersFor(type, container)
                .Select(h => h.ComponentModel.Implementation)
                .OrderBy(t => t.Name)
                .ToArray();
        }

        private static IEnumerable<IHandler> GetHandlersFor(Type type, IWindsorContainer container) {
            return container.Kernel.GetAssignableHandlers(type);
        }

        [Test]
        public void AllAndOnlyControllersHaveControllersSuffix() {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Name.EndsWith("Controller"));
            var registeredControllers = GetImplementationTypesFor(typeof(IController), _containerWithControllers);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        [Test]
        public void AllAndOnlyControllersLiveInControllersNamespace() {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Namespace != null && c.Namespace.Contains("Controllers"));
            var registeredControllers = GetImplementationTypesFor(typeof(IController), _containerWithControllers);
            Assert.AreEqual(allControllers, registeredControllers);
        }

        [Test]
        public void AllControllersAreTransient() {
            var nonTransientControllers = GetHandlersFor(typeof(IController), _containerWithControllers)
                                                .Where(controller => controller.ComponentModel.LifestyleType != LifestyleType.Transient)
                                                .ToArray();

            Assert.IsEmpty(nonTransientControllers);
        }

        [Test]
        public void AllControllersExposeThemselvesAsService() {
            var controllersWithWrongName = GetHandlersFor(typeof(IController), _containerWithControllers)
                                                .Where(controller => controller.ComponentModel.Services.Single() != controller.ComponentModel.Implementation)
                                                .ToArray();

            Assert.IsEmpty(controllersWithWrongName);
        }

    }

}
