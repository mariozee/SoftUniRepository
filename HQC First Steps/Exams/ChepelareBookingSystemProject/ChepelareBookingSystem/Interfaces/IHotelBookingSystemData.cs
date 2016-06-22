using ChepelareBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChepelareBookingSystem.Interfaces
{
    public interface IHotelBookingSystemData
    {
        IUserRepository RepositoryWithUsers { get; }
        IRepository<Venue> RepositoryWithVenues { get; }
        IRepository<Room> RepositoryWithRooms { get; }
        IRepository<Booking> RepositoryWithBookings { get; }
    }
}
