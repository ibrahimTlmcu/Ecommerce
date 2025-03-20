using Ecommerce.DtoLayer.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.VıewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {

        //Urun detaylari bu alanda gelecek Urune tiklandigi zaman bu alana gidilecek ve urun detaylari burada cagirilacak
        private readonly IHttpClientFactory _httpClientFactory;
        public _ProductDetailFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
         
            if (string.IsNullOrEmpty(id))
            {
                return View("id bos geldi"); 
            }


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/Products/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                //return View("Api basarili");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);

            }
            else
            {
                return View("Api basarisiz");
            }
            
        }



    }
}
