# Welcome to your CDK TypeScript project

This is a blank project for CDK development with TypeScript.

The `cdk.json` file tells the CDK Toolkit how to execute your app.

## Useful commands

* `npm run build`   compile typescript to js
* `npm run watch`   watch for changes and compile
* `npm run test`    perform the jest unit tests
* `npx cdk deploy`  deploy this stack to your default AWS account/region
* `npx cdk diff`    compare deployed stack with current state
* `npx cdk synth`   emits the synthesized CloudFormation template


follow below steps 
1.mkdir my-s3-bucket
2.cd my-s3-bucket
3.cdk init app --language typescript
4.npm install @aws-sdk/client-s3 --registry https://registry.npmjs.org
5.Update your lib/my-s3-bucket-stack.ts to include the S3 deployment library and updated code will be 
	import * as cdk from 'aws-cdk-lib';
	import { Construct } from 'constructs';
	import * as s3 from 'aws-cdk-lib/aws-s3';
	import * as s3_deployment from 'aws-cdk-lib/aws-s3-deployment';
	import * as path from 'path';

	export class MyS3BucketStack extends cdk.Stack {
	  constructor(scope: Construct, id: string, props?: cdk.StackProps) {
		super(scope, id, props);

		// Create an S3 bucket
		const bucket = new s3.Bucket(this, 'MyBucket', {
		  versioned: true,
		  removalPolicy: cdk.RemovalPolicy.DESTROY, // This will delete the bucket when the stack is destroyed
		  autoDeleteObjects: true, // This will delete all objects in the bucket when the stack is destroyed
		});

		// Upload files to the bucket from the assets directory
		const assetsPath = path.join(__dirname, '../assets');
		new s3_deployment.BucketDeployment(this, 'DeployFiles', {
		  sources: [s3_deployment.Source.asset(assetsPath)],
		  destinationBucket: bucket,
		});
	  }
	}
6.rm -rf node_modules  && npm install --registry https://registry.npmjs.org && npm run build
7.mkdir assets
8.echo "Hello, S3!" > assets/my-file.txt
9.cdk bootstrap
10.cdk deploy
 so file structure will be my-s3-bucket/
├── assets/
│   └── my-file.txt
├── lib/
│   └── my-s3-bucket-stack.ts
├── node_modules/
├── bin/
├── cdk.json
├── package.json
├── tsconfig.json
└── yarn.lock (or package-lock.json)



