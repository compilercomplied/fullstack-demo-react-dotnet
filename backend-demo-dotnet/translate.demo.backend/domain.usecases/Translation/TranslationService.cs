using AutoMapper;
using domain.contracts.HttpClient;
using domain.models.Usecases.Translation;
using domain.models.Usecases.Translation.HttpClient;
using Microsoft.Extensions.Logging;

namespace domain.usecases.Translation
{

  public class TranslationService
  {

    #region DI

    readonly ILogger<TranslationService> _logger;
    readonly ITranslationClient _client;
    readonly IMapper _mapper;

    public TranslationService(
      ILogger<TranslationService> logger,
      ITranslationClient client,
      IMapper mapper
    )
    {

      _logger = logger;
      _client = client;
      _mapper = mapper;

    }
    #endregion DI

    public TranslationResponse Translate(TranslationRequest req)
    {

      var apiRequest = _mapper.Map<TranslationAPIRequest>(req);
      var apiResponse = _client.Translate(apiRequest);

      var result = apiResponse.Unwrap();


      return _mapper.Map<TranslationResponse>(result);
    }

  }

}
