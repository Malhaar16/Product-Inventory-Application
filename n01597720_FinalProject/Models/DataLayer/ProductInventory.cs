using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace n01597720_FinalProject.Models.DataLayer;

[Table("ProductInventory")]
public partial class ProductInventory
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ProductName { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? ProductPrice { get; set; }

    public int? ProductQuantity { get; set; }
}
