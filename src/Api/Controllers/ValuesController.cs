using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;

namespace Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            var products = new List<Product>{ new Product() { Id = 1, Nome = "Teste" }, new Product() { Id = 2, Nome = "Teste 2" } };

            return Request.CreateResponse(products);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var product = new Product() { Id = id, Nome = "Testes" };

            return Request.CreateResponse(product);
        }


        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Product product)
        {
            return Request.CreateResponse(HttpStatusCode.Created);
        }


        // PUT api/values/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Product product)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        // DELETE api/values/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
