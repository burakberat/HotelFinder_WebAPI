﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelFinderEntities
{
    public class Hotel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(70)]
        [Required]
        public string Name { get; set; }
        [StringLength(70)]
        [Required]
        public string City { get; set; }
    }
}