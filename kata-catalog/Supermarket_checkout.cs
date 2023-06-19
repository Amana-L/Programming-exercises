using System;
using System.Collections.Generic;

public class Checkout
{
    public string sku;
    public float total;
    public static Dictionary<string, int> cart = new Dictionary<string, int>();

    public static Dictionary<string, float[]> inventory = new Dictionary<string, float[]>();
    // The inventory is  (sku ,  (price_after_offer, unit_price) and just (sku, (unit_price)) where there is no offer

    public void set_up_inventory()
    {
        inventory["SOUP"] = new float[]{ 0.00f, 1.00f };
        inventory["RAMEN"] = new float[]{ 0.20f, 0.40f };
        inventory["ORANGE"] = new float[]{ 2.00f, 2.00f };      // no offer so
        inventory["GRAPES"] = new float[]{ 4.00f, 4.00f };          //  both prices are same 
        inventory["YOGURT"] = new float[]{ 0.66f, 0.67f };
    }



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

    public string place_in_cart(string sku, int offer_modulus)
    {
        int offer = 0;
        float unit_price = 0;
        string display_str = " ";
        cart[sku]++;
        offer = cart[sku] % offer_modulus;
        unit_price = inventory[sku][Math.Sign(offer)];

        total += unit_price;
        display_str = sku + " x " + cart[sku] + ": $" + unit_price;
        return display_str;
    }

    public string Scan(string sku)
    {
        switch (sku)
        {
            case "SOUP":
                return place_in_cart("SOUP", 2);

            case "RAMEN":
                return place_in_cart("RAMEN", 3);

            case "ORANGE":
                return place_in_cart("ORANGE", 2);      
    
            case "GRAPES":
                return place_in_cart("GRAPES", 2);
            
            case "YOGURT":
                return place_in_cart("YOGURT", 3);

            default:
                return "Invalid item SKU";
        }
    }
}

