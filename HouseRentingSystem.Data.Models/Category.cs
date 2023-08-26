namespace HouseRentingSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Category;

    [Comment("category table")]
    public class Category
    {
        public Category()
        {
            this.Houses = new HashSet<House>();
        }

        [Comment("category id")]
        [Key]
        public int Id { get; set; }

        [Comment("category name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<House> Houses { get; set; }
    }
}
