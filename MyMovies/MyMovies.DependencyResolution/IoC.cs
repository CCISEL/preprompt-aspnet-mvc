using MyMovies.DomainModel;
using MyMovies.DomainModel.Services;
using MyMovies.DomainModel.ServicesImpl;
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
                            x.For<IMoviesService>().HttpContextScoped().Use<EFMoviesService>();
                            x.For<MovieDBContext>().HttpContextScoped().Use<MovieDBContext>();
                        });
            return ObjectFactory.Container;
        }
    }
}