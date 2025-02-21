using Ecommerce.Catalog.Dtos.AboutDto;
using Ecommerce.DtoLayer.CatalogDtos.AboutDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ResultAboutDto = Ecommerce.DtoLayer.CatalogDtos.AboutDtos.ResultAboutDto;

namespace Ecommerce.WebUI.VıewComponents.UILayoutViewComponents
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/About")]
    public class _FooterUILayoutComponentPartial : ViewComponent
    {


        private readonly IHttpClientFactory _httpClientFactory;
        public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
     
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/Abouts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            //Serialeze Metinde => Jsona donusum yapiyor Ekle Guncelle daha cok 
            //Deserialeize Jsondan => Metine  Listele idye gore getir daha cok 
            return View();
        }

    }

}
