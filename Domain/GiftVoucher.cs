using System;

namespace Domain
{
    public class GiftVoucher
    {
        public GiftVoucher(String code, String description, Decimal price, ProductCategory? category) {
            Code = code;
            Description = description;
            Value = price;
            Category = category;
        }

        public String Code {
            get; private set;
        }

        public String Description {
            get; private set;
        }

        public Decimal Value {
            get; private set;
        }
        
        public ProductCategory? Category {
            get; private set;
        }
    }
}
