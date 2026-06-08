using Avia.BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Avia.Test
{
    [Collection("tests")]
    public class CityTest
    {
        private readonly WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>();
        private readonly City city = new City
        {
            Code = "MSK",
            Name = "Москва"
        };
        private readonly City cityUpdate = new City
        {
            Code = "SPB",
            Name = "Санкт-Петербург"
        };

        [Theory]
        [InlineData("/api/city/all")]
        public async Task TestGetAllCities(string url)
        {
            using (var client = _factory.CreateClient())
            {
                var tempResponse = await client.PostAsJsonAsync("/api/city/create", city);
                var id = Convert.ToInt32(await tempResponse.Content.ReadAsStringAsync());
                var response = await client.GetAsync(url);
                await client.DeleteAsync("/api/city/delete/" + id);

                response.EnsureSuccessStatusCode();
                Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            }
        }

        [Theory]
        [InlineData("/api/city/id/")]
        public async Task TestGetCityById(string url)
        {
            using (var client = _factory.CreateClient())
            {
                var tempResponse = await client.PostAsJsonAsync("/api/city/create", city);
                var id = Convert.ToInt32(await tempResponse.Content.ReadAsStringAsync());
                var response = await client.GetAsync(url + id);
                await client.DeleteAsync("/api/city/delete/" + id);

                response.EnsureSuccessStatusCode();
                Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            }
        }

        [Theory]
        [InlineData("/api/city/filter/")]
        public async Task TestGetCitiesByFilter(string url)
        {
            using (var client = _factory.CreateClient())
            {
                var tempResponse = await client.PostAsJsonAsync("/api/city/create", city);
                var id = Convert.ToInt32(await tempResponse.Content.ReadAsStringAsync());
                var response = await client.GetAsync(url + city.Name);
                await client.DeleteAsync("/api/city/delete/" + id);

                response.EnsureSuccessStatusCode();
                Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            }
        }

        [Theory]
        [InlineData("/api/city/create")]
        public async Task TestCreateCity(string url)
        {
            using (var client = _factory.CreateClient())
            {
                var response = await client.PostAsJsonAsync(url, city);
                var id = await response.Content.ReadAsStringAsync();
                await client.DeleteAsync($"/api/city/delete/{id}");

                response.EnsureSuccessStatusCode();
                Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            }
        }

        [Theory]
        [InlineData("/api/city/update/")]
        public async Task TestUpdateCity(string url)
        {
            using (var client = _factory.CreateClient())
            {
                var tempResponse = await client.PostAsJsonAsync("/api/city/create", city);
                var id = await tempResponse.Content.ReadAsStringAsync();
                var response = await client.PutAsJsonAsync(url + id, cityUpdate);
                await client.DeleteAsync($"/api/city/delete/{id}");

                response.EnsureSuccessStatusCode();
                Assert.Null(response.Content.Headers.ContentType);
            }
        }

        [Theory]
        [InlineData("/api/city/delete/")]
        public async Task TestDeleteCity(string url)
        {
            using (var client = _factory.CreateClient())
            {
                var tempResponse = await client.PostAsJsonAsync("/api/city/create", city);
                var id = Convert.ToInt32(await tempResponse.Content.ReadAsStringAsync());
                var response = await client.DeleteAsync(url + id);

                response.EnsureSuccessStatusCode();
                Assert.Null(response.Content.Headers.ContentType);
            }
        }
    }
}