using LaptopsAz.Core.Models.Common;
using Microsoft.AspNetCore.Identity;

namespace LaptopsAz.Core.Models;

public class Review : BaseEntity
{
    public Guid ProductID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Comment { get; set; }
    public Product? Product { get; set; }
}