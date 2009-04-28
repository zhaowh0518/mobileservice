/****************************************************************************
 * Copyright (C) Disappearwind. All rights reserved.                        *
 *                                                                          *
 * Author: disapearwind                                                     *
 * Created: 2009-4-28                                                       *
 *                                                                          *
 * Description:                                                             *
 *  To do structor                                                          *
 *                                                                          *
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disappearwind.MobileService.MobileMainService
{
    /// <summary>
    /// To do structor
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
    }
}
