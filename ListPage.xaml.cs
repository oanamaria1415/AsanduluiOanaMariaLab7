using AsanduluiOanaMariaLab7.Models;
using SQLite;
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
        Shop selectedShop = (ShopPicker.SelectedItem as Shop);
        slist.ShopID = selectedShop.ID;
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

 
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetShopsAsync();
        ShopPicker.ItemsSource = (System.Collections.IList)items;
        ShopPicker.ItemDisplayBinding = new Binding("ShopDetails");
        var shopl = (ShopList)BindingContext;
       
        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
        if (BindingContext is string textList)
        {
            listView.ItemsSource = textList.Split('\n').ToList();
        }

    }

    async void OnDeleteProductButtonClicked(object sender, EventArgs e)
    {
        
        var selectedProduct = listView.SelectedItem as string;

        if (!string.IsNullOrEmpty(selectedProduct))
        {
            
            var products = ((string)BindingContext)?.Split('\n').ToList();

           
            products.Remove(selectedProduct);

           
            BindingContext = string.Join("\n", products);

           
            listView.ItemsSource = products;
        }
        else
        {
           
            await DisplayAlert("Eroare", "Nu ati selectat niciun produs pentru stergere!", "OK");
        }
    }



}
