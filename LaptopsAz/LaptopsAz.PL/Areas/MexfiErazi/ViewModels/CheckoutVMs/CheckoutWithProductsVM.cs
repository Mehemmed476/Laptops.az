namespace LaptopsAz.PL.Areas.MexfiErazi.ViewModels.CheckoutVMs;

public class CheckoutWithProductsVM
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
    public List<string> ProductNames { get; set; }
}