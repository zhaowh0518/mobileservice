/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind                                                     *
 * Created: 2009-4-28                                                       *
 *                                                                          *
 * Description:                                                             *
 *  dispatcher all things                                                   *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading;
using Disappearwind.MobileService.FetionService;

namespace Disappearwind.MobileService.MobileMainService
{
    /// <summary>
    /// dispatcher all things
    /// </summary>
    public class MainDispatcher
    {
        /// <summary>
        /// Mobile user info
        /// </summary>
        public static MoileUserInfo CurrentMobileUserInfo = MoileUserInfo.GetConfiMoileUserInfo();
        /// <summary>
        /// List to do something.
        /// depend ToDo model class
        /// </summary>
        public static ToDoList TODOList = new ToDoList();
        /// <summary>
        /// Default constructor.do some services
        /// </summary>
        public MainDispatcher()
        {
            TODOList.LoadFromXmlFile();
            //add service thread
            SendMessageServcie();
            SaveMessageService();
        }
        /// <summary>
        /// Show friend infomation message
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowInfoMessage(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Use thread to run send message method
        /// </summary>
        private void SendMessageServcie()
        {
            Thread t = new Thread(new ThreadStart(SendToDoMessage));
            t.Start();
        }
        /// <summary>
        /// Send ToDo Message to mobile
        /// </summary>
        public void SendToDoMessage()
        {
            while (true)
            {
                foreach (var item in TODOList)
                {
                    if (item.IsEqualTime(item.Time,DateTime.Now))
                    {
                        FetionMainService.SendMessage(CurrentMobileUserInfo.Number,
                            CurrentMobileUserInfo.Password, CurrentMobileUserInfo.Number, item.Content);
                        TODOList.DoneItem(item);
                    }
                    Thread.Sleep(new TimeSpan(99));
                }
                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// Save message to file
        /// </summary>
        private void SaveMessageService()
        {
            Thread t = new Thread(new ThreadStart(delegate { while (true) { TODOList.SaveToXmlFile(); Thread.Sleep(10000); } }));
            t.Start();
        }
    }
}
