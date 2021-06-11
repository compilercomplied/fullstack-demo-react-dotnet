using domain.contracts.Providers;
using domain.models.Constants.Env;
using infra.providers.Google.Translation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace application.builder.Injection.Extensions
{

  public static partial class DomainInjection
  {

    public static IServiceCollection ConfigureProviderServices(
      this IServiceCollection services
    ) 
    {

      if (IsGoogleEnvConfigured())
      {
        services
          .AddScoped<ITranslationProviderService, GoogleTranslationProviderService>();
      }
      else
      { 
        services
          .AddScoped<ITranslationProviderService, MockTranslationProviderService>();
      }


      return services;

    }

    static bool IsGoogleEnvConfigured() =>
      !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(GoogleEnv.CREDENTIALS))
      && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(GoogleEnv.PROJECTID));

  }

}
