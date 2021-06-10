using domain.contracts.HttpClient;
using http.client.Translation;
using Microsoft.Extensions.DependencyInjection;

namespace application.builder.Injection.Extensions
{

  public static partial class DomainInjection
  {

    public static IServiceCollection ConfigureHttpClients(this IServiceCollection services) 
    {

      services
        .AddScoped<ITranslationClient, MockTranslationClient>();

      return services;

    }

  }

}
