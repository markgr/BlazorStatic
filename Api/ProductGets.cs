using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Api;

namespace Company.Function
{
    public class ProductGets
    {

        private readonly IProductData productData;

        public ProductGets(IProductData productData)
        {
            this.productData = productData;            
        }

        [FunctionName("ProductGets")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            var products = await productData.GetProducts();
            return new OkObjectResult(products);
        }
    }
}
