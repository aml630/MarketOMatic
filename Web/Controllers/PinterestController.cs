using MarketOMatic.ExportLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PinterestController : Controller
    {
        // GET: Pinterest
        public string Me()
        {
            using (var db = new MarketOMaticEntities())
            {
                var siteToken = db.SiteTokens.Where(x => x.SiteTokenId == 2).FirstOrDefault();

                var pinLogic = new PinterestLogic(siteToken.Value);

                return pinLogic.Me();
            }
        }

        public string MyBoards()
        {
            using (var db = new MarketOMaticEntities())
            {
                var siteToken = db.SiteTokens.Where(x => x.SiteTokenId == 2).FirstOrDefault();

                var pinLogic = new PinterestLogic(siteToken.Value);

                return pinLogic.GetMyBoards();
            }
        }

        public string GetExportBoard()
        {
            using (var db = new MarketOMaticEntities())
            {
                var siteToken = db.SiteTokens.Where(x => x.SiteTokenId == 2).FirstOrDefault();

                var boardNumber = db.PinterestBoards.Where(x => x.SiteId == siteToken.SiteId).FirstOrDefault();

                var pinLogic = new PinterestLogic(siteToken.Value);

                return pinLogic.GetBoardPins(boardNumber.BoardNumber).ToString();
            }
        }

        public string TweetPinFromBoard()
        {
            using (var db = new MarketOMaticEntities())
            {
                var siteToken = db.SiteTokens.Where(x => x.SiteTokenId == 2).FirstOrDefault();

                var boardNumber = db.PinterestBoards.Where(x => x.SiteId == siteToken.SiteId).FirstOrDefault();

                var pinLogic = new PinterestLogic(siteToken.Value);

                return pinLogic.SaveBoardPins(boardNumber.BoardNumber);
            }
        }

        public PinterestPinDetailsModel.PinDetailsResponse GetPinDetails()
        {
            using (var db = new MarketOMaticEntities())
            {
                var siteToken = db.SiteTokens.Where(x => x.SiteTokenId == 2).FirstOrDefault();

                var pinLogic = new PinterestLogic(siteToken.Value);

                var pinId = "733453489290830416";

                return pinLogic.GetPinDetails(pinId);
            }
        }

        public PinterestPinDetailsModel.PinDetailsResponse PinImageToBoard()
        {
            using (var db = new MarketOMaticEntities())
            {
                var siteToken = db.SiteTokens.Where(x => x.SiteTokenId == 2).FirstOrDefault();

                var pinLogic = new PinterestLogic(siteToken.Value);

                var pinId = "479914904038569690";

                var pinDetailOutput = pinLogic.GetPinDetails(pinId);

                return pinDetailOutput;
            }
        }
    }
}