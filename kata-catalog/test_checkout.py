import unittest
from Supermarket_checkout import Checkout

class TestCheckout(unittest.TestCase):

    def setUp(self):
        self.checkout = Checkout()

    def test_scan_nothing(self):
        result = self.checkout.scan('')               
        result = self.checkout.total()
        self.assertEqual(result, 'Total: $0.00')

    def test_scan_invalid_sku(self):
        result = self.checkout.scan('INVALID', 1)
        self.assertEqual(result, 'Invalid item SKU')

    def test_scan_one(self):
        self.checkout.scan('RAMEN', 1)
        result = self.checkout.total()
        self.assertEqual(result, 'Total: $0.40')

    def test_multiple(self):
        self.checkout.scan('SOUP', 1)
        self.checkout.scan('RAMEN', 1)
        result = self.checkout.total()
        self.assertEqual(result, 'Total: $1.40')

    def test_multiple_with_all_discounts(self):
        self.checkout.scan('SOUP', 2)
        self.checkout.scan('YOGURT', 3)
        self.checkout.scan('RAMEN', 3)
        self.checkout.scan('ORANGE', 1)
        result = self.checkout.total()
        self.assertEqual(result, 'Total: $8.00')

if __name__ == '__main__':
    unittest.main()
