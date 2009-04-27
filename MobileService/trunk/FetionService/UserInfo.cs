/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind                                                     *
 * Created: 2009-4-27                                                       *
 *                                                                          *
 * Description:                                                             *
 *   Fetion user information                                                *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disappearwind.MobileService.FetionService
{
    /// <summary>
    /// User info of fetion
    /// </summary>
    public class UserInfo
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
    }
}
