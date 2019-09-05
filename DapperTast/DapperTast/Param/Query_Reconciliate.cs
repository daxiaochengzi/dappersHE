using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{/// <summary>
/// 
/// </summary>
    public class Query_Reconciliate
    {/// <summary>
     /// 对账类型(1-挂号、2-门诊、3-住院)
     /// </summary>
        public int BusinessType { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string StartAt { get; set; }
        /// <summary>
        /// EndAt
        /// </summary>
        [Display(Name = "结束时间")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string EndAt { get; set; }
        /// <summary>
        /// 明细列表
        /// </summary>
        [Display(Name = "明细列表")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public List<OrderDetailListcs> OrderDetailList { get; set; }
    }
}
