using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideosAccessPoint.Domain.Entities
{
    public abstract class EntityBase
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Display(Name ="Назва")]
        public virtual string Title { get; set; }
        [Display(Name = "Опис")]
        public virtual string Description { get; set; }

    }
}
