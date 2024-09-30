using BillBookFinal_ConsumingPart.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BillBookFinal_ConsumingPart.Controllers
{
    public class SalesSummaryController : Controller
    {
        private readonly HttpClient client;


        public SalesSummaryController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }

        public IActionResult AllSalesSummary()
        {
            List<AllSalesSummary> saless = new List<AllSalesSummary>();


            string url = "https://localhost:44371/api/SalesSummary/GetSalesSummary";
            HttpResponseMessage message = client.GetAsync(url).Result;

            if (message.IsSuccessStatusCode)
            {
                var jsondata = message.Content.ReadAsStringAsync().Result;
                saless = JsonConvert.DeserializeObject<List<AllSalesSummary>>(jsondata);
            }

            return View(saless);

        }

        public IActionResult FetchParty()
        {
            List<Party> partyDropdowns = new List<Party>();
            string url = "https://localhost:44371/api/SalesSummary/GetParty";
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

        public IActionResult SalesSummaryByPartyId(string partyId)
        {
            if (string.IsNullOrEmpty(partyId))
            {
                TempData["Msg"] = "Party ID is required.";
                return View(); 
            }

            string url = $"https://localhost:44371/api/SalesSummary/GetSalesById/{partyId}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var students = JsonConvert.DeserializeObject<List<AllSalesSummary>>(jsondata);
                return Json(students);
            }
            else
            {
                TempData["Msg"] = "Could not fetch sales record.";
                return View();
            }
        }

        public IActionResult FetchStatus()
        {
            List<Status> statusDropdowns = new List<Status>();
            string url = "https://localhost:44371/api/SalesSummary/GetStatus";
            HttpResponseMessage mes = client.GetAsync(url).Result;
            if (mes.IsSuccessStatusCode)
            {
                var jsondata = mes.Content.ReadAsStringAsync().Result;
                statusDropdowns = JsonConvert.DeserializeObject<List<Status>>(jsondata);
                return Json(statusDropdowns);
            }
            else
            {
                return Json(null);
            }
        }

        public IActionResult SalesSummaryByStatus(string Status)
        {
            if (string.IsNullOrEmpty(Status))
            {
                TempData["Msg"] = "Status  is required.";
                return View();
            }

            string url = $"https://localhost:44371/api/SalesSummary/GetSalesByStatus/{Status}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var students = JsonConvert.DeserializeObject<List<AllSalesSummary>>(jsondata);
                return Json(students);
            }
            else
            {
                TempData["Msg"] = "Could not fetch sales record.";
                return View();
            }
        }

        
    }
}

