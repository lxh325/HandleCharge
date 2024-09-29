using SqlSugar;

namespace Model
{
    [SugarTable("M_PatientChargeDetail")]
    public class M_PatientChargeDetail
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "TaskCode", IsPrimaryKey = true)]
        public string TaskCode { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "PatientOrder", IsPrimaryKey = true)]
        public int PatientOrder { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ChargeOrder", IsPrimaryKey = true)]
        public int ChargeOrder { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ChargeDate")]
        public DateTime? ChargeDate { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "PaidMoney")]
        public decimal? PaidMoney { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ChargeType")]
        public int? ChargeType { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "OrderNumber")]
        public string OrderNumber { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "IFRefund")]
        public bool? IFRefund { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "IFAccountCheck")]
        public bool? IFAccountCheck { get; set; }
    }

}
