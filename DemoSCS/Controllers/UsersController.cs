using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCSDALCore;
using DataModelCore;
using Microsoft.AspNetCore.Authorization;

namespace DemoSCS.Controllers
{
   
    public class UsersController : Controller
    {
		
        // GET: Users
        public ActionResult Index()
        {
            try
            {
                //if(HttpContext.User.Identity.IsAuthenticated)

                UserDetails userDetails = new UserDetails();
                List<user_info> allUsers = userDetails.GetAllUserList();



                return View(allUsers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (!string.IsNullOrEmpty(collection["Name"].ToString()))
                {
                    user_info user_Info = new user_info();
                    user_Info.Name = collection["Name"].ToString();

                    UserDetails userDetails = new UserDetails();
                    bool isAdded = userDetails.SaveUserDetails(user_Info);


                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Name", "Please Enter User Name");
                    return View(new user_info());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(new user_info());
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}