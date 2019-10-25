using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string DishName { get; set; }
        public string Author { get; set; }
        public string BriefIntro { get; set; }
        public int PrepTime { get; set; }
        public int Servings { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
        public string ImagePath { get; set; }
    }
}
