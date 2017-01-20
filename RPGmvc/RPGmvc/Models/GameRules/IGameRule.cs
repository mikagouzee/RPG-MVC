using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGmvc.Models.GameRules
{
    interface IGameRule
    {
        void setStats(Character myCharac);
        void setSpendablePoints(Character myCharac);
    }
}
