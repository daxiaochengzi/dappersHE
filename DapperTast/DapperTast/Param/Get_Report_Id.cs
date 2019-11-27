using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{/// <summary>
/// 
/// </summary>
    public class Get_Report_Id
    {/// <summary>
     /// 报告类型
     /// </summary>
        [Display(Name = "报告类型")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string ReportType { get; set; }
        /// <summary>
        /// HIS报告ID
        /// </summary>
        [Display(Name = "HIS报告ID")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string ReportId { get; set; }
    }
}
