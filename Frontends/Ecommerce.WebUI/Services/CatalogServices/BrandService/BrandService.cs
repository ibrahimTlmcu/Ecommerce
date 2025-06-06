﻿using Ecommerce.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.BrandService
{
    public class BrandService : IBrandService
    {


        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync("brands", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync($"brands?id={id}");
        }

        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {
            var response = await _httpClient.GetAsync($"brands/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<UpdateBrandDto>();
            return result;
        }

        public async Task<List<ResultBrandDto>> GettAllBrandAsync()
        {
            var response = await _httpClient.GetAsync("brands");
            response.EnsureSuccessStatusCode();
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            return result;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync("brands", updateBrandDto);
        }
    }
}

