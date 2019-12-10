using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public static class SeedData
    {
        // ensure the database is populated with data
        // the parameter will be sent from the startup (we call this method in startup)
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate(); // Migrations script will run automatically, it will only run once to create the database and tables
            // if we have another new context, we need to run it manually by using
            // dotnet ef database update -- context + contextName

            if (!context.Recipes.Any()) // if there's no data in the Recipes table inside the database, then do the following thing
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        DishName = "Sesame Chicken",
                        Author = "MISSFAVOR",
                        BriefIntro = "My family begs for this dish! Much easier to prepare than the ingredient list indicates. If you are a fan of Chinese food, prepare to become ADDICTED to this yummy sesame chicken. Serve over jasmine rice.",
                        Servings = 4,
                        PrepTime = 50,
                        Ingredients = "Chicken",
                        Directions = "Step1: , Step2: , Step3: , Step4: ",
                        Images = new List<Image>() { new Image() { RecipeID = 1, Path = "images/SesameChicken.png" } }
                        //ImagePath = "images/SesameChicken.png"
                    },
                    new Recipe
                    {
                        DishName = "Chicken Congee",
                        Author = "Buckwheat Queen",
                        BriefIntro = "Delicious Chicken Congee",
                        Servings = 6,
                        PrepTime = 75,
                        Ingredients = "Chicken breast",
                        Directions = "Step1: , Step2: , Step3: , Step4: ",
                        Images = new List<Image>() { new Image() { RecipeID = 2, Path = "images/ChickenCongee.png" } }
                        //ImagePath = "images/ChickenCongee.png"
                    },
                    new Recipe
                    {
                        DishName = "Authentic Pad Thai",
                        Author = "Allrecipes",
                        BriefIntro = "Inspired by the pad thai at Thai Tom, this recipe features a tamarind paste, vinegar, sugar, and fish sauce mixture over perfectly stir-fried eggs, chicken breast, and rice noodles, garnished with peanuts, chives, and fresh bean sprouts.",
                        Servings = 6,
                        PrepTime = 60,
                        Ingredients = "Rice noodles, Chicken breast",
                        Directions = "Step1: , Step2: , Step3: , Step4: ",
                        Images = new List<Image>() { new Image() { RecipeID = 3, Path = "images/PadThai.png" } }
                        //ImagePath = "images/PadThai.png"
                    },
                    new Recipe
                    {
                        DishName = "Chicken Enchilada Skillet",
                        Author = " Campbell's Canada",
                        BriefIntro = "Feel like having enchiladas tonight but don't want to fuss around with the stuffing and baking? This one-dish rice skillet has all the flavor of enchiladas and comes together in record time as the rice and chicken cook to perfection right in the sauce.",
                        Servings = 4,
                        PrepTime = 30,
                        Ingredients = "Chicken breast, Mexican cheese blend, Instant white rice",
                        Directions = "Step1: , Step2: , Step3: , Step4: ",
                        Images = new List<Image>() { new Image() { RecipeID = 4, Path = "images/Enchilada.png" } }
                        //ImagePath = "images/Enchilada.png"
                    }
                 );

                context.SaveChanges(); // save the data in the database
            }
        }
    }
}
