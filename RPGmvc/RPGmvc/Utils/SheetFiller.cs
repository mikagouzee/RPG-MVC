using RPGmvc.Models;
using RPGmvc.Models.Caracteristic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace RPGmvc.Utils
{
    public class SheetFiller
    {
        XmlDocument myDoc;

        // Used to save older sheet before changing them, in case there's a trouble
        public void backUpCharacter(Character myCharac, string myPath)
        {
            myDoc = new XmlDocument();

            if (CheckIfCharacterAlreadyExists(myCharac.characterName.ToLower()))
                myDoc.Load(myPath + myCharac.characterName.ToLower() + ".xml");

            myPath += "backup\\";
            myPath += myCharac.characterName.ToLower() + ".xml";

            saveFile(myPath);

        }

        // Used to check that the sheet exists
        public bool CheckIfCharacterAlreadyExists(string characterName)
        {
            string directory = ConfigurationManager.AppSettings["path"];
            directory = System.Web.HttpContext.Current.Server.MapPath(directory);
            string mask = "*.xml";
            string nameModified = directory.ToString() + characterName + ".xml";

            foreach (string file in Directory.GetFiles(directory, mask))
            {
                if (file == nameModified)
                {
                    return true;
                }
            }

            return false;
        }

        public void fillInfos(Character myCharac, string myPath)
        {
            myDoc = new XmlDocument();

            // We will need to change this to ensure the good game sheet is loaded.
            // Currently we only have call of cthulhu sheets so it will have to do.
            if (CheckIfCharacterAlreadyExists(myCharac.characterName.ToLower()))
                myDoc.Load(myPath + myCharac.characterName.ToLower() + ".xml");
            else
                myDoc.Load(myPath + myCharac.game.name.Replace(" ", "_").ToLower()+"_character_sheet");

            // We fill the information section : name, campaign, game etc.
            var nameNode = myDoc.SelectSingleNode("/character_sheet/infos/name");
            nameNode.InnerText = myCharac.characterName;

            var playerNameNode = myDoc.SelectSingleNode("/character_sheet/infos/player_name");
            playerNameNode.InnerText = myCharac.playerName;

            var gameNode = myDoc.SelectSingleNode("/character_sheet/infos/game");
            gameNode.InnerText = myCharac.game.ToString();

            var careerNode = myDoc.SelectSingleNode("/character_sheet/infos/career");
            //careerNode.InnerText = myCharac.metier.name;
            careerNode.InnerText = myCharac.careerName;

            // Now we save the file as an xml.
            string path = myPath + myCharac.characterName.ToLower() + ".xml";
            saveFile(path);
        }

        public void fillSheet(Character myCharac, string myPath)
        {
            myDoc = new XmlDocument();
            if (CheckIfCharacterAlreadyExists(myCharac.characterName.ToLower()))
                myDoc.Load(myPath + myCharac.characterName.ToLower() + ".xml");
            else
                myDoc.Load(myPath + myCharac.game.name.Replace(" ", "_").ToLower() + "_character_sheet");

            fillBaseAttributes(myCharac, myPath);
            fillStats(myCharac, myPath);
            fillSkills(myCharac, myPath);
            fillSpendablePoints(myCharac, myPath);
        }

        public void fillBaseAttributes(Character myCharac, string myPath)
        {
            myDoc = new XmlDocument();

            // We will need to change this to ensure the good game sheet is loaded.
            // Currently we only have call of cthulhu sheets so it will have to do.
            if (CheckIfCharacterAlreadyExists(myCharac.characterName.ToLower()))
                myDoc.Load(myPath + myCharac.characterName.ToLower() + ".xml");
            else
                myDoc.Load(myPath + myCharac.game.name.Replace(" ", "_").ToLower()+"_character_sheet");


            foreach (ICaracteristic battr in myCharac.baseAttr)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/base_attributes/" + battr.name.Replace(" ", "_").ToLower());
                currentNode.InnerText = battr.value.ToString();
            }
            string path = myPath + myCharac.characterName.ToLower() + ".xml";
            saveFile(path);
        }

        public void fillStats(Character myCharac, string myPath)
        {
            myDoc = new XmlDocument();

            // We will need to change this to ensure the good game sheet is loaded.
            // Currently we only have call of cthulhu sheets so it will have to do.
            if (CheckIfCharacterAlreadyExists(myCharac.characterName.ToLower()))
                myDoc.Load(myPath + myCharac.characterName.ToLower() + ".xml");
            else
                myDoc.Load(myPath + myCharac.game.name.Replace(" ", "_").ToLower()+"_character_sheet");

            foreach (ICaracteristic stat in myCharac.stats)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/stats/" + stat.name.Replace(" ", "_").ToLower());
                currentNode.InnerText = stat.value.ToString();
            }
            string path = myPath + myCharac.characterName.ToLower() + ".xml";
            saveFile(path);
        }

        public void fillSpendablePoints(Character myCharac, string myPath)
        {
            myDoc = new XmlDocument();

            // We will need to change this to ensure the good game sheet is loaded.
            // Currently we only have call of cthulhu sheets so it will have to do.
            if (CheckIfCharacterAlreadyExists(myCharac.characterName.ToLower()))
                myDoc.Load(myPath + myCharac.characterName.ToLower() + ".xml");
            else
                myDoc.Load(myPath + myCharac.game.name.Replace(" ", "_").ToLower() + "_character_sheet");

            foreach (ICaracteristic sPoint in myCharac.spendPoints)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/spendable_points/" + sPoint.name.Replace(" ", "_").ToLower());
                currentNode.InnerText = sPoint.value.ToString();
            }

            string path = myPath + myCharac.characterName.ToLower() + ".xml";
            saveFile(path);
        }

        public void fillSkills(Character myCharac, string myPath)
        {
            myDoc = new XmlDocument();

            // We will need to change this to ensure the good game sheet is loaded.
            // Currently we only have call of cthulhu sheets so it will have to do.
            if (CheckIfCharacterAlreadyExists(myCharac.characterName.ToLower()))
                myDoc.Load(myPath + myCharac.characterName.ToLower() + ".xml");
            else
                myDoc.Load(myPath + myCharac.game.name.Replace(" ", "_").ToLower().Replace(" ", "_").ToLower() + "_character_sheet");

            foreach (ICaracteristic skill in myCharac.skills)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/skills/" + skill.name.Replace(" ", "_").ToLower());
                currentNode.InnerText = skill.value.ToString();
            }

            string path = myPath + myCharac.characterName.ToLower() + ".xml";
            saveFile(path);
        }

        public void saveFile(string myPath)
        {
            myDoc.Save(myPath);
        }
    }
}