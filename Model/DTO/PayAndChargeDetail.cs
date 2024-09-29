using SqlSugar;
using System;

namespace Model.DTO
{
    public class PayAndChargeDetail:M_PatientPayRecord
    {
        public M_PatientChargeDetail? Detail { get; set; }
    }
}
