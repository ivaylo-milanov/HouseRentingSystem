namespace HouseRentingSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Agent;

    [Comment("agent table")]
    public class Agent
    {
        public Agent()
        {
            this.OwnedHouses = new HashSet<House>();
            this.Id = Guid.NewGuid();
        }

        [Comment("agent id")]
        [Key]
        public Guid Id { get; set; }

        [Comment("agent phone number")]
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Comment("agent  user id")]
        [Required]
        public Guid UserId { get; set; }

        [Comment("agent user")]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<House> OwnedHouses { get; set; }
    }
}