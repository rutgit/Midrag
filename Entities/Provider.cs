using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Entities
{
    public class Provider
    {
        [Key, NotNull]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public bool IsActive { get; set; }
        public bool IsReservist { get; set; }
        public string? PhotoURL { get; set; }
        public string? NumOfRanks { get; set; }

    }
}
