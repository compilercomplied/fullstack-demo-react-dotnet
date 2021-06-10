using domain.contracts.HttpClient;
using domain.extensions.Core.Result;
using domain.models.Usecases.Translation.HttpClient;
using System;
using System.Linq;

namespace http.client.Translation
{

  #region aliases
  using TranslationResult = Result<TranslationAPIResponse>;
  #endregion aliases

  public class MockTranslationClient : ITranslationClient
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
