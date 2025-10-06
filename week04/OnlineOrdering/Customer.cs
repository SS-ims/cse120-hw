public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name => name;

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetAddressString()
    {
        return address.GetFullAddress();
    }
}