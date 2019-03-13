namespace BinXiangHealth.EMT.Hosp.ProxyApi
{
    public interface IHospProxyRequestModel//<TRequestBody>
    {
        (string code, string json) ConvertToHospRequest();

        //TRequestBody GetRequestBody();
    }

    public interface IHospProxyResponseModel
    {
        int GetResponseCode();

        string GetResponseMessage();

        bool IsSuccess { get; }
    }
}
