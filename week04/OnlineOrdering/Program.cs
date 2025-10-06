using System;

class Program
{
    static void Main(string[] args)
    {
    // --- First Order ---
    Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);

        Product prod1 = new Product("Laptop", "LP1001", 999.99, 1);
        Product prod2 = new Product("Wireless Mouse", "WM2002", 25.50, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        DisplayOrder(order1);

        // --- Second Order ---
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);

        Product prod3 = new Product("Desk Chair", "DC3003", 150.00, 1);
        Product prod4 = new Product("Notebook", "NB4004", 5.25, 5);

        Order order2 = new Order(customer2);
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);

        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalPrice():0.00}");
        Console.WriteLine(new string('-', 50));
    }
}
