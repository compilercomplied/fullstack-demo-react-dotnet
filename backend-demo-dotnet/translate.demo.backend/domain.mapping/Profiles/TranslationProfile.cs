using AutoMapper;
using domain.models.Usecases.Translation;
using domain.models.Usecases.Translation.HttpClient;

namespace domain.mapping.Profiles
{

  public class TranslationProfile : Profile
  {

    public TranslationProfile()
    {

      TranslationAPIMappings();

    }



    void TranslationAPIMappings()
    {

      CreateMap<TranslationRequest, TranslationAPIRequest>();

      CreateMap<TranslationAPIResponse, TranslationResponse>();

    }


  }

}
