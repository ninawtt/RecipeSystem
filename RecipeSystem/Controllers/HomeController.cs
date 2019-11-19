using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem.Models;

namespace RecipeSystem.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository recipeRepository;

        // Constructor
        public HomeController(IRecipeRepository repo) // magic of Dependency Injection
        {
            recipeRepository = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipeRepository.SaveRecipe(recipe);
                return View("Thanks");
            }
            else
            {
                return View(recipe);
            }
        }

        public ViewResult RecipeList()
        {
            return View(recipeRepository.Recipes);
        }

        public ViewResult ViewRecipe(int recipeID)
        {
            Recipe recipe = recipeRepository.Recipes
                .FirstOrDefault(r => r.RecipeID == recipeID);
            return View(recipe);
        }

        [HttpGet]
        public ViewResult ReviewRecipe()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ReviewRecipe(Review review)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks");
            }
            else
            {
                return View(review);
            }
        }
    }
}
