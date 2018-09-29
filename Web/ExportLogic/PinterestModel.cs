using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOMatic.ExportLogic
{
    class PinterestMeModel
    {
        public class Data
        {
            public string url { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string id { get; set; }
        }

        public class MeResponse
        {
            public Data data { get; set; }
        }

    }

    class PinterestBoardCreateModel
    {
        public class BoardCreateRequest
        {
            public string name { get; set; }
            public string description { get; set; }
        }

        public class Data
        {
            public string url { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class BoardCreateResponse
        {
            public Data data { get; set; }
        }
    }

    class PinterestBoardInfoModel
    {
        public class Creator
        {
            public string url { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string id { get; set; }
        }

        public class __invalid_type__60x60
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Image
        {
            public __invalid_type__60x60 __invalid_name__60x60 { get; set; }
        }

        public class Counts
        {
            public int pins { get; set; }
            public int collaborators { get; set; }
            public int followers { get; set; }
        }

        public class Data
        {
            public string description { get; set; }
            public Creator creator { get; set; }
            public string url { get; set; }
            public DateTime created_at { get; set; }
            public string privacy { get; set; }
            public object reason { get; set; }
            public Image image { get; set; }
            public Counts counts { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class BoardInfo
        {
            public Data data { get; set; }
        }
    }

    class PinterestBoardPinListModel
    {
        public class PinInfo
        {
            public string url { get; set; }
            public string note { get; set; }
            public string link { get; set; }
            public string id { get; set; }
        }

        public class Page
        {
            public object cursor { get; set; }
            public object next { get; set; }
        }

        public class PinListResponse
        {
            public List<PinInfo> data { get; set; }
            public Page page { get; set; }
        }
    }

    class PinterestPinDetailsModel
    {
        public class Creator
        {
            public string url { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string id { get; set; }
        }

        public class Media
        {
            public string type { get; set; }
        }

        public class Board
        {
            public string url { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Original
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Image
        {
            public Original original { get; set; }
        }

        public class Counts
        {
            public int saves { get; set; }
            public int comments { get; set; }
        }

        public class Author
        {
            public string name { get; set; }
        }

        public class Article
        {
            public DateTime published_at { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public List<Author> authors { get; set; }
        }

        public class Link
        {
            public string locale { get; set; }
            public string title { get; set; }
            public string site_name { get; set; }
            public string description { get; set; }
            public string favicon { get; set; }
        }

        public class Metadata
        {
            public Article article { get; set; }
            public Link link { get; set; }
        }

        public class Data
        {
            public object attribution { get; set; }
            public Creator creator { get; set; }
            public string url { get; set; }
            public Media media { get; set; }
            public DateTime created_at { get; set; }
            public string id { get; set; }
            public string note { get; set; }
            public string color { get; set; }
            public string link { get; set; }
            public Board board { get; set; }
            public Image image { get; set; }
            public Counts counts { get; set; }
            public string original_link { get; set; }
            public Metadata metadata { get; set; }
        }

        public class PinDetailsResponse
        {
            public Data data { get; set; }
        }

    }
    class PinterestMyBoardsModel
    {
        public class Board
        {
            public string url { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class MyBoardsResponse
        {
            public List<Board> data { get; set; }
        }
    }


}
