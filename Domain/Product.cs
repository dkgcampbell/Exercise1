using System;

namespace Domain
{
    public class Product
    {
        public Product(String code, String description, Decimal price, ProductCategory? category, Boolean eligibleForOfferVoucher) {
            Code = code;
            Description = description;
            Price = price;
            Category = category;
            EligibleForOfferVoucher = eligibleForOfferVoucher;
        }

        public String Code {
            get; private set;
        }

        public String Description {
            get; private set;
        }

        public Decimal Price {
            get; private set;
        }

        public ProductCategory? Category {
            get; private set;
        }

        public Boolean EligibleForOfferVoucher {
            get; private set;
        }
    }

    public enum ProductCategory { HeadGear };
}
