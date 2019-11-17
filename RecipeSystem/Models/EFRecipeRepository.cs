using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        // Constructor 
        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;

        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeID == 0) // if the RecipeID equal 0, it means it is a new one, then save it into the Recipes
            {
                context.Recipes.Add(recipe);
            } 
            else
            {
                Recipe recipeEntry = context.Recipes
                    .FirstOrDefault(r => r.RecipeID == recipe.RecipeID);

                if (recipeEntry != null)
                {
                    recipeEntry.DishName = recipe.DishName;
                    recipeEntry.Author = recipe.Author;
                    recipeEntry.BriefIntro = recipe.BriefIntro;
                    recipeEntry.PrepTime = recipe.PrepTime;
                    recipeEntry.Servings = recipe.Servings;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    recipeEntry.Directions = recipe.Directions;
                }
            }
            context.SaveChanges();
        }
    }
}
