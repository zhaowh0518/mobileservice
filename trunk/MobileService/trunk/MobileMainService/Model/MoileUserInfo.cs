/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind                                                     *
 * Created: 2009-4-27                                                       *
 *                                                                          *
 * Description:                                                             *
 *   User information                                                       *
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
    /// User info of fetion
    /// </summary>
    public class MoileUserInfo
    {
        /// <summary>
        /// Mobile number
        /// </summary>
        public long Number { get; set; }
        /// <summary>
        /// Display name of user
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Password to login fetion
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Get MobileUserInfo from appconfig.xaml
        /// </summary>
        /// <returns></returns>
        public static MoileUserInfo GetConfiMoileUserInfo()
        {
            MoileUserInfo user = new MoileUserInfo();
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("AppConfig.xaml", UriKind.RelativeOrAbsolute);
            foreach (var key in rd.Keys)
            {
                user = rd[key] as MoileUserInfo;
            }
            return user;
        }
    }
}
