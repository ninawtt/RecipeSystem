using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public class RecipeRepository
    {

        private static List<Recipe> recipes = new List<Recipe>
        {
            // hard code data
            new Recipe
                {
                    RecipeID = 1,
                    DishName = "Sesame Chicken",
                    Author = "MISSFAVOR",
                    BriefIntro = "Delicious Sesame Chicken",
                    Servings = 4,
                    PrepTime = 50,
                    Ingredients = "Chicken",
                    Directions = "Step1: , Step2: , Step3: , Step4: ",
                    ImagePath = "SesameChicken.png"
                },
                new Recipe
                {
                    RecipeID = 2,
                    DishName = "Chicken Congee",
                    Author = "Buckwheat Queen",
                    BriefIntro = "Delicious Chicken Congee",
                    Servings = 6,
                    PrepTime = 75,
                    Ingredients = "Chicken breast",
                    Directions = "Step1: , Step2: , Step3: , Step4: ",
                    ImagePath = "ChickenCongee.png"
                },
                new Recipe
                {
                    RecipeID = 3,
                    DishName = "Pad Thai",
                    Author = "Allrecipes",
                    BriefIntro = "Delicious Pad Thai",
                    Servings = 6,
                    PrepTime = 60,
                    Ingredients = "Rice noodles, Chicken breast",
                    Directions = "Step1: , Step2: , Step3: , Step4: ",
                    ImagePath = "PadThai.png"
                },
                new Recipe
                {
                    RecipeID = 4,
                    DishName = "Chicken Enchilada Skillet",
                    Author = " Campbell's Canada",
                    BriefIntro = "Delicious Chicken Enchilada Skillet",
                    Servings = 4,
                    PrepTime = 30,
                    Ingredients = "Chicken breast, Mexican cheese blend, Instant white rice",
                    Directions = "Step1: , Step2: , Step3: , Step4: ",
                    ImagePath = "Enchilada.png"
                }
        };
        private static int counter = recipes.Count();

        public static IEnumerable<Recipe> Recipes
        {
            get
            {
                return recipes;
            }
        }

        public static void AddRecipe(Recipe recipe)
        {
            recipe.RecipeID = ++counter;
            recipes.Add(recipe);
        }
    }
}
