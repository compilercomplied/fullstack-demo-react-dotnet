using domain.contracts.Providers;
using domain.extensions.Core.Result;
using domain.models.Constants.Env;
using domain.models.Usecases.Translation.HttpClient;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.Translate.V3;
using System;
using System.Linq;

namespace infra.providers.Google.Translation
{

  #region aliases
  using TranslationResult = Result<TranslationAPIResponse>;
  #endregion aliases

  public class GoogleTranslationProviderService : ITranslationProviderService
  {

    readonly string ProjectID;

    readonly TranslationServiceClient _client;

    public GoogleTranslationProviderService()
    {

      _client = TranslationServiceClient.Create();
      ProjectID = Environment.GetEnvironmentVariable(GoogleEnv.PROJECTID);

    }

    public TranslationResult Translate(TranslationAPIRequest req)
    {

      var googleRequest = new TranslateTextRequest
      {
        Contents = { req.Text },
        TargetLanguageCode = req.TargetLanguage,
        Parent = new ProjectName(ProjectID).ToString(),
        MimeType = "text/plain",
      };


      var response = _client.TranslateText(googleRequest);
      var translation = response.Translations.FirstOrDefault();

      return TranslationResult.OK(
        new TranslationAPIResponse(translation?.TranslatedText)
      );
    }

  }

}
