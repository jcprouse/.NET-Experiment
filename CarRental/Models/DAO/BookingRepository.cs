using System.Collections.Generic;
using CarRental.Models.Entities;

namespace CarRental.Models.DAO
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> _cars = new List<Booking>();
        private List<Booking> _vans = new List<Booking>();

        public List<Booking> GetCarBookings()
        {
            return _cars;
        }

        public void AddCarBooking(Booking b)
        {
            this._cars.Add(b);
        }

        public List<Booking> GetVanBookings()
        {
            return _vans;
        }

        public void AddVanBooking(Booking b)
        {
            this._vans.Add(b);
        }
    }
}