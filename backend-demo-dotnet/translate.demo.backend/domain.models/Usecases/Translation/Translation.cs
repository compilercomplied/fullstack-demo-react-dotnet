
namespace domain.models.Usecases.Translation
{

  public record TranslationRequest
  (
    string SourceLanguage,
    string TargetLanguage,
    string Text
  );

  public record TranslationResponse
  (
    string Text
  );
}
