﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateInfo.API.Models
{
    public class PointOfInterestForUpdationDto
    {

        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
