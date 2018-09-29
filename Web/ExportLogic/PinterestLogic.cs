using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarketOMatic.ExportLogic.PinterestBoardCreateModel;

namespace MarketOMatic.ExportLogic
{
    class PinterestLogic
    {
        string accessToken;

        public PinterestLogic(string token)
        {
            accessToken = token;
        }

        public string Me()
        {
            var client = new RestClient("https://api.pinterest.com/v1/me/?access_token=" + accessToken);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string CreateBoard(string name, string description)
        {

            var requestObject = new BoardCreateRequest();
            requestObject.name = name;
            requestObject.description = description;

            var client = new RestClient("https://api.pinterest.com/v1/boards/?access_token=" + accessToken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(requestObject);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GetBoardInfo(string boardId)
        {
            var client = new RestClient("https://api.pinterest.com/v1/boards/"+ boardId + "/?access_token="+ accessToken + "&fields=creator%2Ccreated_at%2Ccounts%2Cdescription%2Cid%2Cimage%2Cname%2Cprivacy%2Creason%2Curl");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GetBoardPins(string boardId)
        {
            var client = new RestClient("https://api.pinterest.com/v1/boards/" + boardId + "/pins/?access_token=" + accessToken);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GetMyBoards()
        {
            var client = new RestClient("https://api.pinterest.com/v1/me/boards/?access_token=" + accessToken);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GetPinDetails(string pinId)
        {
            var client = new RestClient("https://api.pinterest.com/v1/pins/" + pinId + "/?access_token=" + accessToken + "&fields=id%2Clink%2Cnote%2Curl%2Cattribution%2Cimage%2Cboard%2Cmedia%2Ccolor%2Cmetadata%2Ccounts%2Ccreated_at%2Ccreator%2Coriginal_link");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }


    }
}
