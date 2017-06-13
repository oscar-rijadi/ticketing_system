using Bootstrap.Extensions.StartupTasks;
using Microsoft.Practices.Unity;
using System;
using TicketingSystem.Core;
using TicketingSystem.Core.Db;
using TicketingSystem.Domain.Interfaces;
using TicketingSystem.Domain.Services.Impl;
using TicketingSystem.EF.DbContexts;
using TicketingSystem.EF.Factories;

namespace TicketingSystem.App_Start
{
    public class Startup : IStartupTask
    {
        public void Run()
        {
            var container = UnityConfig.GetConfiguredContainer();
            RegisterTypes(container);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISeatPositionManager, SeatPositionManager>(
                new InjectionFactory((unityContainer, type, arg3) => new SeatPositionManager(new RepositoryFactory<TicketingSystemContext>(new TicketingSystemContextFactory(new ConfigSettingsProvider())))));

            container.RegisterType<ITicketTypeManager, TicketTypeManager>(
                new InjectionFactory((unityContainer, type, arg3) => new TicketTypeManager(new RepositoryFactory<TicketingSystemContext>(new TicketingSystemContextFactory(new ConfigSettingsProvider())))));

            container.RegisterType<IUserManager, UserManager>(
                new InjectionFactory((unityContainer, type, arg3) => new UserManager(new RepositoryFactory<TicketingSystemContext>(new TicketingSystemContextFactory(new ConfigSettingsProvider())))));

            container.RegisterType<ITicketManager, TicketManager>(
                new InjectionFactory((unityContainer, type, arg3) => new TicketManager(new RepositoryFactory<TicketingSystemContext>(new TicketingSystemContextFactory(new ConfigSettingsProvider())))));
        }
    }
}