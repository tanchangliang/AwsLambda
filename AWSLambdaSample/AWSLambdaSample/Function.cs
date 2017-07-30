using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambdaSample
{
    public class Function
    {
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            //IAmazonS3 client = new AmazonS3Client(Amazon.RegionEndpoint.APNortheast1);
            AmazonS3Client client = new AmazonS3Client();
            PutObjectRequest request = new PutObjectRequest();
            
            request.BucketName = "databucket-rest-datasource";
            request.Key = "hello.txt";
            request.ContentType = "text/plain";
            request.ContentBody = "Hello World!";
            try {
                client.PutObjectAsync(request);
                
                return client.PutObjectAsync(request).ToString();

            } catch (Exception e) {
                return e.ToString();
            }
        }
    }
}
