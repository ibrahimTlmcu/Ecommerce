namespace Ecommerce.WebUI.Settings
{
    public class ClientSettings
    {
        public Client EcommerceVisitorClient { get; set; }
        public Client EcommerceAdminClient { get; set; }
        public Client EcommerceManagerClient { get; set; }
    }
    public class Client
    {
        public string ClientId { get; set; }

        public string ClientSecrets { get; set; }
    }
    //appsatting.json ici ile bu kisim senkron calisacak
}
