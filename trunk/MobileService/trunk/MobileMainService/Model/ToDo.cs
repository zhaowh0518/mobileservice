/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind                                                     *
 * Created: 2009-4-28                                                       *
 *                                                                          *
 * Description:                                                             *
 *  To do and to do list structor                                           *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Disappearwind.MobileService.MobileMainService
{
    /// <summary>
    /// To do class
    /// </summary>
    public class ToDo
    {
        /// <summary>
        /// Guid
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// Message content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Do datetime
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ToDo()
        {
 
        }
        /// <summary>
        /// Constructor.ID will be generated
        /// </summary>
        /// <param name="content">message content</param>
        /// <param name="dt">do datetime</param>
        public ToDo(string content, DateTime dt)
        {
            ID = Guid.NewGuid();
            Content = content;
            Time = dt;
        }
        /// <summary>
        /// Juge is two datetime equal
        /// </summary>
        /// <param name="dt1">first time</param>
        /// <param name="dt2">second time</param>
        /// <returns></returns>
        public bool IsEqualTime(DateTime dt1, DateTime dt2)
        {
            if (dt1 == dt2)
            {
                return true;
            }
            TimeSpan ds = dt1 - dt2;
            if (ds.Ticks < 0 && ds.Ticks >= -10001000)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Convert current object to xml
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            string resultXML = string.Empty;
            XmlSerializer xmlSeri = new XmlSerializer(GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                xmlSeri.Serialize(ms, this,new XmlSerializerNamespaces());
                resultXML = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
            return resultXML;
        }
    }
    /// <summary>
    /// To do list class
    /// </summary>
    public class ToDoList : List<ToDo>
    {
        /// <summary>
        /// Persistence data to xml file
        /// </summary>
        public void SaveToXmlFile()
        {
            string dataPath = GetDataPath();
            string xmlInfo = string.Empty;
            string xmlFileName = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            foreach (var item in this)
            {
                xmlFileName = string.Format("{0}{1}.xml", dataPath, item.ID);
                if (!File.Exists(xmlFileName))
                {
                    xmlInfo = item.ToXml();
                    xmlDoc.LoadXml(xmlInfo);
                    xmlDoc.Save(xmlFileName);
                }
            }
        }
        /// <summary>
        /// Get xml data path
        /// </summary>
        /// <returns></returns>
        public string GetDataPath()
        {
            string currentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\");
            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }
            return currentPath;
        }
        /// <summary>
        /// Get path of done to do thing
        /// </summary>
        /// <returns></returns>
        public string GetDonePath()
        {
            string donePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Done\\");
            if (!Directory.Exists(donePath))
            {
                Directory.CreateDirectory(donePath);
            }
            return donePath;
        }
        /// <summary>
        /// Get data from xml files which persistenced by SaveToXmlFile
        /// </summary>
        public void LoadFromXmlFile()
        {
            string dataPath = GetDataPath();
            DirectoryInfo direInfo = new DirectoryInfo(dataPath);
            XmlSerializer xmlSeri = new XmlSerializer(typeof(ToDo));
            FileStream fs = null;
            foreach (var item in direInfo.GetFiles())
            {
                fs = item.OpenRead();
                object o = xmlSeri.Deserialize(fs);
                Add((ToDo)o);
                fs.Dispose();
            }
            if (fs != null)
            {
                fs.Close();
            }
        }
        /// <summary>
        /// When to do thing had done, move xml file to done fold
        /// </summary>
        /// <param name="td"></param>
        public void DoneItem(ToDo td)
        {
            string sourcePath = GetDataPath();
            string destPath = GetDonePath();
            string xmlFileName = td.ID + ".xml";
            sourcePath += xmlFileName;
            destPath += xmlFileName;
            File.Move(sourcePath, destPath);
        }
    }
}
