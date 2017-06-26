using System;

namespace Orchard.Webshop.Models
{
    [Serializable]
    public class ShoppingCartItem
    {
        public int ProductId { get; private set; }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                    throw new IndexOutOfRangeException();

                _quantity = value;
            }
        }

        public ShoppingCartItem()
        {

        }

        public ShoppingCartItem(int productId, int quantity = 1)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
