using domain.models.Usecases.Translation;
using domain.usecases.Translation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TranslateApi.Controllers
{

  [Route("[controller]")]
  public class TranslationController : ABCController
  {

    readonly string[] LANGUAGES = new string[]{ "EN", "DE", "FR" };

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
    public IActionResult Translate([FromBody] TranslationRequest req)
    {

      var validation = req.IsValid(LANGUAGES);

      if (validation.ContainsErrors()) return BadRequest(validation);

      return Ok(_service.Translate(req));

    }

  }

}
