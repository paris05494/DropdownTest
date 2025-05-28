using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Dropdown.Models;

namespace Dropdown.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        private string _searchText;
        private BaseUnit _selectedItem;
        private int _selectedIndex;

        public List<BaseUnit> AllItems { get; set; }
        public ObservableCollection<BaseUnit> FilteredItems { get; set; }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    FilterItems(SearchText);
                }
            }
        }

        public BaseUnit SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                    SelectedIndex = FilteredItems.IndexOf(_selectedItem);
                }
            }
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainVM()
        {
            AllItems = new List<BaseUnit>
            {
                new BaseUnit { Id = 1, Name = "Apple" },
                new BaseUnit { Id = 2, Name = "Banana" },
                new BaseUnit { Id = 3, Name = "Cherry" },
                new BaseUnit { Id = 4, Name = "Date" }
            };
            FilteredItems = new ObservableCollection<BaseUnit>(AllItems);
        }

        public void FilterItems(string keyword)
        {
            var filtered = AllItems
                .Where(item => item.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();

            FilteredItems.Clear();
            foreach (var item in filtered)
                FilteredItems.Add(item);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

