using System;
using System.Collections.Generic;

public class Checkout
{
    public string sku;
    public float total;
    public static Dictionary<string, int> cart = new Dictionary<string, int>();

    public void Initialise_cart()
    {
        cart.Add("SOUP", 0);
        cart.Add("RAMEN", 0);
        cart.Add("ORANGE", 0);
        cart.Add("GRAPES", 0);
        cart.Add("YOGURT", 0);
    }

    public string tot()
    {
        return "Total: $" + total;
    }

    public string Scan(string sku)
    {
        int offer = 0;
        float unit_price = 0;
        string display_str = " ";
        switch (sku)
        {
            case "SOUP":
                cart[sku]++;
                offer = cart[sku] % 2;
                switch (offer)
                {
                    case 0:
                        unit_price = 0.00f;
                        break;
                    default:
                        unit_price = 1.00f;
                        break;
                }
                total += unit_price;
                display_str = sku + " x " + cart[sku] + ": $" + unit_price;
                return display_str;

            case "RAMEN":
                cart[sku]++;
                offer = cart[sku] % 3;
                switch (offer)
                {
                    case 0:
                        unit_price = 0.20f;
                        break;
                    default:
                        unit_price = 0.40f;
                        break;
                }
                total += unit_price;
                display_str = sku + " x " + cart[sku] + ": $" + unit_price;
                return display_str;
            
            case "ORANGE":
                cart[sku]++;
                unit_price = 2.00f;
                total += unit_price;
                display_str = sku + " x " + cart[sku] + ": $" + unit_price;
                return display_str;

            case "GRAPES":
                cart[sku]++;
                unit_price = 4.00f;
                total += unit_price;
                display_str = sku + " x " + cart[sku] + ": $" + unit_price;
                return display_str;

            case "YOGURT":
                cart[sku]++;
                offer = cart[sku] % 3;
                switch (offer)
                {
                    case 0:
                        unit_price = 0.66f;
                        break;
                    default:
                        unit_price = 0.67f;
                        break;
                }
                total += unit_price;
                display_str = sku + " x " + cart[sku] + ": $" + unit_price;
                return display_str;

            default:
                return "Invalid item SKU";
        }
    }
}
