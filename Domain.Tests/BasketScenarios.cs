using System;
using Xunit;
using Domain;

namespace Domain.Tests
{
  public class BasketScenarios
  {
    [Fact]
    public void Basket1()
    {
      var basket = new Basket();
      basket.AddProduct("hat1050", 1);
      basket.AddProduct("jumper5465", 1);
      basket.AddGiftVoucher("XXX-XXX", 1);

      Assert.Equal(60.15m, basket.TotalPrice);
    }

    [Fact]
    public void Basket2()
    {
      var basket = new Basket();
      basket.AddProduct("hat2500", 1);
      basket.AddProduct("jumper2600", 1);
      basket.AddGiftVoucher("YYY-YYY", 1);

      Assert.Equal(51.00m, basket.TotalPrice);
      Assert.Equal("There are no products in your basket applicable to voucher Voucher YYY-YYY .", basket.Message);
    }

    [Fact]
    public void Basket3()
    {
      var basket = new Basket();
      basket.AddProduct("hat2500", 1);
      basket.AddProduct("jumper2600", 1);
      basket.AddProduct("headlight350", 1);
      basket.AddGiftVoucher("YYY-YYY", 1);

      Assert.Equal(51.00m, basket.TotalPrice);
    }

    [Fact]
    public void Basket4()
    {
      var basket = new Basket();
      basket.AddProduct("hat2500", 1);
      basket.AddProduct("jumper2600", 1);
      basket.AddGiftVoucher("XXX-XXX", 1);
      basket.AddOfferVoucher("YYY-YYY");

      Assert.Equal(41m, basket.TotalPrice);
    }

    [Fact]
    public void Basket5()
    {
      var basket = new Basket();
      basket.AddProduct("hat2500", 1);
      basket.AddProduct("gift3000", 1);
      basket.AddOfferVoucher("YYY-YYY");

      Assert.Equal(55m, basket.TotalPrice);
      Assert.Equal("You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.", basket.Message);
    }
  }
}
