using SqlSugar;

namespace Model
{
    [SugarTable("M_PatientChargeDetailLog")]
    public class M_PatientChargeDetailLog
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "TaskCode")]
        public string TaskCode { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "PatientOrder")]
        public int PatientOrder { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ChargeOrder")]
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
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Isvalid")]
        public bool? Isvalid { get; set; }
    }

}
