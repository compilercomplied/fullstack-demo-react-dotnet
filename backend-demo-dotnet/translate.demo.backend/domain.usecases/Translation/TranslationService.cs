using AutoMapper;
using domain.contracts.Providers;
using domain.models.Usecases.Translation;
using domain.models.Usecases.Translation.HttpClient;
using Microsoft.Extensions.Logging;

namespace domain.usecases.Translation
{

  public class TranslationService
  {

    #region DI

    readonly ILogger<TranslationService> _logger;
    readonly ITranslationProviderService _prov;
    readonly IMapper _mapper;

    public TranslationService(
      ILogger<TranslationService> logger,
      ITranslationProviderService prov,
      IMapper mapper
    )
    {

      _logger = logger;
      _prov = prov;
      _mapper = mapper;

    }
    #endregion DI

    public TranslationResponse Translate(TranslationRequest req)
    {

      var apiRequest = _mapper.Map<TranslationAPIRequest>(req);
      var apiResponse = _prov.Translate(apiRequest);

      var result = apiResponse.Unwrap();


      return _mapper.Map<TranslationResponse>(result);
    }

  }

}
