using DAL.Helper;
using Model;
using Model.DTO;
using SqlSugar;

namespace DAL
{
    public class AutoHandleChargeDAL
    {
        
        public List<PayAndChargeDetail> GetPayRecordList(string start)
        {
            try
            {
                var list=SqlSugarDbContext.MainDbContext.Queryable<M_PatientPayRecord>()
                     .LeftJoin<M_PatientChargeDetail>((a,b)=>a.任务编码==b.TaskCode&& a.受理序号 == b.PatientOrder && a.支付类型 == b.ChargeType)
                     .Where((a,b) => a.交易结果==1&&a.是否退款==false)//退款的不处理
                     .Where((a,b)=>a.订单号!=b.OrderNumber)
                     .Where( "a.任务编码>=@id", new {id=start })
                     .OrderBy(a => a.任务编码)
                     .Select((a, b) => new PayAndChargeDetail
                     {
                         任务编码 = a.任务编码.SelectAll(),
                         Detail=b
                     })
                     .ToList();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AutoHandleChargeDAL/GetPayRecordList:获取支付记录列表DAL出错：" + ex.Message);
                return null;
            }
        }
        public async Task<int> AdjustChargeDetail(PayAndChargeDetail payInfo)
        {
            try
            {
                int Excount = 0;
                await SqlSugarDbContext.MainDbContext.AsTenant().BeginTranAsync();
                var payCount = SqlSugarDbContext.MainDbContext.Queryable<M_PatientPayRecord>()
                   .Where(x => x.任务编码 == payInfo.任务编码 && x.受理序号 == payInfo.受理序号 && x.支付类型 == payInfo.支付类型&&x.交易结果==1&&x.是否退款==false)
                   .Count();
                //含多条成功支付记录的，不处理
                if (payCount > 1)
                {
                    LogHelper.WriteWarn("任务编码【" + payInfo.任务编码 + "】包含多条支付成功记录，请联系财务处理！");
                    return -1;
                }
                //修改收费子表------OrderNumber  可能也会有多条同一支付类型多次收费的记录（部分退款？）
                Excount += await SqlSugarDbContext.MainDbContext.Updateable<M_PatientChargeDetail>()
                    .SetColumns(x => x.OrderNumber==payInfo.订单号)
                    .Where(x => x.TaskCode==payInfo.任务编码&&x.PatientOrder==payInfo.受理序号&&x.ChargeType==payInfo.支付类型)
                    .ExecuteCommandAsync();

                //修改收费子表log表
                await SqlSugarDbContext.MainDbContext.Updateable<M_PatientChargeDetailLog>()
                   .SetColumns(x => x.OrderNumber == payInfo.订单号)
                   .Where(x => x.TaskCode == payInfo.任务编码 && x.PatientOrder == payInfo.受理序号 && x.ChargeType == payInfo.支付类型&&x.Isvalid==true)
                   .ExecuteCommandAsync();

                var nowInfo= SqlSugarDbContext.MainDbContext.Queryable<M_PatientChargeDetail>()
                    .Where(x=>x.TaskCode == payInfo.任务编码 && x.PatientOrder == payInfo.受理序号 && x.ChargeType == payInfo.支付类型)
                    .First();
                await SqlSugarDbContext.MainDbContext.AsTenant().CommitTranAsync();
                LogHelper.WriteInfo("任务编码【" + payInfo.任务编码 + "】收费子表订单号*"+ Excount + "修改成功！原收费子表实体:" + ObjectToJson.GetObjectToJson(payInfo.Detail) + "，现收费子表实体：" + ObjectToJson.GetObjectToJson(nowInfo));
                return Excount;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AutoHandleChargeDAL/AdjustChargeDetail:修改收费子表DAL出错：" + ex.Message);
                await SqlSugarDbContext.MainDbContext.AsTenant().RollbackTranAsync();
                return 0;
            }
        }
    }
}
