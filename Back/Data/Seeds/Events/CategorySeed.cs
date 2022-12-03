using CohorteApi.Models;

namespace CohorteApi.Data.Seeds.Events
{
    public static class CategoriesSeed
    {
        public static IEnumerable<Category> GetData()
        {
            /*
             4. Catalogo
  - 
  - Teatro
  - Familiar
  - Deporte
  - Seminarios
  - Cursos y Tallers

             */
            var objs = new[] {
                new Category() {Id=1,Name = "Musica" },
                new Category() {Id=2,Name = "Familiar" },
                new Category() {Id=3,Name = "Deporte" },
                new Category() {Id=4,Name = "Seminarios" },
                new Category() {Id=5,Name = "Cursos y Talleres" },

                 };

            return objs;
        }
    }
}
