namespace Ecommerce.WebUI.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
        //Bu sinifi kullanici adi seifre olmadan visitor olarak sisteme girecek
        //kisinin alacagi token icin kullanacagiz
    }
}
