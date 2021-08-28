﻿using DimensionService.Models.RequestModels;
using DimensionService.Models.ResultModels;
using System.Collections.Generic;

namespace DimensionService.Service.Chat
{
    public interface IChatService
    {
        bool AddChat(AddChatModel data, out string message);

        bool GetChatColumnInfo(string userID, out List<ChatColumnInfoModel> chatColumnInfos, out string message);
    }
}