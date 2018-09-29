using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MarketOMatic.ExportLogic
{
    class TwitterLogic
    {
        public string Tweet(string message, string imageSource = null)
        {

            string ConsumerKey = "j3HsSc1ejljPQlrKite0yiGAe",
            ConsumerKeySecret = "2H0CGLfnO3IhSF7yEmt9gzfKDEA5W6eDBVGOHk6hVrToorsHRF",
            AccessToken = "919319179529818113-UQkL7yk4SoSk9RccTfogPhfOOX5biJT",
            AccessTokenSecret = "KqZleU9ADCXZe6KF0IjvJWCTWpeyY4OF7BZZbYVd62tqa";

            var twitter = new Twitter(ConsumerKey, ConsumerKeySecret, AccessToken, AccessTokenSecret);

            if (!string.IsNullOrEmpty(imageSource))
            {
                string imagePath = HttpRuntime.AppDomainAppPath + imageSource;

                return twitter.PublishToTwitter(message, imagePath);
            }
            else
            {
                var rez = Task.Run(async () =>
                {
                    return await twitter.TweetText(message, string.Empty);
                });
            }

            return "error";
        }
    }
}
