using System;

namespace Domain
{
    public class LineItem<T>
    {
        public LineItem(T stockItem, int quantity) {
            this.Product = stockItem;
            Quantity = quantity;
        }

        public T Product {
            get; private set;
        }

        public int Quantity {
            get; private set;
        }
    }
}
