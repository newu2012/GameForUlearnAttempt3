using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class InventoryItem : INotifyPropertyChanged
    {
        private Item _details;
        private int _quantity;

        public Item Details
        {
            get => _details;
            set
            {
                _details = value; 
                OnPropertyChanged("Details");
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value; 
                OnPropertyChanged("Quantity");
                OnPropertyChanged("Description");
            }
        }
        
        public int ItemID => Details.ID;
        public int Price => Details.Price;

        public string Description => Quantity > 1 ? Details.NamePlural : Details.Name;

        public InventoryItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}