using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddClotheDetails : ContentPage
    {
        public AddClotheDetails()
        {
            InitializeComponent();
            BindingContext = this;
        }
        int count = 0;
        string countDisplay = "Click me to update the stocks";

        public string CountDisplay
        {
            get => countDisplay;
            set
            {
                if (value == countDisplay)
                    return;
                countDisplay = value;
                OnPropertyChanged();

            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Get All Persons  
            var clotheDetails = await App2.Services.ClotheDetailsService.GetClotheDetails();
            if (clotheDetails != null)
            {
                lstClothDetails.ItemsSource = clotheDetails;
            }
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //count++;
            //CountDisplay = $"Stock details updated {count} time(s) successfully";
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                ClotheDetails clotheDetails = new ClotheDetails()
                {
                    ClotheName = txtName.Text,
                    ClotheGender = txtgender.Text,
                    Quantity = Convert.ToInt32(txtQuantity.Text)
                };
           
                await App2.Services.ClotheDetailsService.AddClotheDetails(clotheDetails);
                txtName.Text = string.Empty;
                txtgender.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                await DisplayAlert("Success", "Clothing Stock added Successfully", "OK");

            }
            var clotheDetail = await App2.Services.ClotheDetailsService.GetClotheDetails();
            if (clotheDetail != null)
            {
                lstClothDetails.ItemsSource = clotheDetail;
            }


        }
        private async void btnDelete_Clicked(object sender, EventArgs e)
        {

            
            var clothId = await App2.Services.ClotheDetailsService.GetClotheDetails(Convert.ToInt32(txtClothId.Text));
            if (clothId != null)
            {
                    await App2.Services.ClotheDetailsService.DeleteClotheDetails(clothId);
                    txtClothId.Text = string.Empty;
                    await DisplayAlert("Success", "Clothing Stock details Deleted", "OK");
                
                var clotheDetail = await App2.Services.ClotheDetailsService.GetClotheDetails();
                if (clotheDetail != null)
                {
                    lstClothDetails.ItemsSource = clotheDetail;
                }
            }
            
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            //count++;
            //CountDisplay = $"Stock details updated {count} time(s) successfully";
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                ClotheDetails clotheDetails = new ClotheDetails()
                {
                    ClotheId = Convert.ToInt32(txtClothId.Text),
                    ClotheName = txtName.Text,
                    ClotheGender = txtgender.Text,
                    Quantity = Convert.ToInt32(txtQuantity.Text)
                };

                await App2.Services.ClotheDetailsService.AddClotheDetails(clotheDetails);
                txtClothId.Text = string.Empty;
                txtName.Text = string.Empty;
                txtgender.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                await DisplayAlert("Success", "Clothing Stock updated Successfully", "OK");

            }
            var clotheDetail = await App2.Services.ClotheDetailsService.GetClotheDetails();
            if (clotheDetail != null)
            {
                lstClothDetails.ItemsSource = clotheDetail;
            }


        }
        

    }
}