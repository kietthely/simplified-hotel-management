﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public enum RoomType
    {
        Standard,
        Deluxe,
        Suite,
        Superior,
        Executive
    }
    public enum BedType {
        Single,
        Double,
        Queen,
        King,
        Twin
    }
    public class HotelRoom
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }


        [Key, Column(Order = 1)]
        [Required(ErrorMessage = "Room number is required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only numeric values are allowed for the room number")]
        public  string RoomId { get; set; } // Room number within the hotel

        public RoomType RoomType { get; set; }

        [Range(1, 8)]
        public int Occupancy { get; set; }
        [MaxLength(50)]
        [Required]
        public  string Name { get; set; }

        [Range(1, 5)]
        public int Beds { get; set; }

        public BedType BedType { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }

        public string? SpecialDetails { get; set; }


        public virtual Hotel? Hotel { get; set; }



    }
}
