using Xunit;

public class TestCheckout
{
    private Checkout checkout;

    public TestCheckout()
    {
        checkout = new Checkout();
    }

    [Fact]
    public void TestScanNothing()
    {
        checkout.Scan("");
        string result = checkout.tot();
        Assert.Equal("Total: $0.00", result);
    }

    [Fact]
    public void TestScanInvalidSku()
    {
        string result = checkout.Scan("INV");
        Assert.Equal("Invalid item SKU", result);
    }

    [Fact]
    public void TestScanOne()
    {
        checkout.Scan("RAMEN");
        string result = checkout.tot();
        Assert.Equal("Total: $0.40", result);
    }

    [Fact]
    public void TestMultiple()
    {
        checkout.Scan("SOUP");
        checkout.Scan("RAMEN");
        string result = checkout.tot();
        Assert.Equal("Total: $1.40", result);
    }

    [Fact]
    public void TestMultipleWithAllDiscounts()
    {
        checkout.Scan("SOUP");
        checkout.Scan("RAMEN");
        checkout.Scan("SOUP");
        checkout.Scan("YOGURT");
        checkout.Scan("RAMEN");
        checkout.Scan("YOGURT");
        checkout.Scan("RAMEN");
        checkout.Scan("YOGURT");
        checkout.Scan("ORANGE");
        string result = checkout.tot();
        Assert.Equal("Total: $6.00", result);
    }
}
