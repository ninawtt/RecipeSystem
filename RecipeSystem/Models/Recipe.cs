using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }

        [Required(ErrorMessage = "Please enter dish name")]
        public string DishName { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter brief introduction")]
        public string BriefIntro { get; set; }

        [Required(ErrorMessage = "Please enter prepare time")]
        public int PrepTime { get; set; }

        [Required(ErrorMessage = "Please enter how many servings")]
        public int Servings { get; set; }

        [Required(ErrorMessage = "Please enter ingredients")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Please enter directions")]
        public string Directions { get; set; }

        public List<Image> Images { get; set; }
    }
}
