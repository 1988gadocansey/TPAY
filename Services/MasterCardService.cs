using RestSharp;

namespace TPAY.Services
{
    /*public class MasterCardService:IMasterCard
    {
        public void ProcessPayment()
        {
            var paramValue = "";
            var client = new RestClient("https://FirstLevelDomain/urlEndPoint.asmx?op=NameOfFunction");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Host", "DomainNameWithoutHttps");
            request.AddHeader("Content-Type", "text/xml");
            request.AddHeader("charset", "utf-8");
            request.AddHeader("SOAPAction", "\"http://DomainWithoutHttps/NameOfFunction\"");
            request.AddParameter("text/xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n  <soap:Body>\r\n    <NameOfFunction xmlns=\"http://domainName.com/\">\r\n      <ParameterYouWantToPass>"+ paramValue + "</clientId>\r\n  </soap:Body>\r\n</soap:Envelope>", ParameterType.RequestBody);
           // IRestResponse response = await client.ExecuteAsync(request);
            IRestResponse response =  client.Execute(request);
        }
    }*/
}