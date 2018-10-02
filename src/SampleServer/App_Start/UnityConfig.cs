using System;
using NLog;
using SampleServer.Persistence;
using SampleServer.Persistence.QueueContext;
using SampleServer.Services;
using Unity;

namespace SampleServer
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            var logger = NLog.LogManager.GetLogger("SampleServer");
            container.RegisterInstance<ILogger>(logger);

            container.RegisterType<IQueueContext, QueueContext>();

            var deviceManager = new DeviceManager();
            container.RegisterInstance<IDeviceManager>(deviceManager);

            var testDevice = new Device("TEST-OEM~00001234", container.Resolve<QueueDataService>());
            testDevice.SharedKey = "9nF2W3A18UG8XOGI7gsk2UV+CdpsSCZ3YHGvQjkKtKY="; 
            deviceManager.AddController("TEST-OEM~00001234", testDevice);
        }
    }
}