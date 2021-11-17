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
    public partial class DeleteItemPage : ContentPage
    {
        public ListView listview;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myRecipes.db3");
        public Recipe recipe;


        public DeleteItemPage()
        {
            this.Title = "Delete Recipes";

            StackLayout stacklayout = new StackLayout();
            var db = new SQLiteConnection(dbPath);

            listview = new ListView();
            listview.ItemsSource = db.Table<Recipe>().OrderBy(X => X.RecipeName).ToList();
            stacklayout.Children.Add(listview);
            listview.ItemSelected += Listview_ItemSelected; 

            Button DeleteButton = new Button();
            DeleteButton.Text = "Delete Recipes";
            DeleteButton.Clicked += DeleteButton_Clicked; 
            stacklayout.Children.Add(DeleteButton);


            Content = stacklayout;


        }

        private void Listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            recipe = (Recipe)e.SelectedItem;
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            db.Table<Recipe>().Delete(X => X.ID == recipe.ID);
            await Navigation.PushAsync(new MainPage());
        }
    }
}