using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{/// <summary>
/// 3.1.4 	预约挂号锁定
/// </summary>
    public class His_Order_Lock
    {/// <summary>
     /// His挂号排班记录id
     /// </summary>
        [Display(Name = "His挂号排班记录id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string Id { get; set; }
        /// <summary>
        /// 预约挂号单号
        /// </summary>
        [Display(Name = "预约挂号单号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
      
        public string OrderNo { get; set; }
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
        /// 病人姓名
        /// </summary>
        [Display(Name = "病人姓名")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string Name { get; set; }
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
        /// 性别
        /// </summary>

        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [Display(Name = "生日")]
        [Required(ErrorMessage = "{0}不能为空!!!")]

        public string Birthday { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        [Display(Name = "民族")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string Nation { get; set; }
        /// <summary>
        /// 国籍
        /// </summary>
        [Display(Name = "国籍")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string Nationality { get; set; }
        /// <summary>
        /// 户籍地址
        /// </summary>
        public string Domicile { get; set; }
        /// <summary>
        /// 居住地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 婚姻状态代码
        /// </summary>
        public string Maritalstatus { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Cellphone { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }

    }
}
