using Microsoft.Extensions.DependencyInjection;
using WpfTest.Interfaces;
using WpfTest.Models;

namespace WpfTest.Data
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Table>, DbRepository<Table>>()
            ;
    }
}
