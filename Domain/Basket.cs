using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
  public class Basket
  {
    private Dictionary<String, LineItem<Product>> items = new Dictionary<string, LineItem<Product>>();
    private Dictionary<String, LineItem<GiftVoucher>> giftVouchers = new Dictionary<string, LineItem<GiftVoucher>>();
    private OfferVoucher offerVoucher = null;
    private String message = String.Empty;

    public Decimal TotalPrice
    {
      get
      {
        message = String.Empty;
        Decimal totalPrice = 0m;
        Decimal totalPriceForOfferVoucher = 0m;
        foreach (var lineItem in items.Values)
        {
          totalPrice += (lineItem.Product.Price * lineItem.Quantity);
          if (lineItem.Product.EligibleForOfferVoucher)
          {
            totalPriceForOfferVoucher += (lineItem.Product.Price * lineItem.Quantity);
          }
        }
        if (offerVoucher != null)
        {
          if (totalPriceForOfferVoucher > offerVoucher.BasketPrice)
          {
            totalPrice -= offerVoucher.Value;
          }
          else
          {
            message = String.Format("You have not reached the spend threshold for voucher {0}. Spend another £{1:0.00} to receive £{2:0.00} discount from your basket total.", offerVoucher.Code, offerVoucher.BasketPrice + 0.01m - totalPriceForOfferVoucher, offerVoucher.Value);
          }
        }
        foreach (var lineItem in giftVouchers.Values)
        {
          if (lineItem.Product.Category == null)
          {
            totalPrice -= (lineItem.Product.Value * lineItem.Quantity);
          } 
          else if (items.Values.ToList().Exists(x => x.Product.Category == lineItem.Product.Category))
          {
            Decimal priceOfProductsInCategory = items.Values.ToList().Where(x => x.Product.Category == lineItem.Product.Category).Sum(y => y.Product.Price * y.Quantity);
            totalPrice -= Math.Min(lineItem.Product.Value * lineItem.Quantity, priceOfProductsInCategory);
          }
          else
          {
              message = String.Format("There are no products in your basket applicable to voucher Voucher {0} .", lineItem.Product.Code);
          }
        }
        return totalPrice;
      }
    }

    public String Message
    {
      get { return message; }
    }

    public int NumberOfLineItems
    {
      get { return items.Count; }
    }

    public IDictionary<String, LineItem<Product>> Items
    {
      get { return items; }
    }

    public void AddProduct(String itemKey, int quantity)
    {
      Product product = new ProductList().GetProduct(itemKey);
      LineItem<Product> lineItem = new LineItem<Product>(product, quantity);
      items.Add(itemKey, lineItem);
      return;
    }

    public void AddGiftVoucher(String voucherKey, int quantity)
    {
      GiftVoucher giftVoucher = new GiftVoucherList().GetGiftVoucher(voucherKey);
      LineItem<GiftVoucher> lineItem = new LineItem<GiftVoucher>(giftVoucher, quantity);
      giftVouchers.Add(voucherKey, lineItem);
      return;
    }

    public void AddOfferVoucher(String voucherKey)
    {
      if (offerVoucher == null)
      {
        offerVoucher = new OfferVoucherList().GetOfferVoucher(voucherKey);
      }
      return;
    }

  }
}
