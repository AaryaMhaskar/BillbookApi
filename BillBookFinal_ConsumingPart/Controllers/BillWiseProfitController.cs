using BillBookFinal_ConsumingPart.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BillBookFinal_ConsumingPart.Controllers
{
    public class BillWiseProfitController : Controller
    {
        private readonly HttpClient client;

        public BillWiseProfitController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }

        public IActionResult FetchParty()
        {
            List<Party> partyDropdowns = new List<Party>();
            string url = "https://localhost:44371/api/Sales/GetParty";
            HttpResponseMessage mes = client.GetAsync(url).Result;
            if (mes.IsSuccessStatusCode)
            {
                var jsondata = mes.Content.ReadAsStringAsync().Result;
                partyDropdowns = JsonConvert.DeserializeObject<List<Party>>(jsondata);

                return Json(partyDropdowns);
            }
            else
            {
                return Json(null);
            }
        }

        public IActionResult BillWiseByPartyId(string partyId)
        {
            if (string.IsNullOrEmpty(partyId))
            {
                TempData["Msg"] = "Party ID is required.";
                return View();
            }

            string url = $"https://localhost:44371/api/Sales/GetBillByPartyId/{partyId}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var students = JsonConvert.DeserializeObject<List<BillWiseProfit>>(jsondata);
                return Json(students);
            }
            else
            {
                TempData["Msg"] = "Could not fetch sales record.";
                return View();
            }
        }

        public IActionResult AllBillWiseProfit()
        {
            List<BillWiseProfit> saless = new List<BillWiseProfit>();


            string url = "https://localhost:44371/api/Sales/GetBillWiseProfit";
            HttpResponseMessage message = client.GetAsync(url).Result;

            if (message.IsSuccessStatusCode)
            {
                var jsondata = message.Content.ReadAsStringAsync().Result;
                saless = JsonConvert.DeserializeObject<List<BillWiseProfit>>(jsondata);
            }


            return View(saless);


        }
    }
}
