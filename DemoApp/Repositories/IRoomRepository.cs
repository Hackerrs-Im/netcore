using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.Repositories
{
    public interface IRoomRepository
    {
        Task AddRoom(Room room);

        Task<Room> Find(Guid id);

        Task<List<Room>> GetAllRooms();
    }
}
