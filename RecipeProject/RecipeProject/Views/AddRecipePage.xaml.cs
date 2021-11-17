using RecipeProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRecipePage : ContentPage
    {
        private Entry RecipeNameEntry;
        private Entry MadeByNameEntry;
        private Entry IngredientsEntry;
        private Entry StepsEntry;
        private Button SaveButton;

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myRecipes.db3");

        public AddRecipePage()
        {
            this.Title = "Enter the Recipe";
            StackLayout stackLayout = new StackLayout();

            Label Name = new Label();
            Name.Text = "Recipe Name";
            RecipeNameEntry = new Entry();
            RecipeNameEntry.Keyboard = Keyboard.Text;
            RecipeNameEntry.Placeholder = "Recipe Name";
            stackLayout.Children.Add(Name);
            stackLayout.Children.Add(RecipeNameEntry);

            Label MDName = new Label();
            MDName.Text = "Made by"; 
            MadeByNameEntry = new Entry();
            MadeByNameEntry.Keyboard = Keyboard.Text;
            MadeByNameEntry.Placeholder = "Made by Name";
            stackLayout.Children.Add(MDName);
            stackLayout.Children.Add(MadeByNameEntry);

            Label IngredientsText = new Label();
            IngredientsText.Text = "List of Ingredients";
            IngredientsEntry = new Entry();
            IngredientsEntry.Keyboard = Keyboard.Text;
            IngredientsEntry.Placeholder = "Ingredients";
            stackLayout.Children.Add(IngredientsText);
            stackLayout.Children.Add(IngredientsEntry);

            Label StepsText = new Label();
            StepsText.Text = "Steps to follow";
            StepsEntry = new Entry();
            StepsEntry.Keyboard = Keyboard.Text;
            StepsEntry.Placeholder = "Mention the Steps";
            stackLayout.Children.Add(StepsText);
            stackLayout.Children.Add(StepsEntry);

            SaveButton = new Button();
            SaveButton.Text = "Save";
            SaveButton.Clicked += SaveButton_Clicked;
            stackLayout.Children.Add(SaveButton);

            Content = stackLayout;

        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Recipe>();

            var maxPK = db.Table<Recipe>().OrderByDescending(comparer => comparer.ID).FirstOrDefault();

            Recipe recipe = new Recipe()
            {
                ID = (maxPK == null ? 1 : maxPK.ID + 1),
                RecipeName = RecipeNameEntry.Text,
                MadeByName = MadeByNameEntry.Text,
                Ingredients = IngredientsEntry.Text,
                Steps = StepsEntry.Text
            };

            db.Insert(recipe);
            await DisplayAlert(null, recipe.RecipeName + " Saved", "OK");
            await Navigation.PushAsync(new MainPage());

        }
    }
}