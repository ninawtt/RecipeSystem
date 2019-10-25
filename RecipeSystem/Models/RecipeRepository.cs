using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public static class RecipeRepository
    {
        private static List<Recipe> recipes = new List<Recipe>();

        public static IEnumerable<Recipe> Recipes
        {
            get
            {
                return recipes;
            }
        }

        public static void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }
    }
}
