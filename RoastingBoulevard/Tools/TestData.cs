using System;
using System.Collections.Generic;
using RoastingBoulevard.Models;

namespace RoastingBoulevard.Tools
{
    public class TestData
    {



        public static List<Food> GetSnacks()
        {
            List<Food> list = new List<Food>();

            list.Add(new Food(0, "croquetasJamon", "descript_croquetasPollo", "ingredientsCroquetasJamon",
                new List<Food.Allergen> {Food.Allergen.Dairy,Food.Allergen.Gluten }
                , "https://firebasestorage.googleapis.com/v0/b/roastingboulevard.appspot.com/o/Food%2Fcroquetas_jamon.jpg?alt=media&token=990f568d-c177-4548-9d20-c428431536fe", 3
                ));
            list.Add(new Food(1, "bolasPollo", "descript_bolasPollo", "ingredients_bolasPollo",
               new List<Food.Allergen> { Food.Allergen.Dairy, Food.Allergen.Gluten }
               , "https://firebasestorage.googleapis.com/v0/b/roastingboulevard.appspot.com/o/Food%2Fbolitas_pollo.png?alt=media&token=97a2ba53-1d01-4562-9ffd-7af1f4f249c7", 3
               ));
            list.Add(new Food(3, "nuggets", "descript_nuggets", "ingredients_nuggets",
              new List<Food.Allergen> { Food.Allergen.Dairy, Food.Allergen.Gluten }
              , "https://firebasestorage.googleapis.com/v0/b/roastingboulevard.appspot.com/o/Food%2Fnuggets_pollo.jpg?alt=media&token=fd9ba962-8e44-4af2-86f4-70f34fbc32d3", 3
              ));
            list.Add(new Food(4, "patatasFritas", "descript_patatasFritas", "ingredients_patatasFritas",
             new List<Food.Allergen> { Food.Allergen.Dairy, Food.Allergen.Gluten }
             , "https://www.cocinacaserayfacil.net/wp-content/uploads/2019/01/Patatas-fritas-caseras-perfectas-y-crujientes.jpg", 3
             ));
            return list;
        }
    }
}
