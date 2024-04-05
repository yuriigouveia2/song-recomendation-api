using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Logging;
using CNX.UserService.Business.Utils;
using CNX.UserService.Business.Interfaces;
using CNX.UserService.Model.Entities;

namespace CNX.UserService.WebApi.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        private readonly IUserBusiness _userBusiness;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        public MainController(INotifier notifier, IUserBusiness userBusiness)
        {
            _notifier = notifier;
            _userBusiness = userBusiness;
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

        protected User IdentifyUser()
        {
            try
            {
                var tokenJwt = HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
                var cpf = new JwtSecurityTokenHandler().ReadJwtToken(tokenJwt).Claims.ToList()
                           .Find(x => x.Type == JwtRegisteredClaimNames.UniqueName).Value;
                return _userBusiness.GetbyCpf(cpf);
            }
            catch (Exception e)
            {
                throw new Exception("It was not possible to identify the user logged in.", e);
            }
        }
    }
}
