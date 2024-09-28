namespace BillBookFinal_ConsumingPart.Models
{
    public class AllSalesSummary
    {
            public DateTime invoiceDate { get; set; }
            public int invoiceId { get; set; }
            public string partyName { get; set; }
            public DateTime dueDate { get; set; }
            public float amount { get; set; }
            public string invoiceStatus { get; set; }
        }

    }

