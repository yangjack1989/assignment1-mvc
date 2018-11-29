using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnt1_project.Models
{
     public interface IPlayersMock
    {
        IQueryable <player> players { get; }
        IQueryable<team> teams { get; }
        player Save(player p);
        void Delet(player p);

    }
}
