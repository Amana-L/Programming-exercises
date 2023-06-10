class Checkout:
    def __init__(self):
        self.prices = {
            'SOUP': {'unit_price': 1.00, 'volume_rule': {'quantity': 2, 'free_quantity': 1}},
            'RAMEN': {'unit_price': 0.40, 'volume_rule': {'quantity': 3, 'total_price': 1.00}},
            'ORANGE': {'unit_price': 2.00},
            'GRAPES': {'unit_price': 4.00, 'lbs': 0.00},       # no price_per_unit needed, scale used
            'YOGURT': {'unit_price': 0.67, 'volume_rule': {'quantity': 3, 'total_price': 2.00}}
        }
        self.cart = {}  

    def scan(self, sku, quantity=1):
        if sku not in self.prices:
            return 'Invalid item SKU'

        if sku == 'GRAPES':
            quantity = float(input('How many lbs?'))

        if sku not in self.cart:
            self.cart[sku] = {'quantity': 0, 'price': 0.00}
        
        unit_price = self.prices[sku].get('unit_price', None)
        volume_rule = self.prices[sku].get('volume_rule', None)

        self.cart[sku]['quantity'] += quantity
        self.cart[sku]['price'] += quantity*unit_price

        display_str = f"{sku} x {self.cart[sku]['quantity']}: "

        if volume_rule is not None:
            total_price = volume_rule.get('total_price', None)
            display_str += f"${unit_price:.2f} each"
            if self.cart[sku]['quantity'] % volume_rule['quantity'] == 0:
                if total_price is not None:
                    self.cart[sku]['price'] = total_price
                    display_str = f"{sku} x {self.cart[sku]['quantity']}: ${total_price:.2f} total"
                else:
                    self.cart[sku]['price'] -= unit_price
                    display_str = f"{sku} x {self.cart[sku]['quantity']}: $0.00 each"

        else:
            display_str += f"${self.cart[sku]['price']:.2f}"

        return display_str

    def total(self):
        total_price = sum(item['price'] for item in self.cart.values())
        return f"Total: ${total_price:.2f}"

