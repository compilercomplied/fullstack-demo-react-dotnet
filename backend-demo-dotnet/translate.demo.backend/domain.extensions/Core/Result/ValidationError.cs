using System;
using System.Collections.Generic;
using System.Linq;

namespace domain.extensions.Core.Result
{

  public class ValidationErrorResponse
  {

    public readonly IList<ValidationError> ValidationErrors;

    public ValidationErrorResponse()
    { 

      ValidationErrors = new List<ValidationError>() { };

    }

    public bool ContainsErrors() => ValidationErrors.Any();

    public void AddError(string property, string message = null) =>
      ValidationErrors.Add(new ValidationError
      {
        Property = property,
        Message = message ?? Messages.Validation_DefaultError,
      });

    public IDictionary<string, string[]> AsDict()
    {

      var result = new Dictionary<string, string[]>();

      foreach (var err in ValidationErrors)
        result[err.Property] = new[] { err.Message };

      return result;

    }

  }

  public class ValidationError
  {

    public string Property { get; set; }
    public string Message { get; set; }

  }

}
