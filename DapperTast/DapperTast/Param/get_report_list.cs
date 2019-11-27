﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{
    public class Get_Report_List
    {/// <summary>
     /// His挂号排班记录id
     /// </summary>
        [Display(Name = "His挂号排班记录id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string StartAt { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string EndAt { get; set; }

        /// <summary>
        /// 电子健康卡id
        /// </summary>
        [Display(Name = "电子健康卡id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string EhealthCardId { get; set; }
        /// <summary>
        /// 居民健康卡主索引id
        /// </summary>
        [Display(Name = "居民健康卡主索引id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string MindexId { get; set; }

        /// <summary>
        /// 证件类别
        /// </summary>
        [Display(Name = "证件类别")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdType { get; set; }

    }
}