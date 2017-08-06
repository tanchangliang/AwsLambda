using System;
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
        public async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            AmazonS3Client client = new AmazonS3Client(Amazon.RegionEndpoint.APNortheast1);

            PutObjectRequest request = new PutObjectRequest()
            {

                BucketName = "databucket-rest-datasource",
                Key = "hello.txt",
                ContentType = "text/plain",
                ContentBody = "Hello World!"
            };
            try {
                await client.PutObjectAsync(request);
                return "OK";
                
            } catch (Exception e) {
                return e.ToString();
            }
        }
    }
}
