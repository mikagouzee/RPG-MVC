﻿using RPGmvc.Models.Caracteristic;
using RPGmvc.Models.Games;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml;

namespace RPGmvc.Utils
{
    // Currently this writer writes only for Call of Cthulhu.
    // We should update it so it can create a sheet for other games too.

    public class SheetWriter
    {
        //string fold = ConfigurationManager.AppSettings["folder"];
        string fold = HttpContext.Current.Server.MapPath("~/App_Data/Characters");
        static XmlWriter myWriter;

        public void CreateSheet(string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            myWriter = XmlWriter.Create(@fold + path, settings);
            myWriter.WriteStartDocument();

            myWriter.WriteStartElement("character_sheet");
            //Information section : meta about the character and game
            #region info
            myWriter.WriteStartElement("infos");
            myWriter.WriteStartElement("name");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("player_name");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("career");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("campaign");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("game");
            myWriter.WriteEndElement();
            myWriter.WriteEndElement();
            #endregion

            //base attributes section
            #region base attributes
            myWriter.WriteStartElement("base_attributes");
            myWriter.WriteStartElement("appearance");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("constitution");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("strength");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("dexterity");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("power");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("size");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("intelligence");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("education");
            myWriter.WriteEndElement();
            myWriter.WriteEndElement();
            #endregion

            //Stats
            #region stats
            myWriter.WriteStartElement("stats");
            myWriter.WriteStartElement("prestance");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("endurance");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("agility");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("brawl_power");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("height");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("knowledge");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("idea");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("will_power");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("sanity");
            myWriter.WriteEndElement();
            myWriter.WriteEndElement();
            #endregion

            //"spendable points"
            #region spendable points
            myWriter.WriteStartElement("spendable_points");
            myWriter.WriteStartElement("health_points");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("wound_limit");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("magic_points");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("occupation_skill_points");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("personal_interest_skill_points");
            myWriter.WriteEndElement();
            myWriter.WriteEndElement();
            #endregion

            // Skills
            #region skills
            myWriter.WriteStartElement("skills");
            myWriter.WriteStartElement("art");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("artisanat");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("baratin");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("bibliotheque");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("comptabilite");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("concocter_potion");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("conduire_attelage");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("coup_de_pied");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("coup_de_poing");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("coup_de_tete");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("discretion");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("dissimulation");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("ecouter");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("ecrire_une_langue");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("esquiver");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("grimper");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("lancer");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("langue_etrangere");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("langue_natale");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("lutte");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("marchandage");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("monde_naturel");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("monter_a_cheval");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("mythe_de_cthulhu");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("nager");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("navigation");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("occultisme");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("persuasion");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("piloter_bateau");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("premiers_soins");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("reparer_concevoir");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("royaume_natal");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("royaumes_etrangers");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("sagacite");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("sauter");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("science");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("se_cacher");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("statut");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("suivre_une_piste");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("trouver_objet_cache");
            myWriter.WriteEndElement();
            myWriter.WriteEndElement();
            #endregion

            myWriter.WriteEndElement();

            myWriter.WriteEndDocument();

            myWriter.Close();

        }

        public void CreateSheet(IGame myGame, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            myWriter = XmlWriter.Create(@fold + path, settings);
            myWriter.WriteStartDocument();

            myWriter.WriteStartElement("character_sheet");
            //Information section : meta about the character and game
            #region info
            myWriter.WriteStartElement("infos");
            myWriter.WriteStartElement("name");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("player_name");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("career");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("campaign");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("game");
            myWriter.WriteEndElement();
            myWriter.WriteEndElement();
            #endregion

            //base attributes section
            myWriter.WriteStartElement("base_attributes");
            foreach (ICaracteristic battr in myGame.BaseAttributes)
            {
                myWriter.WriteStartElement(battr.name);
                myWriter.WriteEndElement();
            }
            myWriter.WriteEndElement();

            //Stats
            myWriter.WriteStartElement("Stats");
            foreach (ICaracteristic stat in myGame.Stats)
            {
                myWriter.WriteStartElement(stat.name);
                myWriter.WriteEndElement();
            }
            myWriter.WriteEndElement();

            //spendable points
            myWriter.WriteStartElement("spendable_points");
            foreach (ICaracteristic sPoint in myGame.SpendPoints)
            {
                myWriter.WriteStartElement(sPoint.name);
                myWriter.WriteEndElement();
            }
            myWriter.WriteEndElement();

            //Skills
            myWriter.WriteStartElement("skills");
            foreach (ICaracteristic skill in myGame.Skills)
            {
                myWriter.WriteStartElement(skill.name);
                myWriter.WriteEndElement();
            }
            myWriter.WriteEndElement();

            myWriter.WriteEndElement();

            myWriter.WriteEndDocument();

        }


    }
}