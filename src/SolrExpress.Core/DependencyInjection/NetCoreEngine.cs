﻿#if NETCOREAPP1_0
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace SolrExpress.Core.DependencyInjection
{
    internal class NetCoreEngine : IEngine
    {
        /// <summary>
        /// Object used in lock
        /// </summary>
        private readonly object _lockObject = new object();

        /// <summary>
        /// Service provider instance
        /// </summary>
        private IServiceProvider _serviceProvider;

        /// <summary>
        /// Collection of service descriptors
        /// </summary>
        private IServiceCollection _serviceCollection;

        /// <summary>
        /// Default constructor of class
        /// </summary>
        public NetCoreEngine()
        {
            this._serviceCollection = new ServiceCollection();
        }

        /// <summary>
        /// Get service provider instance
        /// </summary>
        /// <returns>Service provider instance</returns>
        private IServiceProvider GetServiceProvider()
        {
            lock (this._lockObject)
            {
                if (this._serviceProvider == null)
                {
                    this._serviceProvider = this._serviceCollection.BuildServiceProvider();
                }
            }

            return _serviceProvider;
        }

        /// <summary>
        /// Adds a singleton service of the type specified in TService with an implementation type specified in TImplementation to the specified DI container
        /// </summary>
        /// <typeparam name="TService">The type of the service to add</typeparam>
        /// <returns>This</returns>
        IEngine IEngine.AddSingleton<TService>()
        {
            this._serviceCollection.TryAddSingleton<TService>();

            return this;
        }

        /// <summary>
        /// Adds a singleton service of the type specified in TService with an implementation type specified in TImplementation to the specified DI container
        /// </summary>
        /// <typeparam name="TService">The type of the service to add</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use</typeparam>
        /// <returns>This</returns>
        IEngine IEngine.AddSingleton<TService, TImplementation>(TImplementation instance)
        {
            this._serviceCollection.TryAddSingleton<TService>(q => instance);

            return this;
        }

        /// <summary>
        /// Adds a singleton service of the type specified in TService with an implementation type specified in TImplementation to the specified DI container
        /// </summary>
        /// <typeparam name="TService">The type of the service to add</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use</typeparam>
        /// <returns>This</returns>
        IEngine IEngine.AddSingleton<TService, TImplementation>()
        {
            this._serviceCollection.TryAddSingleton<TService, TImplementation>();

            return this;
        }

        /// <summary>
        /// Adds a transient service of the type specified in TService with an implementation type specified in TImplementation to the specified DI container
        /// </summary>
        /// <typeparam name="TService">The type of the service to add</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use</typeparam>
        /// <returns>This</returns>
        IEngine IEngine.AddTransient<TService, TImplementation>()
        {
            this._serviceCollection.TryAddTransient<TService, TImplementation>();

            return this;
        }

        /// <summary>
        /// Adds a transient service of the type specified in TService with an implementation type specified in TImplementation to the specified DI container
        /// </summary>
        /// <param name="instance">Instace of TImplementation used to resolve DI</param>
        /// <typeparam name="TService">The type of the service to add</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use</typeparam>
        /// <returns>This</returns>
        IEngine IEngine.AddTransient<TService, TImplementation>(TImplementation instance)
        {
            this._serviceCollection.AddTransient<TService, TImplementation>(q => instance);

            return this;
        }

        /// <summary>
        /// Get service of type TService from the DI provider
        /// </summary>
        /// <returns>Instance of type TService</returns>
        TService IEngine.GetService<TService>()
        {
            return this.GetServiceProvider().GetRequiredService<TService>();
        }
    }
}
#endif