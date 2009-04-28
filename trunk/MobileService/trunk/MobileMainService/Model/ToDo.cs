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
    }
}
