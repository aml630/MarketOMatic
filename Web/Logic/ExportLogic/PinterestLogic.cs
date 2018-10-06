using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web;
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

        public PinterestBoardPinListModel.PinListResponse GetBoardPins(string boardId)
        {
            var client = new RestClient("https://api.pinterest.com/v1/boards/" + boardId + "/pins/?access_token=" + accessToken);
            var request = new RestRequest(Method.GET);
            var response = client.Execute<PinterestBoardPinListModel.PinListResponse>(request);
            return response.Data;
        }

        public string GetMyBoards()
        {
            var client = new RestClient("https://api.pinterest.com/v1/me/boards/?access_token=" + accessToken);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public PinterestPinDetailsModel.PinDetailsResponse GetPinDetails(string pinId)
        {
            var client = new RestClient("https://api.pinterest.com/v1/pins/" + pinId + "/?access_token=" + accessToken + "&fields=id%2Clink%2Cnote%2Curl%2Cattribution%2Cimage%2Cboard%2Cmedia%2Ccolor%2Cmetadata%2Ccounts%2Ccreated_at%2Ccreator%2Coriginal_link");
            var request = new RestRequest(Method.GET);
            var response = client.Execute<PinterestPinDetailsModel.PinDetailsResponse>(request);
            return response.Data;
        }

        public string SaveBoardPins(string boardId)
        {
            var boardList = GetBoardPins(boardId);

            foreach(var pin in boardList.data)
            {
                var pinDetails = GetPinDetails(pin.id).data;

                CreateNewPin(pinDetails);
            }

            return "success";
        }

        private static void CreateNewPin(PinterestPinDetailsModel.Data pinDetails)
        {
            using (var db = new MarketOMaticEntities())
            {
                var newPinEntrsy = new PinterestPinDetail()
                {
                    dataattribution = "",
                    datacreatorfirst_name = pinDetails.creator.first_name,
                    datacreatorlast_name = pinDetails.creator.last_name,
                    datacreatorid = int.Parse(pinDetails.creator.id),
                    datacreatorurl = pinDetails.creator.url,
                    dataurl = pinDetails.url,
                    datamediatype = pinDetails.media.type,
                    datacreated_at = pinDetails.created_at.ToString(),
                    dataid = int.Parse(pinDetails.id),
                    datanote = pinDetails.note,
                    datacolor = pinDetails.color,
                    datalink = pinDetails.link,
                    databoardurl = pinDetails.board.url,
                    databoardid = int.Parse(pinDetails.board.id),
                    databoardname = pinDetails.board.name,
                    dataimageoriginalurl = pinDetails.image.original.url,
                    dataimageoriginalwidth = pinDetails.image.original.width,
                    dataimageoriginalheight = pinDetails.image.original.height,
                    datacountssaves = pinDetails.counts.saves,
                    datacountscomments = pinDetails.counts.comments,
                    dataoriginal_link = pinDetails.original_link
                };

                db.PinterestPinDetails.Add(newPinEntrsy);
                db.SaveChanges();
            }
        }
    }
}
