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

namespace Disappearwind.MobileService.MobileMainService
{
    /// <summary>
    /// dispatcher all things
    /// </summary>
    public class MainDispatcher
    {
        /// <summary>
        /// List to do something.
        /// depend ToDo model class
        /// </summary>
        public static List<ToDo> ToDoList = new List<ToDo>();
        /// <summary>
        /// Show friend infomation message
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowInfoMessage(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
