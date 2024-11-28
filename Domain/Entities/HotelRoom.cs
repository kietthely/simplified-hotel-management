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
    public enum RoomStatus
    {
        Available,
        Booked,
        OutOfService,
        HouseKeeping
    }
    public class HotelRoom
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        // Room number within the hotel
        [Key, Column(Order = 1)]
        [Required(ErrorMessage = "Room number is required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only numeric values are allowed for the room number")]
        public  string RoomId { get; set; } 

        public RoomType RoomType { get; set; }

        [Range(1, 30)]
        public int Occupancy { get; set; }
        [MaxLength(50)]
        [Required]
        public  string Name { get; set; }

        [Range(1, 10)]
        public int Beds { get; set; }
        // Base price of the room - This can be changed based on the season/promotion/availability
        [Range(1, 10000)]
        public double BasePrice { get; set; }
        public BedType BedType { get; set; }
        [Range(1, 200)]
        public int RoomSize { get; set; }
        // Room status - Available, Booked, Out of service, Housekeeping
        public RoomStatus? RoomStatus { get; set; }
        // Upload image of the room - Not mapped to the database
        [NotMapped]
        public IFormFile? Image { get; set; }

        // Image URL of the room
        public string? ImageUrl { get; set; }
        // Special details about the room - no-smoking, pet-friendly, etc.
        public string? SpecialDetails { get; set; }
        // Created and updated date of the room
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public virtual Hotel? Hotel { get; set; }
        public ICollection<RoomAmenity>? RoomAmenities { get; set; }
    }
}
