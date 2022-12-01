using CohorteApi.Core.Models.Newsletter;
using CohorteApi.Models;

namespace CohorteApi.Core.Mapper
{
    public static class NewsletterMapper
    {
        public static Newsletter ToEntity( this NewsletterDTO dto)
        {
            //todo mappings
            return new Newsletter();
        }


        public static NewsletterDTO ToDTO(this Newsletter obj)
        {
            //todo mappings
            return new NewsletterDTO();
        }

    }
}
