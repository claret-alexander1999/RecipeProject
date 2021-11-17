using RecipeProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditRecipePage : ContentPage
    {
        public static Entry IdEntry;
        public static Entry RecipeNameEntry;
        public static Entry MadeByNameEntry;
        public static Entry IngredientsEntry;
        public static Entry StepsEntry;
        public static Button UpdateButton;
        private Button DeleteButton;

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myRecipes.db3");
        public EditRecipePage()
        {
            this.Title = "Edit Recipe";


            StackLayout stacklayout = new StackLayout();

            IdEntry = new Entry();
            IdEntry.Placeholder = "ID";
            IdEntry.IsVisible = false;
            stacklayout.Children.Add(IdEntry);


            Label Name = new Label();
            Name.Text = "Recipe Name";
            RecipeNameEntry = new Entry();
            RecipeNameEntry.Keyboard = Keyboard.Text;
            RecipeNameEntry.Placeholder = "Recipe Name";
            stacklayout.Children.Add(Name);
            stacklayout.Children.Add(RecipeNameEntry);

            Label MDName = new Label();
            MDName.Text = "Made by";
            MadeByNameEntry = new Entry();
            MadeByNameEntry.Keyboard = Keyboard.Text;
            MadeByNameEntry.Placeholder = "Made by Name";
            stacklayout.Children.Add(MDName);
            stacklayout.Children.Add(MadeByNameEntry);

            Label IngredientsText = new Label();
            IngredientsText.Text = "List of Ingredients";
            IngredientsEntry = new Entry();
            IngredientsEntry.Keyboard = Keyboard.Text;
            IngredientsEntry.Placeholder = "Ingredients";
            stacklayout.Children.Add(IngredientsText);
            stacklayout.Children.Add(IngredientsEntry);

            Label StepsText = new Label();
            StepsText.Text = "Steps to follow";
            StepsEntry = new Entry();
            StepsEntry.Keyboard = Keyboard.Text;
            StepsEntry.Placeholder = "Mention the Steps";
            stacklayout.Children.Add(StepsText);
            stacklayout.Children.Add(StepsEntry);

            UpdateButton = new Button();
            UpdateButton.Text = "Update";
            UpdateButton.Clicked += UpdateButton_Clicked;
            stacklayout.Children.Add(UpdateButton);

            

            Content = stacklayout;

        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            Recipe recipe = new Recipe()
            {
                ID = Convert.ToInt32(IdEntry.Text),
                RecipeName = RecipeNameEntry.Text,
                MadeByName = MadeByNameEntry.Text,
                Ingredients = IngredientsEntry.Text,
                Steps=StepsEntry.Text
            };

            db.Update(recipe);
            await Navigation.PushAsync(new MainPage());
        }
    }
}