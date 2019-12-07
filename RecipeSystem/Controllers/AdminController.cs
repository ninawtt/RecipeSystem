using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal; //Contain a method to access the physical path of a variable in the application

namespace RecipeSystem.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRecipeRepository recipeRepository;
        private HostingEnvironment hostingEnvironment;

        // Constructor
        public AdminController (IRecipeRepository repo, HostingEnvironment hostingEnv)
        {
            recipeRepository = repo;
            hostingEnvironment = hostingEnv; // to implement the image uploading function
        }
        
        public ViewResult Index() => View(recipeRepository.Recipes);

        public ViewResult Create()
        {
            ViewBag.Title = "Add Recipe";
            return View("Update", new Recipe());
        }

        public ViewResult Update(int recipeID)
        {
            ViewBag.Title = "Update Recipe";
            return View(recipeRepository.Recipes
                .FirstOrDefault(r => r.RecipeID == recipeID));
        }

        [HttpPost]
        public IActionResult Update(Recipe recipe)
        {
            if (!ModelState.IsValid) //server-side validation
            {
                ViewBag.Title = "Update Recipe";
                return View(recipe);
            }
            
            recipeRepository.SaveRecipe(recipe);
            TempData["message"] = $"{recipe.DishName} has been saved!";

            /////////////////////
            //Save Recipe Image//
            /////////////////////

            // Get recipe ID we have saved in database
            int recipeID = recipe.RecipeID;

            // Get wwwroot path to save the file on server
            string wwwrootPath = hostingEnvironment.WebRootPath;

            // Get the uploaded files
            var files = HttpContext.Request.Form.Files;

            // Get the reference of DBset for the recipe we just have saved in database
            Recipe savedRecipe = recipeRepository.Recipes
                .FirstOrDefault(r => r.RecipeID == recipeID);
            
            //V2
            if (files.Count != 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string imagePath = @"images/recipe/";
                    string extension = Path.GetExtension(files[i].FileName);
                    string RelativeImagePath = imagePath + recipeID + "-" + (i+1) + extension;
                    string absImagePath = Path.Combine(wwwrootPath, RelativeImagePath);

                    //Upload the file on server
                    using (var fileStream = new FileStream(absImagePath, FileMode.Create))
                    {
                        files[i].CopyTo(fileStream);
                    }

                    // Set the image path on database
                    
                    if(savedRecipe.Images != null)
                    {
                        savedRecipe.Images.Add(new Image() { RecipeID = savedRecipe.RecipeID, Path = RelativeImagePath });
                    } else
                    {
                        savedRecipe.Images = new List<Image> { new Image() { RecipeID = savedRecipe.RecipeID, Path = RelativeImagePath } };
                    }
                }
            }
            else
            {
                // Set the default image path on database
                savedRecipe.Images = new List<Image> { new Image() { RecipeID = savedRecipe.RecipeID, Path = "images/DefaultRecipe.jpg" } };
            }



            //V1
            // Upload the files on server and save the image path if user have uploaded any file
            //if (files.Count != 0)
            //{
            //    string imagePath = @"images/recipe/";
            //    string extension = Path.GetExtension(files[0].FileName);
            //    string RelativeImagePath = imagePath + recipeID + extension;
            //    string absImagePath = Path.Combine(wwwrootPath, RelativeImagePath);

            //    //Upload the file on server
            //    using (var fileStream = new FileStream(absImagePath, FileMode.Create))
            //    {
            //        files[0].CopyTo(fileStream);
            //    }

            //    // Set the image path on database
            //    savedRecipe.ImagePath = RelativeImagePath;

            //}
            //else
            //{
            //    // Set the default image path on database
            //    savedRecipe.ImagePath = "images/DefaultRecipe.jpg";
            //}
            
            recipeRepository.SaveRecipe(savedRecipe);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int recipeID)
        {
            Recipe deletedRecipe = recipeRepository.DeleteRecipe(recipeID);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.DishName} was deleted!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
