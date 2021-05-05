using System;
using System.ComponentModel.DataAnnotations;

namespace ControlCenter.Entities
{
    public abstract class EntityBase
    {
    }

    public abstract class EntityWithId : EntityBase
    { 
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}