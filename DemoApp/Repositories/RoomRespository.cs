using DemoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.Repositories
{
    public class RoomRespository : IRoomRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomRespository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRoom(Room room)
        {
            _dbContext.Add(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Room> Find(Guid id)
        {
            return await _dbContext.Room.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _dbContext.Room.ToListAsync();
        }
    }
}
