using RPGmvc.Models;
using RPGmvc.Models.Games;
using RPGmvc.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace RPGmvc.Repository
{
    public class CharacterRepository
    {
        
        public IEnumerable<Character> Get()
        {
            List<Character> myCharacs = new List<Character>();

            // This might be reworked.
            // We get the character sheets in app_data and create characters from that.
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);
            var myFiles = Directory.GetFiles(@path);

            foreach (var file in myFiles)
            {
                // This might be reworked : change the generic name for game.name + "_character_sheet".
                if (file != path + "call_of_cthulhu_character_sheet")
                {
                    Character charac = new Character(file);
                    myCharacs.Add(charac);
                }
            }

            return myCharacs;
        }

        public Character Get(string name)
        {
            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);
            var myFiles = Directory.GetFiles(@path);

            Character searched_character = new Character();

            foreach (var file in myFiles)
            {
                if (file == path + name.ToLower() + ".xml")
                {
                    searched_character = new Character(file);
                }
            }
            return searched_character;
        }

        public void Update(Character monPerso, Character newVersion)
        {
            SheetFiller sFiller = new SheetFiller();

            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            // Save existing version in "backup" sub-folder
            sFiller.backUpCharacter(monPerso, path);

            // Record the new values
            sFiller.fillInfos(newVersion, path);
            sFiller.fillBaseAttributes(newVersion, path);
            sFiller.fillStats(newVersion, path);
            sFiller.fillSpendablePoints(newVersion, path);
            sFiller.fillSkills(newVersion, path);

        }

        public void UpdateSkills(Character monPerso, Character newVersion)
        {
            SheetFiller sFiller = new SheetFiller();

            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            // Save existing version in "backup" sub-folder
            sFiller.backUpCharacter(monPerso, path);

            // Record the new values
            sFiller.fillSkills(newVersion, path);
            sFiller.fillSpendablePoints(newVersion, path);
        }

        public void Create(string characterName, string playerName)
        {
            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            // Use a basic constructor.
            Character myCharacter = new Character(characterName, playerName);
            
            // Creates a character_sheet for Cthulhu Game. 
            // It's the default for dev purposes.
            SheetWriter sWriter = new SheetWriter();
            sWriter.CreateSheet("cthulhu_character_sheet");

            // Filler will be used to record values of character in sheet.
            SheetFiller sFiller = new SheetFiller();
            sFiller.fillInfos(myCharacter, path);
            sFiller.fillBaseAttributes(myCharacter, path);
            sFiller.fillStats(myCharacter, path);
            sFiller.fillSpendablePoints(myCharacter, path);
            sFiller.fillSkills(myCharacter, path);

        }

        // This is the "ultimate" creator.
        public void Create(IGame myGame, string mycharacterName, string myplayerName)
        {
            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            // This will load the caracteristic of the game in the character and set every value
            Character myHero = new Character(myGame, mycharacterName, myplayerName);
            
            // This will create a generic character sheet using the name of the game and its caracteristic lists.
            SheetWriter sWriter = new SheetWriter();
            sWriter.CreateSheet(myGame, myGame.name+"_character_sheet");

            SheetFiller sFiller = new SheetFiller();
            sFiller.fillInfos(myHero, path);
            sFiller.fillBaseAttributes(myHero, path);
            sFiller.fillStats(myHero, path);
            sFiller.fillSpendablePoints(myHero, path);
            sFiller.fillSkills(myHero, path);

        }

    }
}