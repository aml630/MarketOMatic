using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOMatic.ExportLogic
{
    class PinterestLogic
    {
        public string AutoPin()
        {
            var accessToken = "AYU2Mge9YgxVP9EdfMz-fQUcgV1bFRCagVrgOUFErq7vBsA-CgAAAAA";
            var boardNum = "850687885802909063";

            var url = "Url Link";
            var imageUrl = "Image URl";
            var notes = "Title of image";


            IRestResponse response = Pin(accessToken, boardNum, url, imageUrl, notes);

            return response.Content;
        }

        private static IRestResponse Pin(string accessToken, string boardNum, string url, string imageUrl, string notes)
        {
            var client = new RestClient("https://api.pinterest.com/v1/pins/?access_token=" + accessToken + "&fields=id%2Clink%2Cnote%2Curl");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"board\"\r\n\r\n" + boardNum + "\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"link\"\r\n\r\n" + url + "\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"image_url\"\r\n\r\n" + imageUrl + "\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"note\"\r\n\r\n" + notes + "\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
