using System;
using System.Collections.Generic;
using IO.Swagger.Client;
using Newtonsoft.Json;
using RestSharp;

namespace csharp_dotnet2_client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Clear();
            Console.WriteLine("Mi App DotNet");
            Console.WriteLine("=============");

            var client = new ApiClient("http://localhost:5000/v2/");
            var queryParams = new Dictionary<string, string>();
            var headerParams = new Dictionary<string, string>(); 
            var postBody = "";
            var formParams = new Dictionary<string, string>();
            var fileParams = new Dictionary<string, FileParameter>();
            var authSettings = new string[] {};

            var response = client.CallApi("pet/1",
                RestSharp.Method.GET,
                queryParams, 
                postBody,
                headerParams,
                formParams,
                fileParams, 
                authSettings
                ) as RestResponse;

            Console.WriteLine($"Status: {response.StatusCode}");
            Console.WriteLine($"Content: {response.Content}");

            Console.WriteLine();
            Console.WriteLine("Pulse INTRO para finalizar...");
            Console.ReadLine();
        }
    }
}
