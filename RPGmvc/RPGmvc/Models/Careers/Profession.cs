using RPGmvc.Models.Caracteristic;
using RPGmvc.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGmvc.Models.Careers
{
    public class Profession : ICareer
    {
        public string name { get; set; }
        public List<Skills> jobSkills{ get; set; }
        //public IGame game{ get; set; }

        public Profession(string name)
        {
            this.name = name;
            this.jobSkills = new List<Skills>();
        }
    }

}