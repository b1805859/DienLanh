using DienLanh_BackEnd.Common;
using DienLanh_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Business
{
    public class B_Booking : S_Booking
    {
        readonly DatabaseContext _dbContext = new();

        public B_Booking(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddBooking(Booking booking)
        {
            try
            {
                booking.BookingID = C_Function.randomID();
                booking.CreatedDate = DateTime.Now;
                booking.UpdatedDate = DateTime.Now;

                while (_dbContext.Bookings!.Any(bookingDB => bookingDB.BookingID == booking.BookingID))
                {
                    booking.BookingID = C_Function.randomID();
                }

                _dbContext.Bookings!.Add(booking);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteBooking(string id)
        {
            bool result = false;
            try
            {
                Booking bookings = _dbContext.Bookings!.Find(id)!;

                if (bookings != null)
                {
                    _dbContext.Bookings.Remove(bookings);
                    _dbContext.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch
            {
                return false;
            }
        }

        public Booking GetBookingDetails(string id)
        {
            try
            {
                Booking booking = _dbContext.Bookings!.Find(id)!;

                return booking;
            }
            catch
            {
                return null;
            }
        }

        public List<Booking> GetBookings()
        {
            try
            {
                return _dbContext.Bookings!.ToList();
            }
            catch
            {
                return new List<Booking>();
            }
        }

        public bool UpdateBooking(Booking booking)
        {
            try
            {
                booking.UpdatedDate = DateTime.Now;

                _dbContext.Entry(booking).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
