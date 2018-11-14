using System;
using System.Linq;
using CarRental.Models.Entities;
using CarRental.Models.DAO;

namespace CarRental.Models.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        /* SPEC
         * Book a car from a [start] date for a given number of days [duration].
         * 
         * A specific car can only be booked if it isn't already booked out. After each car booking, 
         * an extra day is required for valeting and can't be booked out on this day.
         * 
         * The [TotalCost] of a car booking is the cars [DailyCost] multiplied by the number of days. The
         * agreed discount is then applied onto final value.
         * 
         * If the booking can't be made, raise an exception highlighting the specific error.
         */
        public Booking MakeCarBooking(Car car, DateTime startDate, int duration, float discount, string name)
        {

            DateTime completedDate = startDate.AddDays(duration + 1);

            var booking = new Booking() {
                CarId = car.Id,
                RentalDate = startDate,
                ReturnDate = startDate.AddDays(duration),
                CompletedDate = completedDate,
                TotalCost = car.DailyCost * duration,
                Name = name
            };

            var bookings = _bookingRepository.GetCarBookings();

            if (bookings.Any(b =>
                (b.RentalDate >= startDate && b.RentalDate <= completedDate)
                ||
                (b.CompletedDate >= startDate && b.CompletedDate <= completedDate)
                ||
                (b.RentalDate <= startDate && b.CompletedDate >= completedDate)
            ))
                throw new InvalidOperationException("Conflict with existing appointment");

            _bookingRepository.AddCarBooking(booking);

            return booking;
        }

        /* SPEC
         * Book a van from a [start] date for a given number of days [duration].
         * 
         * A specific van can only be booked if it isn't already booked out. No valet is required for a van.
         * 
         * The daily rate for a van after 5 days is subject to a further 25% discount.
         * The [TotalCost] of a van booking is the vans [DailyCost] multiplied by the number of days. The
         * agreed discount is then applied onto final value.
         * 
         * If the booking can't be made, raise an exception highlighting the specific error.
         */
        public Booking MakeVanBooking(Van van, DateTime start, int duration, float discount, string name)
        {
            // todo:: make booking for van

            return null;
        }
    }
}
