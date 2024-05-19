# Welcome to your CDK C# project!

This is a blank project for CDK development with C#.

The `cdk.json` file tells the CDK Toolkit how to execute your app.

It uses the [.NET CLI](https://docs.microsoft.com/dotnet/articles/core/) to compile and execute your project.

## Useful commands

* `dotnet build src` compile this app
* `cdk deploy`       deploy this stack to your default AWS account/region
* `cdk diff`         compare deployed stack with current state
* `cdk synth`        emits the synthesized CloudFormation template

follow the below steps:-
0.create Iam user in aws with codedeployment access In aws and then start below step on your local.
1.	mkdir cdk-hello-world
2.	cd cdk-hello-world
3.	cdk init app --language csharp
4.	Create a folder named lambda in your project directory (cdk-hello-world) and add your Lambda function code. For example, create a file named hello.js with the following content:
5.	exports.handler = async (event) => {
6.	  return {
7.	      statusCode: 200,
8.	      headers: { "Content-Type": "text/plain" },
9.	      body: JSON.stringify({ message: "Hello, World!" }),
10.	  };
11.	};
12.	open MyLambdaCDKStack.cs 
      	using Amazon.CDK;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.Lambda;
using Constructs;

namespace CdkHelloWorld
{
    public class CdkHelloWorldStack : Stack
    {
        internal CdkHelloWorldStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // Define the Lambda function resource
            var helloWorldFunction = new Function(this, "HelloWorldFunction", new FunctionProps
            {
                Runtime = Runtime.NODEJS_20_X, // Choose any supported Node.js runtime
                Code = Code.FromAsset("lambda"), // Points to the lambda directory
                Handler = "hello.handler" // Points to the 'hello' file in the lambda directory
            });
            var api = new LambdaRestApi(this, "HelloWorldApi", new LambdaRestApiProps
            {
                Handler = helloWorldFunction,
                Proxy = false
            });
            // Add a '/hello' resource with a GET method
            var helloResource = api.Root.AddResource("hello");
            helloResource.AddMethod("GET");
        }
    }
}
6.for cdk we need account and region and acceskey will be fetched by C:\Users\{username} \.aws\credential in bash you can do it using 
export CDK_DEFAULT_ACCOUNT=your-aws-account-id
7.cdk bootstrap will create stack which we want to deploy you can see in “cdk.out” folder(run this command on folder cdk-hello-world)
8. if its pass then use CDK deploy to deploy
9. I have face issue when I was using bash but works fine when I run above command on CMD because of proxy setting
10.after deployment you can see stack is created in aws 




