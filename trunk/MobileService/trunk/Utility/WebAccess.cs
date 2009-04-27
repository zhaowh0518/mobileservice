/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind                                                     *
 * Created: 2009-4-27                                                       *
 *                                                                          *
 * Description:                                                             *
 *   Access web.Copy from blogsolution,but less params                      *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Disappearwind.MobileService.Utility
{
    /// <summary>
    /// Access web url
    /// </summary>
    public class WebAccess
    {
        /// <summary>
        /// Request a url with data and return the url's response
        /// </summary>
        /// <param name="url">The request url</param>
        /// <returns>return response</returns>
        public static string GetRequest(string url)
        {
            try
            {
                string result = string.Empty;
                //request
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "Get";
                //get response
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
                result = sr.ReadToEnd();
                sr.Close();
                res.Close();

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
