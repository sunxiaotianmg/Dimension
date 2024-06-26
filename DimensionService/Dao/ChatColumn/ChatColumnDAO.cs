﻿using DimensionService.Context;
using DimensionService.Models.DimensionModels;

namespace DimensionService.Dao.ChatColumn
{
    public class ChatColumnDAO : IChatColumnDAO
    {
        private static readonly Dictionary<string, object> addChatLocks = new();
        private static readonly object addChatLock = new();

        public bool AddChatColumn(string userID, string friendID, string chatID)
        {
            object bodyLock;
            lock (addChatLock)
            {
                string str = $"{userID}-{friendID}-{chatID}";
                if (!addChatLocks.TryGetValue(str, out bodyLock))
                {
                    bodyLock = new object();
                    addChatLocks.TryAdd(str, bodyLock);
                }
            }
            lock (bodyLock)
            {
                using DimensionContext context = new();
                if (!context.ChatColumn.Where(item => item.UserID == userID && item.FriendID == friendID && item.ChatID == chatID).Any())
                {
                    context.ChatColumn.Add(new ChatColumnModel
                    {
                        UserID = userID,
                        FriendID = friendID,
                        ChatID = chatID
                    });
                    context.SaveChanges();
                }
                return true;
            }
        }

        public List<ChatColumnModel> GetChatColumns(string userID)
        {
            using DimensionContext context = new();
            return context.ChatColumn.Where(item => item.UserID == userID).ToList();
        }

        public bool ChatColumnExist(string userID, string chatID)
        {
            using DimensionContext context = new();
            return context.ChatColumn.Where(item => item.UserID == userID && item.ChatID == chatID).Any();
        }
    }
}
