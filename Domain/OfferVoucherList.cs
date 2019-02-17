using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class OfferVoucherList
    {
        private IDictionary<String, OfferVoucher> offerVoucherList = new Dictionary<String, OfferVoucher> ();
        
        public OfferVoucherList () {
            offerVoucherList.Add("YYY-YYY", new OfferVoucher("YYY-YYY", "£5.00 off baskets over £50.00", 5m, 50m));
        }

        public OfferVoucher GetOfferVoucher(String code) {
            return offerVoucherList[code];
        }
    }
}
