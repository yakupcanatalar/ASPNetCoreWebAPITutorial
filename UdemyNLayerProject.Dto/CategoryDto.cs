﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UdemyNLayerProject.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
