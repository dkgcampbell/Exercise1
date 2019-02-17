using System;

namespace Domain
{
    public class OfferVoucher
    {
        public OfferVoucher(String code, String description, Decimal value, Decimal basketPrice) {
            Code = code;
            Description = description;
            Value = value;
            BasketPrice = basketPrice;
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

        public Decimal BasketPrice {
            get; private set;
        }
    }
}
