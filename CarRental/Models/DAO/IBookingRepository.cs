using System.Collections.Generic;
using CarRental.Models.Entities;

namespace CarRental.Models.DAO
{
    public interface IBookingRepository
    {
        void AddCarBooking(Booking b);
        void AddVanBooking(Booking b);
        List<Booking> GetCarBookings();
        List<Booking> GetVanBookings();
    }
}