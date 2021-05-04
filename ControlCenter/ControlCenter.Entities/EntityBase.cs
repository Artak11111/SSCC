using System;
using System.ComponentModel.DataAnnotations;

namespace ControlCenter.Entities
{
    public abstract class EntityBase
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}