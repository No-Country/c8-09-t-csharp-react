using System.Data;
using CohorteApi.Models;

namespace CohorteApi.Data.Seeds
{
    public static class RestrictionsSeed
    {
        public static IEnumerable<Restriction> GetData()
        {
            var objs = new[] {
                new Restriction() {Id =1, Name="age must be 18+", Category="Age",Condition="age>18", Description="" },
                new Restriction() {Id = 2, Name="No alcohol" ,Category ="", Condition="alcohol not allowed", Description="" },
            };
          
            return objs;
        }
    }
}


