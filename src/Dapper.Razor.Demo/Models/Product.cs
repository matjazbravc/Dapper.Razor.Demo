using Dapper.Razor.Demo.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dapper.Razor.Demo.Models
{
    /// <summary>
    /// Product model/entity
    /// </summary>
    [Serializable]
    public class Product
    {
        [Key]
        [Ignore] // ***Ignore Id property when inserting/updating entity because is AUTOINCREMENT
        [Display(Name = "Product Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [StringLength(128, ErrorMessage = "Name should be 1 to 128 char in lenght")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Model")]
        [StringLength(64, ErrorMessage = "Name should be 1 to 64 char in lenght")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Obsolete")]
        public bool Obsolete { get; set; } = false;

        [Display(Name = "Modified")]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
