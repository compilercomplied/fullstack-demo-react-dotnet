
using domain.extensions.Core.Result;
using System.Linq;

namespace domain.models.Usecases.Translation
{

  public record TranslationRequest
  {

    public string SourceLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string Text { get; set; }


    public ValidationErrorResponse IsValid(string[] languages)
    {
      var validation = new ValidationErrorResponse();


      if (!languages.Contains(SourceLanguage.ToUpperInvariant()))
        validation.AddError(nameof(SourceLanguage), $"Available languages : {string.Join(",", languages)}");

      if (!languages.Contains(TargetLanguage.ToUpperInvariant()))
        validation.AddError(nameof(TargetLanguage), $"Available languages : {string.Join(",", languages)}");

      if (string.IsNullOrEmpty(Text))
        validation.AddError(nameof(Text));

      return validation;

    }

  };

  public record TranslationResponse
  (
    string Text
  );
}
