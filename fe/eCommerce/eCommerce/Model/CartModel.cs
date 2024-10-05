using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace eCommerce.Model
{
    public class CartModel : INotifyPropertyChanged
    {
        public long itemId { get; set; }
        public string itemImg { get; set; }
        public string itemName { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;  
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Command DecreseTapCommand
        {
            get
            {
                return new Command(val =>
                {
                    var modelObj = (CartModel) val;
                    if (modelObj.quantity >= 2)
                    {
                        quantity = (modelObj.quantity - 1);
                        OnPropertyChanged("quantity");
                    }
                   

                });
            }
        }

        public Command IncreaseTapCommand
        {
            get
            {
                return new Command(val =>
                {
                    quantity = (Int16.Parse(val.ToString()) + 1);
                    OnPropertyChanged("quantity");
                });
            }
        }
    }
}
