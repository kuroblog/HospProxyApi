using Agebull.Common.Ioc;
using Agebull.ZeroNet.ZeroApi;
using BinXiangHealth.EMT.Hosp.ProxyApi.Models;
using Gboxt.Common.DataModel;
using System.Linq;
using HModels = BinXiangHealth.EMT.Hosp.ProxyApi.Models.HOSP.JHWR;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Controllers.JHWR
{
    public class CostController : ApiController
    {
        private readonly IProxyService proxyService = IocHelper.Create<IProxyService>();

        [Route("api/v1/cost/list")]
        public ApiArrayResult<CostListResponse> CostList(CostListRequest request) => this.DoApiArrayResult(
            proxyService.DoTrans<HModels.Hosp4002Request, HModels.Hosp4002Response, CostListRequest, CostListResponse[]>(
                request,
                req => new HModels.Hosp4002Request
                {
                    clinicNo = req.id,
                    patientCard = req.cardNo
                },
                res => res.data?.Select(p => new CostListResponse
                {
                    feeCode = p.Fee_Code,
                    exeDoctDept = p.DocDept_Name,
                    docName = p.Doc_Name,
                    drugFlag = p.Drug_Flag,
                    exeDeptName = p.Exec_DeptName,
                    itemCode = p.Item_Code,
                    itemName = p.Item_Name,
                    moDate = p.Mo_Date,
                    payFlag = p.Pay_Flag,
                    qty = p.Qty,
                    id = p.Recipe_Key,
                    recipeNo = p.Recipe_No,
                    recipeSeq = p.SeqNo,
                    cost = p.Tot_Cost,
                    transType = p.Trans_Type,
                    unit = p.UNIT,
                    unitPrice = p.Unit_Price,
                    invoiceNo = p.InvoiceNo
                })?.ToArray()));

        [Route("api/v1/cost/settle")]
        public ApiResult<CostSettleResponse> CostSettle(CostSettleRequest request) => this.DoApiResult(
            proxyService.DoTrans<HModels.Hosp4004Request, HModels.Hosp4004Response, CostSettleRequest, CostSettleResponse>(
                request,
                req => new HModels.Hosp4004Request
                {
                    clinicNo = req.clinicNo,
                    feeSource = req.source,
                    ownCost = req.ownCost,
                    payCost = req.payCost,
                    pubCost = req.pubCost,
                    realName = req.name,
                    recipe_Key = req.keys,
                    totCost = req.totCost,
                    pactCode = req.pactCode,
                    tradeNo = req.tradeNo,
                    Recipe_CF = req.recipeKeys
                },
                res => new CostSettleResponse
                {
                    windowNo = res.data?.windowNo,
                    invoiceNo = res.data?.invoiceNo,
                    invoiceSeq = res.data?.invoiceSeq,
                    siTradeNo = res.data?.siTradeNo,
                    vancy = res.data?.vancy,
                    deptName = res.data?.deptname,
                    feeItems = res.data?.FeeItemList
                }));

        [Route("api/v1/cost/pre")]
        public ApiResult<CostPreSettleResponse> CostPreSettle(CostPreSettleRequest request)
        {
            return this.DoApiResult(
                proxyService.DoTrans<HModels.Hosp4003Request, HModels.Hosp4003Response, CostPreSettleRequest, CostPreSettleResponse>(
                    request,
                    p => new HModels.Hosp4003Request
                    {
                        clinicNo = p.clinicNo,
                        operCode = p.operCode,
                        realName = p.name,
                        recipe_Key = p.recipeKey
                    },
                    p => new CostPreSettleResponse
                    {
                        ownCost = p.data?.ownCost,
                        payCost = p.data?.payCost,
                        pubCost = p.data?.pubCost,
                        totCost = p.data?.totCost
                    }));
        }
    }
}
