using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogisticProgram
{
    class Requests
    {
        private double CurennciesToByn(string currency, int price)
        {
            if (currency == "EUR")
            {
                using (var webClient = new WebClient())
                {
                    var response = webClient.DownloadString("http://www.nbrb.by/api/exrates/rates/292");
                    MatchCollection search = Regex.Matches(response, @"\d+[.]\d+");
                    double rate = Convert.ToDouble(search[0].ToString().Replace('.', ','));
                    return price * rate;
                } 
            }
            else if (currency == "USD")
            {
                using (var webClient = new WebClient())
                {
                    var response = webClient.DownloadString("http://www.nbrb.by/api/exrates/rates/145");
                    MatchCollection search = Regex.Matches(response, @"\d+[.]\d+");
                    double rate = Convert.ToDouble(search[0].ToString().Replace('.', ','));
                    return price * rate;
                }
            }
            else if (currency == "RUB")
            {
                using (var webClient = new WebClient())
                {
                    var response = webClient.DownloadString("http://www.nbrb.by/api/exrates/rates/298");
                    MatchCollection search = Regex.Matches(response, @"\d+[.]\d+");
                    double rate = Convert.ToDouble(search[0].ToString().Replace('.', ','));
                    return price * rate / 100;
                }
            }
            else if (currency == "BYN")
            {
                return price;
            }
            else
            {
                return 0;
            }
        }
        public double ConvertPrice(Dictionary<string, int> prices)
        {
            double sum = 0;
            foreach (KeyValuePair<string, int> price in prices)
            {
                sum += CurennciesToByn(price.Key, price.Value);
            }
            return sum;
        }
    }
}
