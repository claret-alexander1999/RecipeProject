using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeProject.Models
{
    public class Recipe
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string RecipeName { get; set; }
        public string MadeByName { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }

       // &#10;
        public override string ToString()
        {
            return this.RecipeName +System.Environment.NewLine+ " Made by " + this.MadeByName;

        }

    }
}
