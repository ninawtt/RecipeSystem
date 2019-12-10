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
                    BriefIntro = "My family begs for this dish! Much easier to prepare than the ingredient list indicates. If you are a fan of Chinese food, prepare to become ADDICTED to this yummy sesame chicken. Serve over jasmine rice.",
                    Servings = 4,
                    PrepTime = 50,
                    Ingredients = "Chicken",
                    Directions = "Step1: , Step2: , Step3: , Step4: ",
                    //ImagePath = "SesameChicken.png"
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
                    //ImagePath = "ChickenCongee.png"
                },
                new Recipe
                {
                    RecipeID = 3,
                    DishName = "Authentic Pad Thai",
                    Author = "Allrecipes",
                    BriefIntro = "Inspired by the pad thai at Thai Tom, this recipe features a tamarind paste, vinegar, sugar, and fish sauce mixture over perfectly stir-fried eggs, chicken breast, and rice noodles, garnished with peanuts, chives, and fresh bean sprouts.",
                    Servings = 6,
                    PrepTime = 60,
                    Ingredients = "Rice noodles, Chicken breast",
                    Directions = "Step1: , Step2: , Step3: , Step4: ",
                    //ImagePath = "PadThai.png"
                },
                new Recipe
                {
                    RecipeID = 4,
                    DishName = "Chicken Enchilada Skillet",
                    Author = " Campbell's Canada",
                    BriefIntro = "Feel like having enchiladas tonight but don't want to fuss around with the stuffing and baking? This one-dish rice skillet has all the flavor of enchiladas and comes together in record time as the rice and chicken cook to perfection right in the sauce.",
                    Servings = 4,
                    PrepTime = 30,
                    Ingredients = "Chicken breast, Mexican cheese blend, Instant white rice",
                    Directions = "Step1: , Step2: , Step3: , Step4: ",
                    //ImagePath = "Enchilada.png"
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
