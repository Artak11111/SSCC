using System;
using System.ComponentModel.DataAnnotations;

namespace ControlCenter.Entities.Models
{
    public abstract class EntityBase
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}