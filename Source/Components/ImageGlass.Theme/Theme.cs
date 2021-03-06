﻿/*
ImageGlass Project - Image viewer for Windows
Copyright (C) 2013 DUONG DIEU PHAP
Project homepage: http://imageglass.org

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Drawing;
using ImageGlass.Services.Configuration;


namespace ImageGlass.Theme
{
    public class Theme
    {
        //Info
        public string name = string.Empty;                  
        public string version = string.Empty;               
        public string author = string.Empty;                
        public string email = string.Empty;                 
        public string website = string.Empty;               
        public string description = string.Empty;           
        public string type = string.Empty;                     //config file type
        public string compatibility = string.Empty;            //minimum version requirement
        public string preview = string.Empty;                  //preview photo file

        //main
        public string topbar = string.Empty;                   
        public int topbartransparent = 0;                      //v1.2 only
        public Color backcolor = Color.White;                  
        public string bottombar = string.Empty;                 //v3.2-
        public Color bottomBarColor = Color.FromArgb(234, 234, 242);    //v3.3+
        public Color statuscolor = Color.Black;                

        //toolbar icon
        public string back = string.Empty;
        public string next = string.Empty;
        public string leftrotate = string.Empty;
        public string rightrotate = string.Empty;
        public string zoomin = string.Empty;
        public string zoomout = string.Empty;
        public string scaletofit = string.Empty;
        public string zoomlock = string.Empty;                  //v1.5+
        public string scaletowidth = string.Empty;
        public string scaletoheight = string.Empty;
        public string autosizewindow = string.Empty;
        public string open = string.Empty;
        public string refresh = string.Empty;
        public string gotoimage = string.Empty;
        public string thumbnail = string.Empty;
        public string checkBackground = string.Empty;
        public string fullscreen = string.Empty;
        public string slideshow = string.Empty;
        public string convert = string.Empty;
        public string print = string.Empty;                     //v1.5+
        public string uploadfb = string.Empty;                  //v1.5+
        public string extension = string.Empty;                 //v1.5+
        public string settings = string.Empty;
        public string about = string.Empty;
        public string like = string.Empty;                      //v2.0-
        public string dislike = string.Empty;                   //v2.0-
        public string report = string.Empty;                    //v2.0-
        public string menu = string.Empty;                      //v3.0+

        public Theme() { }

        /// <summary>
        /// Read theme data from theme configuration file (Version 1.5+)
        /// </summary>
        /// <param name="file"></param>
        public Theme(string file)
        {
            LoadTheme(file);
        }

        /// <summary>
        /// Read theme data from theme configuration file (Version 1.5+). 
        /// Return TRUE if sucessful, FALSE if the theme format is older version
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool LoadTheme(string file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlElement root = doc.DocumentElement;
            XmlElement nType = null;
            XmlElement n = null;

            try
            {
                //Load theme version 1.5+ as default
                nType = (XmlElement)root.SelectNodes("Theme")[0]; //<Theme>
                n = (XmlElement)nType.SelectNodes("Info")[0];//<Info>
            }
            catch
            {
                LoadThemeOldVersion(file);
                return false;
            }

            try { name = n.GetAttribute("name"); }
            catch { };
            try { version = n.GetAttribute("version"); }
            catch { };
            try { author = n.GetAttribute("author"); }
            catch { };
            try { email = n.GetAttribute("email"); }
            catch { };
            try { website = n.GetAttribute("website"); }
            catch { };
            try { description = n.GetAttribute("description"); }
            catch { };
            try { type = n.GetAttribute("type"); }
            catch { };
            try { compatibility = n.GetAttribute("compatibility"); }
            catch { };
            try { preview = n.GetAttribute("preview"); }
            catch { };

            n = (XmlElement)nType.SelectNodes("main")[0]; //<main>
            try { topbar = n.GetAttribute("topbar"); }
            catch { };
            try { topbartransparent = int.Parse(n.GetAttribute("topbartransparent")); }
            catch { };
            try { backcolor = Color.FromArgb(int.Parse(n.GetAttribute("backcolor"))); }
            catch { };
            try { bottomBarColor = Color.FromArgb(int.Parse(n.GetAttribute("bottombarcolor"))); }
            catch { };
            try { statuscolor = Color.FromArgb(int.Parse(n.GetAttribute("statuscolor"))); }
            catch { };

            n = (XmlElement)nType.SelectNodes("toolbar_icon")[0]; //<toolbar_icon>
            try { back = n.GetAttribute("back"); }
            catch { };
            try { next = n.GetAttribute("next"); }
            catch { };
            try { leftrotate = n.GetAttribute("leftrotate"); }
            catch { };
            try { rightrotate = n.GetAttribute("rightrotate"); }
            catch { };
            try { zoomin = n.GetAttribute("zoomin"); }
            catch { };
            try { zoomout = n.GetAttribute("zoomout"); }
            catch { };
            try { scaletofit = n.GetAttribute("scaletofit"); }
            catch { };
            try { zoomlock = n.GetAttribute("zoomlock"); }
            catch { };
            try { scaletowidth = n.GetAttribute("scaletowidth"); }
            catch { };
            try { scaletoheight = n.GetAttribute("scaletoheight"); }
            catch { };
            try { autosizewindow = n.GetAttribute("autosizewindow"); }
            catch { };
            try { open = n.GetAttribute("open"); }
            catch { };
            try { refresh = n.GetAttribute("refresh"); }
            catch { };
            try { gotoimage = n.GetAttribute("gotoimage"); }
            catch { };
            try { thumbnail = n.GetAttribute("thumbnail"); }
            catch { };
            try { checkBackground = n.GetAttribute("caro"); }
            catch { };
            try { fullscreen = n.GetAttribute("fullscreen"); }
            catch { };
            try { slideshow = n.GetAttribute("slideshow"); }
            catch { };
            try { convert = n.GetAttribute("convert"); }
            catch { };
            try { print = n.GetAttribute("print"); }
            catch { };
            try { uploadfb = n.GetAttribute("uploadfb"); }
            catch { };
            try { extension = n.GetAttribute("extension"); }
            catch { };
            try { settings = n.GetAttribute("settings"); }
            catch { };
            try { about = n.GetAttribute("about"); }
            catch { };
            //try { like = n.GetAttribute("like"); }
            //catch { };
            //try { dislike = n.GetAttribute("dislike"); }
            //catch { };
            //try { report = n.GetAttribute("report"); }
            //catch { };
            try { report = n.GetAttribute("menu"); }
            catch { };

            return true;
        }

        /// <summary>
        /// Read theme data from theme configuration file (Version 1.4)
        /// </summary>
        /// <param name="file"></param>
        public void LoadThemeOldVersion(string file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlElement root = doc.DocumentElement;//<data>
            XmlElement n = (XmlElement)root.SelectNodes("metadata")[0];//<metadata>

            try { name = n.GetAttribute("name"); }
            catch { };
            try { version = n.GetAttribute("version"); }
            catch { };
            try { author = n.GetAttribute("author"); }
            catch { };
            try { email = n.GetAttribute("email"); }
            catch { };
            try { website = n.GetAttribute("website"); }
            catch { };
            try { description = n.GetAttribute("description"); }
            catch { };
            try { type = n.GetAttribute("type"); }
            catch { };
            try { compatibility = n.GetAttribute("compatibility"); }
            catch { };
            try { preview = n.GetAttribute("preview"); }
            catch { };

            n = (XmlElement)root.SelectNodes("main")[0]; //<main>
            try { topbar = n.GetAttribute("topbar"); }
            catch { };
            try { topbartransparent = int.Parse(n.GetAttribute("topbartransparent")); }
            catch { };
            try { backcolor = Color.FromArgb(int.Parse(n.GetAttribute("backcolor"))); }
            catch { };
            try { bottombar = n.GetAttribute("bottombar"); }
            catch { };
            try { statuscolor = Color.FromArgb(int.Parse(n.GetAttribute("statuscolor"))); }
            catch { };

            n = (XmlElement)root.SelectNodes("toolbar_icon")[0]; //<toolbar_icon>
            try { back = n.GetAttribute("back"); }
            catch { };
            try { next = n.GetAttribute("next"); }
            catch { };
            try { leftrotate = n.GetAttribute("leftrotate"); }
            catch { };
            try { rightrotate = n.GetAttribute("rightrotate"); }
            catch { };
            try { zoomin = n.GetAttribute("zoomin"); }
            catch { };
            try { zoomout = n.GetAttribute("zoomout"); }
            catch { };
            try { scaletofit = n.GetAttribute("scaletofit"); }
            catch { };
            try { zoomlock = n.GetAttribute("zoomlock"); }
            catch { };
            try { scaletowidth = n.GetAttribute("scaletowidth"); }
            catch { };
            try { scaletoheight = n.GetAttribute("scaletoheight"); }
            catch { };
            try { autosizewindow = n.GetAttribute("autosizewindow"); }
            catch { };
            try { open = n.GetAttribute("open"); }
            catch { };
            try { refresh = n.GetAttribute("refresh"); }
            catch { };
            try { gotoimage = n.GetAttribute("gotoimage"); }
            catch { };
            try { thumbnail = n.GetAttribute("thumbnail"); }
            catch { };
            try { checkBackground = n.GetAttribute("caro"); }
            catch { };
            try { fullscreen = n.GetAttribute("fullscreen"); }
            catch { };
            try { slideshow = n.GetAttribute("slideshow"); }
            catch { };
            try { convert = n.GetAttribute("convert"); }
            catch { };
            try { print = n.GetAttribute("print"); }
            catch { };
            try { uploadfb = n.GetAttribute("uploadfb"); }
            catch { };
            try { extension = n.GetAttribute("extension"); }
            catch { };
            try { settings = n.GetAttribute("settings"); }
            catch { };
            try { about = n.GetAttribute("about"); }
            catch { };
            //try { like = n.GetAttribute("like"); }
            //catch { };
            //try { dislike = n.GetAttribute("dislike"); }
            //catch { };
            //try { report = n.GetAttribute("report"); }
            //catch { };
            try { report = n.GetAttribute("menu"); }
            catch { };
        }

        /// <summary>
        /// Save theme compatible with v1.5+
        /// </summary>
        /// <param name="dir"></param>
        public void SaveAsTheme(string dir)
        {
            dir = (dir + "\\").Replace("\\\\", "\\");
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("ImageGlass");//<ImageGlass>
            XmlElement nType = doc.CreateElement("Theme");//<Theme>

            XmlElement n = doc.CreateElement("Info");// <Info>
            n.SetAttribute("name", name);
            n.SetAttribute("version", version);
            n.SetAttribute("author", author);
            n.SetAttribute("email", email);
            n.SetAttribute("website", website);
            n.SetAttribute("description", description);
            n.SetAttribute("type", "ImageGlass Theme Configuration");
            n.SetAttribute("compatibility", compatibility);
            n.SetAttribute("preview", preview);
            nType.AppendChild(n);

            n = doc.CreateElement("main");// <main>
            n.SetAttribute("topbar", topbar);
            n.SetAttribute("topbartransparent", "0");
            n.SetAttribute("bottombar", bottombar);
            n.SetAttribute("backcolor", backcolor.ToArgb().ToString());
            n.SetAttribute("statuscolor", statuscolor.ToArgb().ToString());
            nType.AppendChild(n);

            n = doc.CreateElement("toolbar_icon");// <toolbar_icon>
            n.SetAttribute("back", back);
            n.SetAttribute("next", next);
            n.SetAttribute("leftrotate", leftrotate);
            n.SetAttribute("rightrotate", rightrotate);
            n.SetAttribute("zoomin", zoomin);
            n.SetAttribute("zoomout", zoomout);
            n.SetAttribute("zoomlock", zoomlock);
            n.SetAttribute("scaletofit", scaletofit);
            n.SetAttribute("scaletowidth", scaletowidth);
            n.SetAttribute("scaletoheight", scaletoheight);
            n.SetAttribute("autosizewindow", autosizewindow);
            n.SetAttribute("open", open);
            n.SetAttribute("refresh", refresh);
            n.SetAttribute("gotoimage", gotoimage);
            n.SetAttribute("thumbnail", thumbnail);
            n.SetAttribute("caro", checkBackground);
            n.SetAttribute("fullscreen", fullscreen);
            n.SetAttribute("slideshow", slideshow);
            n.SetAttribute("convert", convert);
            n.SetAttribute("print", print);
            n.SetAttribute("uploadfb", uploadfb);
            n.SetAttribute("extension", extension);
            n.SetAttribute("settings", settings);
            n.SetAttribute("about", about);
            //n.SetAttribute("like", this.like);
            //n.SetAttribute("dislike", this.dislike);
            //n.SetAttribute("report", this.report);
            n.SetAttribute("menu", report);
            nType.AppendChild(n);

            root.AppendChild(nType);
            doc.AppendChild(root);

            //create temp directory of theme
            if (Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            doc.Save(dir + "config.xml"); //save file
        }

        /// <summary>
        /// Apply the new theme
        /// </summary>
        /// <param name="themePath">Đường dẫn đầy đủ của *.igtheme</param>
        public void ApplyTheme(string themePath)
        {
            //Save theme path
            GlobalSetting.SetConfig("Theme", themePath);

            //Save background color
            try
            {
                ImageGlass.Theme.Theme th = new ImageGlass.Theme.Theme(themePath);
                GlobalSetting.SetConfig("BackgroundColor", th.backcolor.ToArgb().ToString());
            }
            catch
            {
                GlobalSetting.SetConfig("BackgroundColor", Color.White.ToArgb().ToString());
            }
        }


    }
}
