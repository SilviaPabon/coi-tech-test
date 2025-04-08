using System;
using System.Collections.Generic;

namespace CoiServiceCrud.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public DateTime DateCreation { get; set; }

    public bool Status { get; set; }
}
