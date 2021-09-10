﻿using DimensionService.Context;
using DimensionService.Models.DimensionModels;
using System.Collections.Generic;
using System.Linq;

namespace DimensionService.Dao.ChatMessages
{
    public class ChatMessagesDAO : IChatMessagesDAO
    {
        public List<ChatMessagesModel> GetChatMessages(string chatID)
        {
            using DimensionContext context = new();
            return context.ChatMessages.Where(item => item.ChatID == chatID).ToList();
        }

        public bool AddMessage(ChatMessagesModel message)
        {
            using DimensionContext context = new();
            context.ChatMessages.Add(message);
            return context.SaveChanges() > 0;
        }
    }
}
