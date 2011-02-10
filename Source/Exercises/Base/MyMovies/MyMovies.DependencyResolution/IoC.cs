using MyMovies.DomainModel;
using MyMovies.DomainModel.Services;
using MyMovies.DomainModel.ServicesImpl;
using MyMovies.DomainModel.ServicesRepositoryInterfaces;
using MyMovies.RepImpl;
using StructureMap;
namespace MyMovies.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>{
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });

                            // IMoviesService
                            //x.For<IMoviesService>().HttpContextScoped().Use<EFMoviesService>();
                            x.For<IMoviesService>().HttpContextScoped().Use<InMemoryMoviesService>();
                            //x.For<IMoviesService>().HttpContextScoped().Use<RepositoryMoviesService>();

                            // IMoviesRepository
                            x.For<IMoviesRepository>().HttpContextScoped().Use<EFIMDBAPIMoviesRepository>();

                            // MovieDbContext
                            x.For<MovieDbContext>().HttpContextScoped().Use<MovieDbContext>();
                        });
            return ObjectFactory.Container;
        }
    }
}