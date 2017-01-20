using RPGmvc.Models.Caracteristic;
using RPGmvc.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGmvc.Models.Careers
{
    public interface ICareer
    {
        string name { get; set; }
        List<Skills> jobSkills { get; set; }
        //IGame game { get; set; }
    }
}
