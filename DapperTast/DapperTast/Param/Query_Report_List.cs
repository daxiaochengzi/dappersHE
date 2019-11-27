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
    {/// <summary>
     /// 电子健康卡id
     /// </summary>

        public string EhealthCardId { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 居民健康卡主索引
        /// </summary>
        public string MindexId { get; set; }
        /// <summary>
        /// 证件类别
        /// </summary>
        [Display(Name = "证件类别")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdType { get; set; }
        /// <summary>
        /// HIS报告ID列表
        /// </summary>
        public List<string> ReportIds { get; set; }
    }
}
