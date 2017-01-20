﻿using RPGmvc.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGmvc.Models.GameRules
{
    public class CallOfCthulhuRules : IGameRule
    {
        public void setStats(Character myCharac)
        {
            //Stats prestance = new Stats("prestance", 90, mon_perso.baseAttr.Where(b => b.name == "appearance").FirstOrDefault().value * 5);
            //Stats endurance = new Stats("endurance", 90, mon_perso.baseAttr.Where(b => b.name == "constitution").FirstOrDefault().value * 5);
            //Stats agility = new Stats("agility", 90, mon_perso.baseAttr.Where(b => b.name == "dexterity").FirstOrDefault().value * 5);
            //Stats brawlpower = new Stats("brawl power", 90, mon_perso.baseAttr.Where(b => b.name == "strength").FirstOrDefault().value * 5);
            //Stats height = new Stats("height", 90, mon_perso.baseAttr.Where(b => b.name == "size").FirstOrDefault().value * 5);
            //Stats knowledge = new Stats("knowledge", 120, mon_perso.baseAttr.Where(b => b.name == "education").FirstOrDefault().value * 5);
            //Stats idea = new Stats("idea", 90, mon_perso.baseAttr.Where(b => b.name == "intelligence").FirstOrDefault().value * 5);
            //Stats willpower = new Stats("will power", 90, mon_perso.baseAttr.Where(b => b.name == "power").FirstOrDefault().value * 5);
            //Stats sanity = new Stats("sanity", 90, mon_perso.baseAttr.Where(b => b.name == "power").FirstOrDefault().value * 5);

            if (!(myCharac.game is CallOfCthulhu))
            {
                return;
            }

            myCharac.stats.Where(s => s.name == "prestance").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "appearance").FirstOrDefault().value * 5;
            myCharac.stats.Where(s => s.name == "endurance").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "constitution").FirstOrDefault().value * 5;
            myCharac.stats.Where(s => s.name == "agility").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "dexterity").FirstOrDefault().value * 5;
            myCharac.stats.Where(s => s.name == "brawl power").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "strength").FirstOrDefault().value * 5;
            myCharac.stats.Where(s => s.name == "height").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "size").FirstOrDefault().value * 5;
            myCharac.stats.Where(s => s.name == "knowledge").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "education").FirstOrDefault().value * 5;
            myCharac.stats.Where(s => s.name == "idea").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "intelligence").FirstOrDefault().value * 5;
            myCharac.stats.Where(s => s.name == "will power").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "power").FirstOrDefault().value * 5;
            myCharac.stats.Where(s => s.name == "sanity").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "power").FirstOrDefault().value * 5;

        }

        public void setSpendablePoints(Character myCharac)
        {
            //spendpoints healthPoints = new spendpoints("health points", 18, (
            //    (mon_perso.baseAttr.Where(b => b.name == "constitution").FirstOrDefault().value
            //    )
            //    +
            //    (mon_perso.baseAttr.Where(b => b.name == "size").FirstOrDefault().value)
            //    ) / 2
            //    );
            //spendpoints woundLimit = new spendpoints("wound limit", 9);
            //spendpoints magicPoints = new spendpoints("magic points", 18);
            //spendpoints occupationSkillPoints = new spendpoints("Occupation skill points", 480);
            //spendpoints personalInterestSkillPoints = new spendpoints("Personal interest skill points", 180);

            if (!(myCharac.game is CallOfCthulhu))
            {
                return;
            }

            myCharac.spendPoints.Where(s => s.name == "health points").FirstOrDefault().value =
                (myCharac.baseAttr.Where(b => b.name == "constitution").FirstOrDefault().value +
                myCharac.baseAttr.Where(b => b.name == "size").FirstOrDefault().value)
                / 2;

            myCharac.spendPoints.Where(s => s.name == "wound limit").FirstOrDefault().value = myCharac.spendPoints.Where(s => s.name == "health points").FirstOrDefault().value / 2;
            myCharac.spendPoints.Where(s => s.name == "magic points").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "power").FirstOrDefault().value;
            myCharac.spendPoints.Where(s => s.name == "Occupation skill points").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "education").FirstOrDefault().value * 20;
            myCharac.spendPoints.Where(s => s.name == "Personal interest skill points").FirstOrDefault().value = myCharac.baseAttr.Where(b => b.name == "intelligence").FirstOrDefault().value * 10;

        }
    }
}