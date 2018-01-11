using Connector.SDK.Filters.Exceptions;
using Connector.SDK.Injector.CustomScopes;
using Connector.SDK.Services.Jobs.Configuration;
using Connector.SDK.Services.Jobs.Logging;
using Connector.SDK.Services.Jobs.Management;
using Connector.SDK.Services.Jobs.Operations.Entries;
using Connector.SDK.Services.Jobs.TaskFinder;
using Connector.SDK.Services.Loggers.Exceptions;
using Connector.SDK.Services.Loggers.HttpClient;
using Connector.SDK.Services.Loggers.WSLoggers;
using Connector.SDK.Services.ServiceFactory;
using Connector.Tasks;
using Connector.Tasks.Chunker;
using Connector.Tasks.Configuration;
using Connector.Tasks.Entries;
using Connector.Tasks.Logging;
using Connector.Tasks.ServiceFactory;
using Connector.Tasks.Tracker;
using Microsoft.Owin.Security.DataProtection;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web.Hosting;
using System.Web.Http.ExceptionHandling;

namespace Connector.SDK.Injector
{
    public static class Mappings
    {
        public static string PublicClientId { get; } = "TestDI1";
        static string PrivateClientId { get; } = "TestDI2";

        public static void InitializeContainer(Container container, IDataProtectionProvider DataProtectionProvider)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            /* Logs */
            container.Register<ILogger, Logger>(Lifestyle.Scoped);
            container.Register<IExceptionLogger, CustomExceptionLogger>(Lifestyle.Scoped);
            container.Register<IHttpClientLogger, HttpClientLoggerParallelFactory<HttpClientLogger>>(Lifestyle.Scoped);
            container.Register<IWSLogger, WSLoggerParallelFactory<WSLogger>>(Lifestyle.Scoped);

            /* SOAP */
            container.Register<IServiceFactory, ServiceFactory>(Lifestyle.Scoped);
            container.Register<IClientMessageInspector, CustomMessageInspector>();
            container.RegisterCollection<IEndpointBehavior>(new List<Assembly> { GetSDKAssembly() });

            /* Jobs */
            IEnumerable<Assembly> tasksAssemblies = GetERPAssemblies();
            container.Register<ITaskLogger, TaskLogger>();
            container.RegisterCollection<ITask>(tasksAssemblies);
            container.RegisterCollection<ITaskAsync>(tasksAssemblies);
            container.RegisterSingleton<ITaskFinder, TaskFinder>();
            container.RegisterSingleton<ITracker, Tracker>();
            container.Register<ITaskManager, TaskManager>(Lifestyle.Scoped);
            container.Register<IEntryService, EntryServiceParallelFactory<EntryService>>(Lifestyle.Scoped);

            /* Task Scopes */
            container.Register<IOperationScope, OperationScope>(new OuterScopedLifestyle());
            //container.Register<IOperationScope, OperationScope>(Lifestyle.Scoped);

            /* Chunker */
            container.Register<IChunker, Chunker>(Lifestyle.Scoped);
        }

        private static Assembly GetSDKAssembly() => Assembly.Load("Connector.SDK");

        /// <summary>
        /// Get any DLL that contains "Connector.Tasks.*.dll"
        /// </summary>
        private static IEnumerable<Assembly> GetERPAssemblies()
        {
            string path = HostingEnvironment.MapPath("/bin");
            DirectoryInfo directory = new DirectoryInfo(path);

            bool checkIfMainDllFound = directory.GetFiles("Connector.Tasks.dll").Any();
            if (!checkIfMainDllFound) throw new DllNotFoundException($"Connector.Tasks.dll not found on {path}");

            FileInfo[] files = directory.GetFiles("Connector.Tasks*.dll");
            foreach (FileInfo file in files)
                yield return Assembly.Load(file.Name.Replace(".dll", ""));
        }
    }
}