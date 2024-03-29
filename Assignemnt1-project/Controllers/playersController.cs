﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignemnt1_project.Models;

namespace Assignemnt1_project.Controllers
{   [Authorize]//[Authorize (Roles = "Administrator")]
    public class playersController : Controller
    {   
        //disable automatic db connection 
       // private nbaModel db = new nbaModel();
       private IPlayersMock db ;
       //defalut sql database constructor
       public playersController()
        {
            this.db = new EFplayers();
        }
        //mock constructor
        public playersController(IPlayersMock mock)
        {
            this.db = mock;
        }


        [AllowAnonymous]
        // GET: players
        public ActionResult Index()
        {
            var players = db.players.Include(p => p.team);
            //return View(players.ToList());
            return View("Index",players.ToList());
        }

       // GET: players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //scaffold code
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //old scaffold does not work with mock
            //player player = db.players.Find(id);
            //new code work for ef and mock
            player player = db.players.SingleOrDefault(p => p.player_id == id);

            if (player == null)
            {   // old scaffold code
                //return HttpNotFound();
                return View("Error");
            }
            return View("Details",player);
        }

        //// GET: players/Create
        public ActionResult Create()
        {
            ViewBag.team_id = new SelectList(db.teams, "team_id", "team_name");
            return View("Create");
        }

        //// POST: players/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "player_id,first_name,last_name,salary,position,points_per_game,rebonds_per_game,injury,team_id")] player player)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.players.Add(player);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.team_id = new SelectList(db.teams, "team_id", "team_name", player.team_id);
        //    return View(player);
        //}

        //// GET: players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //player player = db.players.Find(id);
            player player = db.players.SingleOrDefault(p => p.player_id == id);
            if (player == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            ViewBag.team_id = new SelectList(db.teams, "team_id", "team_name", player.team_id);
            return View("Edit",player);
        }

        //// POST: players/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "player_id,first_name,last_name,salary,position,points_per_game,rebonds_per_game,injury,team_id")] player player)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(player).State = EntityState.Modified;
                // db.SaveChanges();
                db.Save(player);
                return RedirectToAction("Index");
            }
            ViewBag.team_id = new SelectList(db.teams, "team_id", "team_name", player.team_id);
            return View(player);
        }

        //// GET: players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //player player = db.players.Find(id);
            player player = db.players.SingleOrDefault(p => p.player_id == id);
            if (player == null)
            {
                // return HttpNotFound();
                return View("Error");
            }
            return View(player);
        }

        //// POST: players/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    player player = db.players.Find(id);
        //    db.players.Remove(player);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
