using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CurrenciesService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesService
{
    public class CurrencyService : ICurrencyService
    {

        public List<CurrencyDetails> getCurrencyInfo()
        {
            List<CurrencyDetails> currencyDetailsList = new List<CurrencyDetails>();
            WebClient client = new WebClient();
            var response = client.DownloadString("http://hasanadiguzel.com.tr/api/kurgetir");

            CurrencyInfo currencyInfo = CurrencyInfo.FromJson(response);

            var tcmbLiveCurrencyInfo = currencyInfo.TcmbAnlikKurBilgileri;

            for (int i = 0; i < tcmbLiveCurrencyInfo.Length - 1; i++)
            {
                CurrencyDetails tempCurrencyDetails = new CurrencyDetails();
                tempCurrencyDetails.Currency_ = translate(tcmbLiveCurrencyInfo[i].CurrencyName);
                tempCurrencyDetails.Buying_ = Convert.ToDouble(tcmbLiveCurrencyInfo[i].ForexBuying);
                tempCurrencyDetails.Selling_ = Convert.ToDouble(tcmbLiveCurrencyInfo[i].ForexSelling);
                currencyDetailsList.Add(tempCurrencyDetails);
            }
            return currencyDetailsList;
        }

        public string translate(string currency)
        {
            switch (currency)
            {

                case "US DOLLAR":
                    currency = "ABD DOLARI";
                    break;
                case "AUSTRALIAN DOLLAR":
                    currency = "AVUSTRALYA DOLARI";
                    break;
                case "DANISH KRONE":
                    currency = "DANİMARKA KRONU";
                    break;
                case "EURO":
                    currency = "EURO";
                    break;
                case "POUND STERLING":
                    currency = "İNGİLİZ STERLİNİ";
                    break;
                case "SWISS FRANK":
                    currency = "İSVİÇRE FRANGI";
                    break;
                case "SWEDISH KRONA":
                    currency = "İSVEÇ KRONU";
                    break;
                case "CANADIAN DOLLAR":
                    currency = "KANADA DOLARI";
                    break;
                case "KUWAITI DINAR":
                    currency = "KUVEYT DİNARI";
                    break;
                case "NORWEGIAN KRONE":
                    currency = "NORVEÇ KRONU";
                    break;
                case "SAUDI RIYAL":
                    currency = "SUUDİ ARABİSTAN RİYALİ";
                    break;
                case "JAPENESE YEN":
                    currency = "JAPON YENİ";
                    break;
                case "BULGARIAN LEV":
                    currency = "BULGAR LEVASI";
                    break;
                case "NEW LEU":
                    currency = "RUMEN LEYİ";
                    break;
                case "RUSSIAN ROUBLE":
                    currency = "RUS RUBLESİ";
                    break;
                case "IRANIAN RIAL":
                    currency = "İRAN RİYALİ";
                    break;
                case "CHINESE RENMINBI":
                    currency = "ÇİN YUANI";
                    break;
                case "PAKISTANI RUPEE":
                    currency = "PAKİSTAN RUPİSİ";
                    break;
                case "QATARI RIAL":
                    currency = "KATAR RİYALİ";
                    break;
                case "SOUTH KOREAN WON":
                    currency = "GÜNEY KORE WONU";
                    break;
                case "AZERBAIJANI NEW MANAT":
                    currency = "AZERBAYCAN YENİ MANATI";
                    break;
                case "UNITED ARAB EMIRATES DIRHAM":
                    currency = "BİRLEŞİK ARAP EMİRLİKLERİ DİRHEMİ";
                    break;
                default:
                    break;
            }

            return currency;
        }
    }
}
