using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignemnt1_project.Models
{
    public class EFplayers : IPlayersMock
    {   // connect database in EF class 
        private nbaModel db = new nbaModel();
        public IQueryable<player> players { get { return db.players; } }

        public IQueryable<team> teams { get { return db.teams; } }

        public void Delet(player p)
        {
            db.players.Remove(p);
            db.SaveChanges();
        }

        public player Save(player p)
        {
            if (p.player_id == 0)
            {
                //insert 
                db.players.Add(p);

            }
            else
            {
                //update 
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
               
            }
            db.SaveChanges();
            return p;
        }
    }
}