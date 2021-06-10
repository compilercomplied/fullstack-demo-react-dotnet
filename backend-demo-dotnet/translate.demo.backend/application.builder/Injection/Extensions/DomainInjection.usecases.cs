using domain.usecases.Translation;
using Microsoft.Extensions.DependencyInjection;

namespace application.builder.Injection.Extensions
{

  public static partial class DomainInjection
  {

    public static IServiceCollection ConfigureDomainServices(this IServiceCollection services) 
    {

      services
        .AddScoped<TranslationService>();

      return services;

    }

  }

}
