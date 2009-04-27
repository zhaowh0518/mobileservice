/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind                                                     *
 * Created: 2009-4-27                                                       *
 *                                                                          *
 * Description:                                                             *
 *   Fetion main service. call some fetion api provided by sms              *
 *   api:http://sms.api.bz/                                                 *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disappearwind.MobileService.FetionService
{
    /// <summary>
    /// Fetion main service
    /// </summary>
    public class FetionMainService
    {
        /// <summary>
        /// The api http address
        /// </summary>
        public static readonly string FetionAPI = "http://sms.api.bz/";

        /// <summary>
        /// Use fetion send message to a mobile
        /// </summary>
        /// <param name="sendNumber">sender mobile number</param>
        /// <param name="password">password for sender to login</param>
        /// <param name="reviceNumber">message revicer's mobile number</param>
        /// <param name="content">message content</param>
        public static void SendMessage(long sendNumber, string password, long reviceNumber, string content)
        {
            string requestURL = string.Format("http://sms.api.bz/fetion.php?username={0}&password={1}&sendto={2}&message={3}", 
                sendNumber, password, reviceNumber, content);
            Disappearwind.MobileService.Utility.WebAccess.GetRequest(requestURL);
        }
    }
}
