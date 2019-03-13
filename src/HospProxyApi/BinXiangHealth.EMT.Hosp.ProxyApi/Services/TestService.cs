using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.ServiceModel;
using System.Xml;

namespace BinXiangHealth.EMT.Hosp.ProxyApi.Services
{
    public interface ITestService
    {
        Controllers.TestResponseDto GetPreRegisters(dynamic param);

        Controllers.TestResponseDto GetDeptTree(dynamic param);

        Controllers.TestResponseDto GetRegisters(dynamic param);

        Controllers.TestResponseDto Test(string code, dynamic param);

        string Hello { get; }
    }

    public class TestService : ITestService
    {
        private readonly string url = string.Empty;

        public TestService(IOptions<HospProxySettings> proxySettings)
        {
            url = proxySettings.Value.Url;
        }

        public string Hello => $"{DateTime.Now.ToString()}: Hello.";

        private Controllers.TestResponseDto doService(string code, dynamic param, Func<AppServiceCommonSoap, (string code, string json), string> svc)
        {
            var result = new Controllers.TestResponseDto { code = code };

            try
            {
                var binding = new BasicHttpBinding
                {
                    ReceiveTimeout = new TimeSpan(0, 0, 60),
                    SendTimeout = new TimeSpan(0, 2, 0),
                    MaxReceivedMessageSize = int.MaxValue,
                    MaxBufferPoolSize = int.MaxValue,
                    MaxBufferSize = int.MaxValue,
                    ReaderQuotas = XmlDictionaryReaderQuotas.Max
                };

                binding.Security.Mode = BasicHttpSecurityMode.None;

                var endpoint = new EndpointAddress(url);

                var soapFactory = new ChannelFactory<AppServiceCommonSoap>(binding, endpoint);
                var soapClient = soapFactory.CreateChannel();

                string json = JsonConvert.SerializeObject(param);
                // var soapResult = soapClient.GetDepartmentTreeAsync(json).Result;
                var soapResult = svc.Invoke(soapClient, (result.code, json));

                result.result = soapResult;

                result.response = JsonConvert.DeserializeObject<dynamic>(soapResult.FormatHospResult());
                result.request = param;
            }
            catch (Exception ex)
            {
                result.error = JsonConvert.DeserializeObject<string[]>(ex.GetErrorMessages().ToJson());
            }

            return result;
        }

        private Func<AppServiceCommonSoap, (string code, string json), string> getPreRegisters = (soap, req) => soap.GetBookingListAsync(req.json).Result;

        public Controllers.TestResponseDto GetPreRegisters(dynamic param)
        {
            return doService("", param, getPreRegisters);
        }

        private Func<AppServiceCommonSoap, (string code, string json), string> getDeptTree = (soap, req) => soap.GetDepartmentTreeAsync(req.json).Result;

        public Controllers.TestResponseDto GetDeptTree(dynamic param)
        {
            return doService("", param, getDeptTree);
            // var result = new Controllers.TestResponseDto { code = "no code" };

            // try
            // {
            //     var binding = new BasicHttpBinding
            //     {
            //         ReceiveTimeout = new TimeSpan(0, 0, 60),
            //         SendTimeout = new TimeSpan(0, 2, 0),
            //         MaxReceivedMessageSize = int.MaxValue,
            //         MaxBufferPoolSize = int.MaxValue,
            //         MaxBufferSize = int.MaxValue,
            //         ReaderQuotas = XmlDictionaryReaderQuotas.Max
            //     };

            //     binding.Security.Mode = BasicHttpSecurityMode.None;

            //     var endpoint = new EndpointAddress(url);

            //     var soapFactory = new ChannelFactory<AppServiceCommonSoap>(binding, endpoint);
            //     var soapClient = soapFactory.CreateChannel();

            //     string json = JsonConvert.SerializeObject(param);
            //     var soapResult = soapClient.GetDepartmentTreeAsync(json).Result;

            //     result.result = soapResult;

            //     result.response = JsonConvert.DeserializeObject<dynamic>(soapResult.FormatHospResult());
            //     result.request = param;
            // }
            // catch (Exception ex)
            // {
            //     result.error = JsonConvert.DeserializeObject<string[]>(ex.GetErrorMessages().ToJson());
            // }

            // return result;
        }

        private Func<AppServiceCommonSoap, (string code, string json), string> getRegisters = (soap, req) => soap.GetRegisterListAsync(req.json).Result;

        public Controllers.TestResponseDto GetRegisters(dynamic param)
        {
            return doService("", param, getRegisters);
            // var result = new Controllers.TestResponseDto { code = "no code" };

            // try
            // {
            //     var binding = new BasicHttpBinding
            //     {
            //         ReceiveTimeout = new TimeSpan(0, 0, 60),
            //         SendTimeout = new TimeSpan(0, 2, 0),
            //         MaxReceivedMessageSize = int.MaxValue,
            //         MaxBufferPoolSize = int.MaxValue,
            //         MaxBufferSize = int.MaxValue,
            //         ReaderQuotas = XmlDictionaryReaderQuotas.Max
            //     };

            //     binding.Security.Mode = BasicHttpSecurityMode.None;

            //     var endpoint = new EndpointAddress(url);

            //     var soapFactory = new ChannelFactory<AppServiceCommonSoap>(binding, endpoint);
            //     var soapClient = soapFactory.CreateChannel();

            //     string json = JsonConvert.SerializeObject(param);
            //     var soapResult = soapClient.GetRegisterListAsync(json).Result;

            //     result.result = soapResult;

            //     result.response = JsonConvert.DeserializeObject<dynamic>(soapResult.FormatHospResult());
            //     result.request = param;
            // }
            // catch (Exception ex)
            // {
            //     result.error = JsonConvert.DeserializeObject<string[]>(ex.GetErrorMessages().ToJson());
            // }

            // return result;
        }

        private Func<AppServiceCommonSoap, (string code, string json), string> doTest = (soap, req) => soap.DoTransAsync(req.code, req.json).Result;

        public Controllers.TestResponseDto Test(string code, dynamic param)
        {
            return doService(code, param, doTest);
            // var result = new Controllers.TestResponseDto { code = code };

            // try
            // {
            //     var binding = new BasicHttpBinding
            //     {
            //         ReceiveTimeout = new TimeSpan(0, 0, 60),
            //         SendTimeout = new TimeSpan(0, 2, 0),
            //         MaxReceivedMessageSize = int.MaxValue,
            //         MaxBufferPoolSize = int.MaxValue,
            //         MaxBufferSize = int.MaxValue,
            //         ReaderQuotas = XmlDictionaryReaderQuotas.Max
            //     };

            //     binding.Security.Mode = BasicHttpSecurityMode.None;

            //     var endpoint = new EndpointAddress(url);

            //     var soapFactory = new ChannelFactory<AppServiceCommonSoap>(binding, endpoint);
            //     var soapClient = soapFactory.CreateChannel();

            //     string json = JsonConvert.SerializeObject(param);
            //     var soapResult = soapClient.DoTransAsync(code, json).Result;

            //     result.result = soapResult;

            //     result.response = JsonConvert.DeserializeObject<dynamic>(soapResult.FormatHospResult());
            //     result.request = param;
            // }
            // catch (Exception ex)
            // {
            //     result.error = JsonConvert.DeserializeObject<string[]>(ex.GetErrorMessages().ToJson());
            // }

            // return result;
        }
    }
}
