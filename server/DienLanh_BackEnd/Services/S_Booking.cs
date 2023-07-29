using DienLanh_BackEnd.Models;

namespace WebAPI_JWT_NET6_Base.Services
{
    public interface S_Booking
    {
        public List<Booking> GetBookings();
        public Booking GetBookingDetails(string id);
        public bool AddBooking(Booking booking);
        public bool UpdateBooking(Booking booking);
        public bool DeleteBooking(string id);
    }
}
