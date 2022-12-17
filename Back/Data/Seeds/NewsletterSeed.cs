using System.Data;
using CohorteApi.Models;

namespace CohorteApi.Data.Seeds
{
    public static class NewsletterSeed
    {
        public static IEnumerable<Newsletter> GetData()
        {
            var newsletters = new[] {
                new Newsletter() {},
                new Newsletter() { },
            };
          
            return newsletters;
        }
    }
}


