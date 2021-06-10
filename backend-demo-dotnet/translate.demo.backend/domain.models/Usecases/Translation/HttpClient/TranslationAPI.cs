
namespace domain.models.Usecases.Translation.HttpClient
{

  public record TranslationAPIRequest
  (
    string SourceLanguage,
    string TargetLanguage,
    string Text
  );

  public record TranslationAPIResponse
  (
    string Text
  );

}
