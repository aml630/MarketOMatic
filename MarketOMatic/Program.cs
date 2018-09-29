using MarketOMatic.ExportLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOMatic
{
    class Program
    {
        static void Main(string[] args)
        {

            var token = "Aox57oRbwy55dca9muXIZsrw1lkJFVj9jMln60pFRn0rfKBijwotwDAAAbOERUZ9SCrgVYkAAAAA";

            var newLogic = new PinterestLogic(token);

            var meCall = newLogic.GetBoardPins("140385782073712462");

            Console.WriteLine(meCall);

            Console.ReadLine();

        }
    }
}
