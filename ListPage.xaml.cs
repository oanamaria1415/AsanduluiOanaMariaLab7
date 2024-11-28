using AsanduluiOanaMariaLab7.Models;

namespace AsanduluiOanaMariaLab7;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }

    // Event handler for saving a shopping list
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow; // Set the current date and time
        await App.Database.SaveShopListAsync(slist); // Save to database
        await Navigation.PopAsync(); // Navigate back to the previous page
    }

    // Event handler for deleting a shopping list
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(slist); // Delete from database
        await Navigation.PopAsync(); // Navigate back to the previous page
    }
}
