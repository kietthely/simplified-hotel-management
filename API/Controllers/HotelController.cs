﻿using API.Mappers;
using Application.Common.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/hotel")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{hotelId}")]
        public async Task<IActionResult> GetHotelDetails(int hotelId)
        {
            var hotels = await _unitOfWork.Hotel.Get(filter: h => h.Id == hotelId, 
                include: q=> q.Include(hr=> hr.HotelRooms)
                .Include(r => r.Reviews)
                .Include(hig => hig.HotelImageGalleries)
                .Include(ha => ha.HotelAmenities));

            return Ok(hotels);
        }

        [HttpGet]
        public async Task<IActionResult> GetSummarisedHotelsInformation()
        {
            var hotels = await _unitOfWork.Hotel.GetAll(include: q => q.Include(hr => hr.HotelRooms).Include(r=>r.Reviews));
            var hotelDto = hotels.Select(s=>s.ToHotelDto()).ToList();
            return Ok(hotelDto);
        }

        [HttpPost]
        public Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
                return Task.FromResult<IActionResult>(BadRequest(ModelState));

            hotel.CreatedDate = DateTime.UtcNow;
            hotel.LastUpdated = DateTime.UtcNow;

            _unitOfWork.Hotel.Add(hotel);
            _unitOfWork.Save();
            // returns 201 if successfully added
            return Task.FromResult<IActionResult>(CreatedAtAction(nameof(GetHotelDetails), new { hotelId = hotel.Id }, hotel));
        }

        [HttpPut("{hotelId}")]
        public async Task<IActionResult> UpdateHotel(int hotelId, [FromBody] Hotel updatedHotel)
        {
            var hotelToBeUpdated = await _unitOfWork.Hotel.Get(filter: h => h.Id == hotelId);
            if (hotelToBeUpdated == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            hotelToBeUpdated.Name = updatedHotel.Name;
            hotelToBeUpdated.Address = updatedHotel.Address;
            hotelToBeUpdated.Description = updatedHotel.Description;
            hotelToBeUpdated.ImageUrl = updatedHotel.ImageUrl;
            hotelToBeUpdated.Size = updatedHotel.Size;
            hotelToBeUpdated.LastUpdated = DateTime.UtcNow;

            _unitOfWork.Hotel.Update(hotelToBeUpdated);
            _unitOfWork.Save();
            return Ok(hotelToBeUpdated);
        }

        [HttpDelete("{hotelId}")]
        public async Task<IActionResult> DeleteHotel(int hotelId)
        {
            var hotel = await _unitOfWork.Hotel.Get(filter: h => h.Id == hotelId);
            if (hotel == null)
                return NotFound();

            _unitOfWork.Hotel.Remove(hotel);
            _unitOfWork.Save();
            return Ok();
        }

    }
}
