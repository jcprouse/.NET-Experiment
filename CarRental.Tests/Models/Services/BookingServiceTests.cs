using System;
using System.Collections.Generic;
using CarRental.Models.DAO;
using CarRental.Models.Entities;
using CarRental.Models.Services;
using Moq;
using NUnit.Framework;

namespace CarRental.Tests.Controllers
{
    [TestFixture]
    public class BookingServiceTests
    {
        static readonly int mockCarId = 1;
        readonly DateTime mockStartDate = DateTime.Parse("2018-11-15");

        readonly List<Booking> bookings = new List<Booking> {
            new Booking { CarId=mockCarId, RentalDate=DateTime.Parse("2018-11-08"), CompletedDate=DateTime.Parse("2018-11-11") }
        };

        Mock<IBookingRepository> mockBookingRepository;
        BookingService bookingService;

        [SetUp]
        public void Init()
        {
            mockBookingRepository = new Mock<IBookingRepository>();
            mockBookingRepository.Setup(m => m.GetCarBookings()).Returns(bookings);
            bookingService = new BookingService(mockBookingRepository.Object);
        }

        [Test]
        public void when_making_a_car_booking_it_should_calculate_the_daily_rate()
        {
            var car = new Car { DailyCost = 100 };

            var booking = bookingService.MakeCarBooking(car, mockStartDate, 1, 0, "Joe Bloggs");
            Assert.AreEqual(100, booking.TotalCost);
        }

        [Test]
        public void the_return_date_is_calculated_correctly()
        {
            var car = new Car { DailyCost = 100 };

            var booking = bookingService.MakeCarBooking(car, mockStartDate, 1, 0, "Joe Bloggs");
            Assert.AreEqual(mockStartDate.AddDays(1), booking.ReturnDate);
        }

        [Test]
        public void valid_bookings_are_saved()
        {
            var car = new Car { DailyCost = 100 };

            Booking booking = bookingService.MakeCarBooking(car, mockStartDate, 1, 0, "Joe Bloggs");
            mockBookingRepository.Verify(m => m.AddCarBooking(booking));
        }

        //Start Date
        [TestCase("2018-11-07", 0)]
        [TestCase("2018-11-07", 1)]
        [TestCase("2018-11-08", 0)]
        //Completed Date
        [TestCase("2018-11-10", 0)]
        [TestCase("2018-11-10", 1)]
        [TestCase("2018-11-11", 0)]
        //All inside
        [TestCase("2018-11-09", 0)]
        //All outside
        [TestCase("2018-11-07", 5)]

        public void exception_is_thrown_if_dates_conflict(string startDate, int duration)
        {
            var car = new Car();
            car.DailyCost = 100;

            Exception ex = Assert.Throws<InvalidOperationException>(() => bookingService.MakeCarBooking(car, DateTime.Parse(startDate), duration, 0, "Joe Bloggs"));
            Assert.That(ex.Message == "Conflict with existing appointment");
        }

        [Test]
        public void agreed_discount_is_applied()
        {
            throw new NotImplementedException();
        }
    }
}
