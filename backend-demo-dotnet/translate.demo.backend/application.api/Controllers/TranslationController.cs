using domain.models.Usecases.Translation;
using domain.usecases.Translation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TranslateApi.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class TranslationController : ControllerBase
  {

    #region DI
    readonly ILogger<TranslationController> _logger;
    readonly TranslationService _service;

    public TranslationController(
      ILogger<TranslationController> logger,
      TranslationService service
    )
    {
      _logger = logger;
      _service = service;
    }
    #endregion DI

    [HttpPost]
    public TranslationResponse Translate([FromBody] TranslationRequest req)
    {

      return _service.Translate(req);

    }

  }

}
