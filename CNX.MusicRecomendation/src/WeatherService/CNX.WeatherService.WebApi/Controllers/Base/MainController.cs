﻿using AutoMapper;
using CNX.WeatherService.Business.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNX.WeatherService.WebApi.Controllers.Base
{
    public class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        
        public MainController(IMapper mapper, INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool OperationIsValid()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationIsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            var notifications = _notifier.GetNotifications();
            return BadRequest(new
            {
                success = false,
                errors = notifications.Select(n => n.Message),
                excepetions = notifications.Select(n => n.InnerExceptionMessage)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErrorModelInvalid(modelState);
            return CustomResponse();
        }

        protected void NotifyErrorModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                Notify(errorMsg);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected void Notify(string message, string innerExceptionMsg)
        {
            _notifier.Handle(new Notification(message, innerExceptionMsg));
        }

        protected string GetJwtToken() => HttpContext.Request.Headers?["Authorization"].ToString()?.Substring(7);
        
    }
}