using System.Data;
using CohorteApi.Models;

namespace CohorteApi.Data.Seeds
{
    public static class TagsSeed
    {
        public static IEnumerable<Tag> GetData()
        {
            var objs = new[]
            {
                new Tag(){Id=1,Name = "Pop"},
                new Tag(){Id=2,Name = "Punk"},
                new Tag(){Id=3,Name = "Rock"},
                new Tag(){Id=4,Name = "Ballad"},
            };

            return objs;
        }
    }
}


