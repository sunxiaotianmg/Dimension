﻿using Dimension.Domain;
using System.ComponentModel.DataAnnotations;

namespace DimensionService.Models.RequestModels
{
    public class CreateCallModel
    {
        [Display(Name = "用户ID")]
        public string UserID { get; set; }

        [Display(Name = "成员")]
        [Required(ErrorMessage = "成员不能为空")]
        public List<string> Member { get; set; }

        [Display(Name = "通讯类型")]
        [Required(ErrorMessage = "通讯类型不能为空")]
        public CallType CallType { get; set; }

        [Display(Name = "使用设备")]
        public UseDevice UseDevice { get; set; }
    }
}
