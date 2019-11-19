﻿using Microsoft.AspNetCore.Mvc;
using RecipeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Controllers
{
    public class AdminController : Controller
    {
        private IRecipeRepository recipeRepository;

        // Constructor
        public AdminController (IRecipeRepository repo)
        {
            recipeRepository = repo;
        }
        
        public ViewResult Index() => View(recipeRepository.Recipes);

        public ViewResult Update(int recipeID)
        {
            return View(recipeRepository.Recipes
                .FirstOrDefault(r => r.RecipeID == recipeID));
        }

        [HttpPost]
        public IActionResult Update(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipeRepository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.DishName} has been saved!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(recipe);
            }
        }
    }
}
