namespace PhotoArtSystem.Web.Infrastructure.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;

    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration { get; private set; }

        public void Execute(Assembly assemblyWeb, Assembly assemblyDb)
        {
            Configuration = new MapperConfiguration(
                cfg =>
                {
                    var typesWeb = assemblyWeb.GetExportedTypes();
                    LoadStandardMappings(typesWeb, cfg);
                    LoadReverseMappings(typesWeb, cfg);
                    LoadCustomMappings(typesWeb, cfg);

                    var typesDb = assemblyDb.GetExportedTypes();
                    LoadStandardMappings(typesDb, cfg);
                    LoadReverseMappings(typesDb, cfg);
                    LoadCustomMappings(typesDb, cfg);
                });
        }

        private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression configuration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                configuration.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadReverseMappings(IEnumerable<Type> types, IMapperConfigurationExpression configuration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Destination = i.GetGenericArguments()[0],
                            Source = t
                        }).ToArray();

            foreach (var map in maps)
            {
                configuration.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression configuration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(configuration);
            }
        }
    }
}
