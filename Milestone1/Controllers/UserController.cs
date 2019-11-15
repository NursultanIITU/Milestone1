using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Milestone1.Data;
using Milestone1.Models;
using Milestone1.Services;

namespace Milestone1.Controllers
{
    public class UserController : Controller
    {
        private readonly MyAppContext _context;
        private UserService _userService;

        public UserController(MyAppContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {

            return View(await _context.Users.ToListAsync());
        }

       

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            _userService.checkId(id);

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.userID == id);

            _userService.checkUser(user);

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }


        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUseAsync(string EmpCode)
        {
            var user = await _context.Users
               .AnyAsync(m => m.EmpCode == EmpCode);
 
            if (!user)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {EmpCode} is already in use.");
            }
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userID,FullName,EmpCode,About")] User user)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(user);
                //await _context.SaveChangesAsync();
                _userService.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            _userService.checkId(id);

            var user = await _context.Users.FindAsync(id);

            _userService.checkUser(user);

            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userID,FullName,EmpCode,About")] User user)
        {
            if (id != user.userID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.userID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.userID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.userID == id);
        }
    }
}
