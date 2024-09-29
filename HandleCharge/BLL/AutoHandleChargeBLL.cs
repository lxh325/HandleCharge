using DAL;
using DAL.Helper;
using System.Numerics;
using System.Timers;

namespace HandleCharge.BLL
{
    public class AutoHandleChargeBLL
    {
        private System.Timers.Timer myTimer = null; //时钟   
        public void Start()
        {
            int pollingTime = ConfigHelper.pollingTime;
            if (pollingTime > 0)
            {
                LogHelper.WriteInfo("开始执行处理支付记录表与上传收费子表订单号不匹配程序，每" + pollingTime + "分钟轮询一次。");
                myTimer = new System.Timers.Timer(pollingTime * 60 * 1000);
                myTimer.Elapsed += new ElapsedEventHandler(AdjustCharge);
                myTimer.AutoReset = true;
                AdjustCharge(null,null);//程序启动时执行
                myTimer.Enabled = true;
            }
        }
        private async void AdjustCharge(object? sender, ElapsedEventArgs e)
        {
            try
            {
                var list = new AutoHandleChargeDAL().GetPayRecordList(ConfigHelper.StartTaskCode);
                if (list != null)
                {
                    var listCount= list.Count;
                    int notHaveChargeCount = 0;
                    int ExecuteCount = 0;
                    var RepeatPayCount = 0;
                    foreach (var pay in list)
                    {
                        if (pay.Detail == null)
                        {
                            notHaveChargeCount++;
                            //联表查询应该不会查询到detail为null的情况
                            LogHelper.WriteWarn("任务编码【" + pay.任务编码 + "】未上传收费，请联系财务处理！");
                        }
                        else
                        {
                            var result= await new AutoHandleChargeDAL().AdjustChargeDetail(pay);
                            if (result == -1)
                            {
                                RepeatPayCount++;
                            }
                            else
                            {
                                ExecuteCount += result;
                            }
                        }
                    }
                    LogHelper.WriteInfo("本次查询共"+ listCount + "条异常数据，其中已处理收费子表"+ ExecuteCount+ "行，包含多次支付成功记录" + RepeatPayCount + "条，未上传收费"+ notHaveChargeCount + "条");
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AutoHandleCharge/AdjustCharge:急救收费处理异常程序异常：" + ex.Message);
            }
        }
    }
}
