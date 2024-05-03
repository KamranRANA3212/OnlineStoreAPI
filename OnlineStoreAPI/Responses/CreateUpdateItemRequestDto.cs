namespace OnlineStoreAPI.Responses
{
    public class CreateUpdateItemRequestDto
    {
            public string ItemDescription { get; set; }
            public decimal ItemCost { get; set; }
            public int Quantity { get; set; }
    }
}
