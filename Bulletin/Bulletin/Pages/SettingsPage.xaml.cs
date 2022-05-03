using Bulletin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bulletin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Db.GetPeopleAsync();
        }

        async void AddButton(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(id.Text) && !string.IsNullOrWhiteSpace(fNameEntry.Text) 
                && !string.IsNullOrWhiteSpace(lNameEntry.Text) && !string.IsNullOrWhiteSpace(HrsWorked.Text))
            {
                await App.Db.SavePersonAsync(new Person
                {
                    Id = int.Parse(id.Text),
                    FName = fNameEntry.Text,
                    LName = lNameEntry.Text,
                    HrsWorked = int.Parse(HrsWorked.Text),
                    IsIn = isIn.IsChecked
                });

                id.Text = fNameEntry.Text = lNameEntry.Text = HrsWorked.Text = string.Empty;
                isIn.IsChecked = false;
                collectionView.ItemsSource = await App.Db.GetPeopleAsync();
            }
        }
        Person lastSelected;
        void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            lastSelected = e.CurrentSelection[0] as Person;
            id.Text = lastSelected.Id.ToString();
            fNameEntry.Text = lastSelected.FName;
            lNameEntry.Text = lastSelected.LName;
            HrsWorked.Text = lastSelected.HrsWorked.ToString();
            isIn.IsChecked = lastSelected.IsIn;
        }
        async void UpdateButton(object sender, EventArgs e)
        {
            if (lastSelected != null)
            {
                lastSelected.Id = int.Parse(id.Text);
                lastSelected.FName = fNameEntry.Text;
                lastSelected.LName = lNameEntry.Text;
                lastSelected.HrsWorked = int.Parse(HrsWorked.Text);
                lastSelected.IsIn = isIn.IsChecked;
                await App.Db.UpdatePersonAsync(lastSelected);
                collectionView.ItemsSource = await App.Db.GetPeopleAsync();
            }
        }
        async void DeleteButton(object sender, EventArgs e)
        {

            await App.Db.DeletePersonAsync(lastSelected);

            collectionView.ItemsSource = await App.Db.GetPeopleAsync();
            id.Text = fNameEntry.Text = lNameEntry.Text = HrsWorked.Text = string.Empty;
            isIn.IsChecked = false;
        }
        async void EmpWorkingButton(object sender, EventArgs e)
        {
            collectionView.ItemsSource = await App.Db.IsInAsync();
            id.Text = fNameEntry.Text = lNameEntry.Text = HrsWorked.Text = string.Empty;
            isIn.IsChecked = false;
        }
        async void EmpNotWorkingButton(object sender, EventArgs e)
        {
            collectionView.ItemsSource = await App.Db.NotInAsync();
            id.Text = fNameEntry.Text = lNameEntry.Text = HrsWorked.Text = string.Empty;
            isIn.IsChecked = false;
        }
    }
}