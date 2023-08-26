namespace HouseRentingSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.House;

    [Comment("house table")]
    public class House
    {
        public House()
        {
            this.Id = Guid.NewGuid();
        }

        [Comment("house id")]
        [Key]
        public Guid Id { get; set; }

        [Comment("house title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("house address")]
        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Comment("house description")]
        [Required]
        [MaxLength(DescriptionsMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("house image url")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("house price per month")]
        [Required]
        public decimal PricePerMonth { get; set; }

        [Comment("house category id")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("house category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Comment("house agent id")]
        [Required]
        public Guid AgentId { get; set; }

        [Comment("house agent")]
        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;

        [Comment("house renter id")]
        public Guid? RenterId { get; set; }

        [Comment("house renter")]
        [ForeignKey(nameof(RenterId))]
        public ApplicationUser? Renter { get; set; }
    }
}