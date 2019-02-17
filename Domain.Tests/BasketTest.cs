using System;
using Xunit;
using Domain;

namespace Domain.Tests
{
  public class BasketTest
  {
    [Fact]
    public void WhenNewBasketIsEmpty()
    {
      var basket = new Basket();

      Assert.Equal(0, basket.NumberOfLineItems);
    }

    [Fact]
    public void When1ItemAddedBasketContains1Item()
    {
      var basket = new Basket();
      basket.AddProduct("hat1050", 1);

      Assert.Equal(1, basket.NumberOfLineItems);
    }

    [Fact]
    public void WhenAnItemAddedBasketContainsThatItem()
    {
      var basket = new Basket();
      basket.AddProduct("hat1050", 1);

      Assert.Equal(1, basket.Items["hat1050"].Quantity);
    }

    [Fact]
    public void WhenNewItemAddedBasketContainsOldAndNewItem()
    {
      var basket = new Basket();
      basket.AddProduct("hat1050", 1);
      basket.AddProduct("jumper2600", 1);

      Assert.Equal(1, basket.Items["hat1050"].Quantity);
      Assert.Equal(1, basket.Items["jumper2600"].Quantity);
    }

    [Fact]
    public void WhenEmptyBasketTotalPriceIsZero()
    {
      var basket = new Basket();

      Assert.Equal(0m, basket.TotalPrice);
    }

    [Fact]
    public void WhenItemAddedBasketTotalPriceIsItemPrice()
    {
      var basket = new Basket();
      basket.AddProduct("hat1050", 1);

      Assert.Equal(10.50m, basket.TotalPrice);
    }

    [Fact]
    public void WhenItemsAddedBasketTotalPriceIsItemsPrice()
    {
      var basket = new Basket();
      basket.AddProduct("hat1050", 1);
      basket.AddProduct("jumper2600", 1);

      Assert.Equal(36.50m, basket.TotalPrice);
    }

    [Fact]
    public void WhenGiftVoucherAddedBasketTotalPriceIsReduced()
    {
        var basket = new Basket();
        basket.AddProduct("hat1050", 1);
        basket.AddGiftVoucher("XXX-XXX", 1);

        Assert.Equal(5.5m, basket.TotalPrice);
    }

    [Fact]
    public void WhenMultipleGiftVoucherAddedBasketTotalPriceIsReduced()
    {
        var basket = new Basket();
        basket.AddProduct("hat1050", 1);
        basket.AddGiftVoucher("XXX-XXX", 2);

        Assert.Equal(0.5m, basket.TotalPrice);
    }

    [Fact]
    public void WhenTotalPriceOfferVoucherAddedBasketTotalPriceIsReduced()
    {
        var basket = new Basket();
        basket.AddProduct("hat2500", 1);
        basket.AddProduct("jumper2600", 1);
        basket.AddOfferVoucher("YYY-YYY");

        Assert.Equal(46m, basket.TotalPrice);
    }

    [Fact]
    public void WhenOfferVoucherAddedOnlyOneAdded()
    {
        var basket = new Basket();
        basket.AddProduct("hat2500", 1);
        basket.AddProduct("jumper2600", 2);
        basket.AddOfferVoucher("YYY-YYY");
        basket.AddOfferVoucher("YYY-YYY");

        Assert.Equal(72m, basket.TotalPrice);
    }
  }
}
