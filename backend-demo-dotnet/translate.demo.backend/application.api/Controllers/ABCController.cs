using domain.extensions.Core.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace TranslateApi.Controllers
{

  public abstract class ABCController : ControllerBase
  {

    protected IActionResult BadRequest(ValidationErrorResponse body)
    {

      var problem = new ValidationProblemDetails(body.AsDict());

      return ValidationProblem(problem);

    }

  }

}
