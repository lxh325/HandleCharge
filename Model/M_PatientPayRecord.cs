using SqlSugar;

namespace Model
{
    [SugarTable("M_PatientPayRecord")]
    public class M_PatientPayRecord
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "订单号", IsPrimaryKey = true)]
        public string 订单号 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "支付交易号")]
        public string 支付交易号 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "任务编码")]
        public string 任务编码 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "人员工号")]
        public string 人员工号 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "付款帐号")]
        public string 付款帐号 { get; set; }
        /// <summary>
        ///  
        /// 默认值: ((0))
        ///</summary>
        [SugarColumn(ColumnName = "支付类型")]
        public int 支付类型 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "交易金额")]
        public decimal 交易金额 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "生成时间")]
        public DateTime 生成时间 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "结束时间")]
        public DateTime? 结束时间 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "退款原始单号")]
        public string 退款原始单号 { get; set; }
        /// <summary>
        ///  
        /// 默认值: ((0))
        ///</summary>
        [SugarColumn(ColumnName = "是否退款")]
        public bool 是否退款 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "交易结果")]
        public int 交易结果 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "备注")]
        public string 备注 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "用户流水号")]
        public string 用户流水号 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "发票号")]
        public string 发票号 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "病人姓名")]
        public string 病人姓名 { get; set; }
        /// <summary>
        ///  
        /// 默认值: ((-1))
        ///</summary>
        [SugarColumn(ColumnName = "撤销结果")]
        public int 撤销结果 { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "受理序号")]
        public int? 受理序号 { get; set; }
    }


}
