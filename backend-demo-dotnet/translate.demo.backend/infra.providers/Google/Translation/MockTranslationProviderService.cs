using domain.contracts.Providers;
using domain.extensions.Core.Result;
using domain.models.Usecases.Translation.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.providers.Google.Translation
{

  #region aliases
  using TranslationResult = Result<TranslationAPIResponse>;
  #endregion aliases

  public class MockTranslationProviderService : ITranslationProviderService
  {
    public TranslationResult Translate(TranslationAPIRequest req)
    {

      var resultText = new string(req.Text.ToCharArray().Reverse().ToArray());

      return TranslationResult.OK(
        new TranslationAPIResponse($"{resultText} - {req.TargetLanguage}")
      );

    }

  }
}
