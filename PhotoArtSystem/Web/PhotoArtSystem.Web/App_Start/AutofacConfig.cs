﻿namespace PhotoArtSystem.Web.App_Start
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using AutoMapper;
    using CloudStorages.CloudinaryApi;
    using CloudStorages.Contracts;
    using Common.Providers;
    using Common.Providers.Contracts;
    using Controllers;
    using Data;
    using Data.Common.EfDbContexts;
    using Data.Common.Repositories;
    using Data.Models.Factories;
    using Infrastructure.Mapping;
    using Infrastructure.Sanitizer;
    using Services.Data;
    using Services.Web;
    using Services.Web.Contracts;
    using Web;

    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new CloudStorageConfigurationProvider())
                .As<ICloudStorageConfigurationProvider>()
                .SingleInstance();

            builder.Register(x => new ApplicationDbContext())
                .As<DbContext>()
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(PhotoArtSystemEfDbRepository<>))
                .As(typeof(IPhotoArtSystemEfDbRepository<>))
                .InstancePerRequest();

            builder.RegisterType<EfDbContextSaveChanges>()
                .As<IEfDbContextSaveChanges>()
                .InstancePerRequest();

            builder.Register(x => new HttpCacheService())
               .As<ICacheService>()
               .InstancePerRequest();

            builder.Register(x => new HtmlSanitizerAdapter())
                .As<ISanitizer>()
                .InstancePerRequest();

            builder.RegisterType<AutoMapperService>()
                .As<IAutoMapperService>()
                .InstancePerRequest();

            builder.RegisterType<CloudinaryCloudStorage>()
                .As<IImageCloudStorage>()
                .InstancePerRequest();

            builder.Register(c => AutoMapperConfig.Configuration.CreateMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope();

            builder.Register(x => new ModelDbFactory())
                .As<IModelDbFactory>()
                .SingleInstance();

            builder.Register(x => new DateTimeProvider())
                .As<IDateTimeProvider>()
                .SingleInstance();

            var userServicesAssembly = Assembly.GetAssembly(typeof(ApplicationUserProfileService));
            builder.RegisterAssemblyTypes(userServicesAssembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>().PropertiesAutowired();
        }
    }
}
