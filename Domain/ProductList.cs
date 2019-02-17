using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class ProductList
    {
        private IDictionary<String, Product> productList = new Dictionary<String, Product> ();
        
        public ProductList () {
            productList.Add("gift3000", new Product("gift3000", "£30 Gift Voucher", 30m, null, false));
            productList.Add("hat1050", new Product("hat1050", "Hat", 10.5m, null, true));
            productList.Add("hat2500", new Product("hat2500", "Hat", 25m, null, true));
            productList.Add("jumper2600", new Product("jumper2600", "Jumper", 26m, null, true));
            productList.Add("jumper5465", new Product("jumper5465", "Jumper", 54.65m, null, true));
            productList.Add("headlight350", new Product("headlight350", "Head Light", 3.5m, ProductCategory.HeadGear, true));
        }

        public Product GetProduct(String code) {
            return productList[code];
        }
    }
}
