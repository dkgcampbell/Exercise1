using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class GiftVoucherList
    {
        private IDictionary<String, GiftVoucher> giftVoucherList = new Dictionary<String, GiftVoucher> ();
        
        public GiftVoucherList () {
            giftVoucherList.Add("XXX-XXX", new GiftVoucher("XXX-XXX", "£5", 5m, null));
            giftVoucherList.Add("YYY-YYY", new GiftVoucher("YYY-YYY", "£5", 5m, ProductCategory.HeadGear));
        }

        public GiftVoucher GetGiftVoucher(String code) {
            return giftVoucherList[code];
        }
    }
}
