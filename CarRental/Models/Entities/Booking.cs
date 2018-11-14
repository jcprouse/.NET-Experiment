using System;

namespace CarRental.Models.Entities
{
    public class Booking
    {
        public int CarId { get; set; }

        public string Name { get; set; }

        public float TotalCost { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime CompletedDate { get; set; }
    }
}