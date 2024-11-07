﻿using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace client.Models
{
    public class HotelRoomViewModel
    {
        public HotelRoom HotelRoomVM{ get; set; }
        public IEnumerable<SelectListItem> HotelList { get; set; }

    }
}