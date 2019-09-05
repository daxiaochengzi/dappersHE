using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{/// <summary>
/// 
/// </summary>
    public class Get_His_Scheduling_List_Param
    {/// <summary>
        /// 科室代码
        /// </summary>
        public string DepartmentCode { get; set; }
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
    }
}
