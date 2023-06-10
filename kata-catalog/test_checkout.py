import unittest
from Supermarket_checkout import Checkout

class TestCheckout(unittest.TestCase):

    def setUp(self):
        self.checkout = Checkout()

    def test_scan_invalid_sku(self):
        result = self.checkout.scan('INVALID', 1)
        self.assertEqual(result, 'Invalid item SKU')

    def test_total(self):
        self.checkout.scan('SOUP', 2)
        self.checkout.scan('RAMEN', 3)
        result = self.checkout.total()
        self.assertEqual(result, 'Total: $2.00')

if __name__ == '__main__':
    unittest.main()