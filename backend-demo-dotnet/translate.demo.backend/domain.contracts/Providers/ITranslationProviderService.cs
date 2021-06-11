using domain.extensions.Core.Result;
using domain.models.Usecases.Translation.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.contracts.Providers
{

  public interface ITranslationProviderService
  {

    Result<TranslationAPIResponse> Translate(TranslationAPIRequest req);

  }

}
