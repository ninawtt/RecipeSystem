using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public class Review
    {
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter score")]
        public int Score { get; set; }

        [Required(ErrorMessage = "Please enter your comment")]
        public string Comment { get; set; }

        public DateTime ReviewTime { get; set; }
    }
}
