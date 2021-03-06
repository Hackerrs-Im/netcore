﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoApp.Models;
using DemoApp.Repositories;

namespace DemoApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _repository;

        public RoomsController(IRoomRepository respository)
        {
            _repository = respository;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var allRoom = await _repository.GetAllRooms();
            return View(allRoom);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _repository.Find(id);

            if (room == null)
            {
                return NotFound();
            }
            
            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Occupancy")] Room room)
        {
            if (ModelState.IsValid)
            {
                room.Id = Guid.NewGuid();
                await _repository.AddRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        //// GET: Rooms/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var room = await _context.Room.SingleOrDefaultAsync(m => m.Id == id);
        //    if (room == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(room);
        //}

        //// POST: Rooms/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Occupancy")] Room room)
        //{
        //    if (id != room.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(room);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RoomExists(room.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(room);
        //}

        //// GET: Rooms/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var room = await _context.Room
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (room == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(room);
        //}

        //// POST: Rooms/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var room = await _context.Room.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Room.Remove(room);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RoomExists(Guid id)
        //{
        //    return _context.Room.Any(e => e.Id == id);
        //}
    }
}
