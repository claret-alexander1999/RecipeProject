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
    public partial class MainPage : ContentPage
    {
        public ListView listview;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myRecipes.db3");
        public Recipe recipe;

        public MainPage()
        {
            this.Title = "My Recipes";

            StackLayout stacklayout = new StackLayout();
            Button addNew = new Button();
            addNew.Text = "Add a New Recipe +";
            addNew.Clicked += AddNew_Clicked;
            stacklayout.Children.Add(addNew);

            

            var db = new SQLiteConnection(dbPath);

            listview = new ListView();
            listview.ItemsSource = db.Table<Recipe>().OrderBy(X => X.RecipeName).ToList();
            listview.SeparatorColor = Color.White;
            stacklayout.Children.Add(listview);
            listview.ItemSelected += Listview_ItemSelected;

            Button DeleteButton = new Button();
            DeleteButton.Text = "Delete Recipes";
            DeleteButton.Clicked += DeleteButton_Clicked;
            stacklayout.Children.Add(DeleteButton);

            Content = stacklayout;
        }

        private async void Listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            await Navigation.PushAsync(new EditRecipePage());
            recipe = (Recipe)e.SelectedItem;
            EditRecipePage.IdEntry.Text = recipe.ID.ToString();
            EditRecipePage.RecipeNameEntry.Text = recipe.RecipeName;
            EditRecipePage.MadeByNameEntry.Text = recipe.MadeByName;
            EditRecipePage.IngredientsEntry.Text = recipe.Ingredients;
            EditRecipePage.StepsEntry.Text = recipe.Steps;


        }

        private async void AddNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecipePage());
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteItemPage());

        }
    }
}