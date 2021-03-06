using Microsoft.Extensions.DependencyInjection;

namespace WpfTest.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            ;
    }
}
