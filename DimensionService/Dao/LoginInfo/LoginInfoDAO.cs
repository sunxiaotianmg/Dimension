﻿using Dimension.Domain;
using DimensionService.Common;
using DimensionService.Context;
using DimensionService.Models.DimensionModels;

namespace DimensionService.Dao.LoginInfo
{
    public class LoginInfoDAO : ILoginInfoDAO
    {
        public bool UserLogin(string userID, UseDevice useDevice, DateTime dateTime)
        {
            using DimensionContext context = new();
            if (context.LoginInfo.Where(item => item.UserID == userID && item.UseDevice == useDevice && item.Effective).FirstOrDefault() is LoginInfoModel loginInfo)
            {
                loginInfo.Effective = false;
                loginInfo.UpdateTime = dateTime;
            }
            context.LoginInfo.Add(new LoginInfoModel
            {
                UserID = userID,
                Token = $"{ClassHelper.GetRandomString(8)}-{ClassHelper.GetRandomString(8)}-{ClassHelper.GetRandomString(8)}-{ClassHelper.GetRandomString(8)}",
                Effective = true,
                UseDevice = useDevice,
                CreateTime = dateTime,
                UpdateTime = dateTime
            });
            return context.SaveChanges() > 0;
        }

        public LoginInfoModel ValidLoginInfo(string userID, UseDevice useDevice)
        {
            using DimensionContext context = new();
            return context.LoginInfo.Where(item => item.UserID == userID && item.UseDevice == useDevice && item.Effective).FirstOrDefault();
        }

        public static bool CheckToken(string userID, string token, UseDevice useDevice)
        {
            using DimensionContext db = new();
            return db.LoginInfo.Where(item => item.UserID == userID && item.Token == token && item.Effective && item.UseDevice == useDevice).Any();
        }
    }
}
