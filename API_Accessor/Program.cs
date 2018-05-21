using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace API_Accessor
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            ProductList productList = null;
            try
            {
                productList = ReadProduct().GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine("API Accessor Error");
                
                Console.WriteLine(e.Message);
            }

            //display the product information
            printProductInformation(productList);

            Console.ReadLine();

        }
        private static void printProductInformation(ProductList productList)
        {
            if (productList != null)
            {
                foreach (var item in productList.results.data)
                {
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.productID);
                    Console.WriteLine(item.hasTemplate);
                    Console.WriteLine(item.quantityDefault);
                    Console.WriteLine(item.quantityMinimum);
                    Console.WriteLine(item.quantityMaximum);
                    Console.WriteLine();
                }
            }
        }

        private static async Task<ProductList> ReadProduct()
        {
            //establish headers
            client.DefaultRequestHeaders.Clear();

            //accept header
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //authentication header
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("miniproject:Pr!nt123"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            //request data as stream
            var streamTask = client.GetStreamAsync("https://testapi.pfl.com/products?apikey=136085");

            //create serializer
            var serializer = new DataContractJsonSerializer(typeof(ProductList));

            //deserialize information
            ProductList results = serializer.ReadObject(await streamTask) as ProductList;

            return results;
        }
    }
}
