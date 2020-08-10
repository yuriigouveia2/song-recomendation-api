﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.WeatherService.Business.Util
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public Notification(string message, string innerExceptionMsg)
        {
            Message = message;
            InnerExceptionMessage = innerExceptionMsg;
        }

        public string Message { get; }
        public string InnerExceptionMessage { get; }
    }
}