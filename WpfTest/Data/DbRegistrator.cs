using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WpfTest.Context;
using Microsoft.EntityFrameworkCore;

namespace WpfTest.Data
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<TableDB>(opt => 
            {
                var type = configuration["Type"];
                switch(type)
                {
                    case null:
                        throw new InvalidOperationException("Не определен тип БД");
                    default:
                        throw new InvalidOperationException($"Тип подключения {type} не поддерживается");
                    case "PostgreSql":
                        opt.UseNpgsql(configuration.GetConnectionString(type));
                        break;
                }
            })
            .AddRepositoriesInDB()
            ;
    }
}
