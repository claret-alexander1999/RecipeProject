using RecipeProject.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RecipeProject.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}