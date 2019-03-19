using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Api.Controllers;
using Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Api.Testes
{
    [TestClass]
    public class TesteApi
    {
        private const int Id = 10;

        #region Controllers da Api
        [TestMethod]
        [TestCategory("Teste Controller Api")]
        public void Testando_o_controlller_metodo_GET()
        {
            var controller = new ValuesController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = controller.Get(Id);

            var product = JsonConvert.DeserializeObject<Product>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(Id, product.Id);
        }


        [TestMethod]
        [TestCategory("Teste Controller Api")]
        public void Testando_o_controlller_metodo_GET_por_id()
        {
            var controller = new ValuesController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = controller.Get(Id);

            var product = JsonConvert.DeserializeObject<Product>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(Id, product.Id);
        }


        [TestMethod]
        [TestCategory("Teste Controller Api")]
        public void Testando_o_controlller_metodo_POST()
        {
            var controller = new ValuesController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = controller.Post(new Product() { Nome = "Teste" });


            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }


        [TestMethod]
        [TestCategory("Teste Controller Api")]
        public void Testando_o_controlller_metodo_PUT()
        {
            var controller = new ValuesController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = controller.Put(Id, new Product { Id = Id, Nome = "Teste" });


            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        [TestCategory("Teste Controller Api")]
        public void Testando_o_controlller_metodo_DELETE()
        {
            var controller = new ValuesController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = controller.Delete(Id);


            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        } 
        #endregion


        #region Chamadas da API
        [TestMethod]
        [TestCategory("Teste Chamada Api")]
        public void Testando_a_chamada_GET_da_API()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54964/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"api/values").Result;
                var products = JsonConvert.DeserializeObject<IList<Product>>(response.Content.ReadAsStringAsync().Result);
                Assert.IsTrue(products.Any());
            }
        }


        [TestMethod]
        [TestCategory("Teste Chamada Api")]
        public void Testando_a_chamada_GET_por_id_da_API()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54964/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"api/values/{Id}").Result;
                var product = JsonConvert.DeserializeObject<Product>(response.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(Id, product.Id);
            }
        }


        [TestMethod]
        [TestCategory("Teste Chamada Api")]
        public void Testando_a_chamada_POST_da_API()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54964/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var data = new StringContent(Id.ToString(), Encoding.UTF8, "application/json");
                var response = client.PostAsync($"api/values", data).Result;

                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            }
        }


        [TestMethod]
        [TestCategory("Teste Chamada Api")]
        public void Testando_a_chamada_PUT_da_API()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54964/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new Product { Id = Id, Nome = "Teste" });

                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PutAsync($"api/values/{Id}", data).Result;

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }


        [TestMethod]
        [TestCategory("Teste Chamada Api")]
        public void Testando_a_chamada_DELETE_da_API()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54964/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.DeleteAsync($"api/values/{Id}").Result;

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        } 
        #endregion

    }
}

