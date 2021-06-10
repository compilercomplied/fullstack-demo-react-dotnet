using domain.extensions.Core.Result;
using domain.models.Usecases.Translation.HttpClient;

namespace domain.contracts.HttpClient
{

  public interface ITranslationClient
  {

    Result<TranslationAPIResponse> Translate(TranslationAPIRequest req);

  }

}
