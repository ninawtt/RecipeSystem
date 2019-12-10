using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string Path { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}



