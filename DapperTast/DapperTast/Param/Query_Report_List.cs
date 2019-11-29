using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DapperTast.Param
{/// <summary>
/// 
/// </summary>
    public class Query_Report_List
    {    
        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name = "开始时间")]
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
        /// 居民健康卡主索引
        /// </summary>
        [Display(Name = "居民健康卡主索引")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string MindexId { get; set; }
        /// <summary>
        /// 证件类别
        /// </summary>
        [Display(Name = "证件类别")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Display(Name = "证件号码")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdNo { get; set; }
        /// <summary>
        /// HIS报告ID列表
        /// </summary>
        public List<string> ReportIds { get; set; } = null;
    }
}
