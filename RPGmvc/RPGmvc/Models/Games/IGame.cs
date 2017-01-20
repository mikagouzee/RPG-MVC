using RPGmvc.Models.Caracteristic;
using RPGmvc.Models.Careers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGmvc.Models.Games
{
    public interface IGame
    {
        string name { get; set; }
        List<BaseAttributes> BaseAttributes { get; set; }
        List<Stats> Stats { get; set; }
        List<Skills> Skills { get; set; }
        List<spendpoints> SpendPoints { get; set; }
        List<ICareer> professions { get; set; }
    }
}
