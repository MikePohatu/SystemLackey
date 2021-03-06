﻿//    BaseMessaging.cs: Base class for tasks with common methods
//    Copyright (C) 2015 Mike Pohatu

//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; version 2 of the License.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License along
//    with this program; if not, write to the Free Software Foundation, Inc.,
//    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.


using System;
using SystemLackey.Core;

namespace SystemLackey.Core.Messaging
{
    public abstract class MessageSender : IMessageSender
    {
        public event MessagingEventHandler SendMessageEvent;

        //Log a new event. Check for empty event handler first
        public virtual void SendMessage(Object o, MessageEventArgs e)
        {
            MessagingEventHandler temp = SendMessageEvent;
            if (temp != null)
            { temp(o, e); }
        }
    }
}
