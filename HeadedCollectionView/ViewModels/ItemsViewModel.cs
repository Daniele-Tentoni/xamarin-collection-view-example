using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using HeadedCollectionView.Models;

namespace HeadedCollectionView.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private OrderByType selectedOrderByType = 0;

        public OrderByType SelectedOrderByType
        {
            get => this.selectedOrderByType;
            set
            {
                SetProperty(ref this.selectedOrderByType, value);
                Task.Run(async () =>
                {
                    if (IsBusy) return;
                    IsBusy = true;
                    try
                    {
                        await ExecuteLoadItemsCommand();
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                });
            }
        }

        public string[] OrderByTypes { get; } = Enum.GetNames(typeof(OrderByType));

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                await Task.Delay(200);
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
