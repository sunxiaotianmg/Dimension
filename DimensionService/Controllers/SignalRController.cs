﻿using Dimension.Domain;
using DimensionService.Hubs;
using DimensionService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DimensionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : ControllerBase
    {
        private readonly IHubContext<InformHub> _hub;

        public SignalRController(IHubContext<InformHub> hub)
        {
            _hub = hub;
        }

        /// <summary>
        /// 公开通知
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        [Route("OpenInform")]
        [HttpPost]
        public WebResultModel OpenInform(string title, string message)
        {
            _hub.Clients.All.SendAsync(HubMessageType.Notification.ToString(), title, message);
            WebResultModel webResult = new()
            {
                State = true,
                Data = null,
                Message = "发送成功"
            };
            return webResult;
        }
    }
}
