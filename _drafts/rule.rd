model: Order collection

properties:
    Id: integer
    Price: decimal
    
execution:
    - Order.Price = 0.0 "Price can not be zero"
    - Order.Id = -1 "Invalid order id"
    