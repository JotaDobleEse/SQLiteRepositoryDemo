using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SQLiteRepositoryDemo.Helpers;
using SQLiteRepositoryDemo.Model;
using SQLiteRepositoryDemo.Services.SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SQLiteRepositoryDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly DemoContext context;
        private bool _all = true;

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private Item _selectedItem;
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public MainPageViewModel(INavigationService navigationService, DemoContext context) : base(navigationService)
        {
            Title = "Items";
            this.context = context;
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            var itemsList = await context.Items.GetAllAsync();
            if (itemsList.Count == 0)
            {
                await InitializeDb.Initialize(context);
                itemsList = await context.Items.GetAllAsync();
            }
            Items = new ObservableCollection<Item>(itemsList);
        }

        private DelegateCommand<string> _filterCommand;
        public DelegateCommand<string> FilterCommand =>
            _filterCommand ?? (_filterCommand = new DelegateCommand<string>(ExecuteFilterCommand, CanExecuteFilterCommand));

        async void ExecuteFilterCommand(string allString)
        {
            var all = bool.Parse(allString);
            if (all)
            {
                var itemsList = await context.Items.GetAllAsync();
                Items = new ObservableCollection<Item>(itemsList);
            }
            else
            {
                var itemsList = await context.Items.GetCheckedItems();
                Items = new ObservableCollection<Item>(itemsList);
            }
            _all = all;
            FilterCommand.RaiseCanExecuteChanged();                
        }

        bool CanExecuteFilterCommand(string allString)
        {
            var all = bool.Parse(allString);
            return all != _all;
        }
    }
}
