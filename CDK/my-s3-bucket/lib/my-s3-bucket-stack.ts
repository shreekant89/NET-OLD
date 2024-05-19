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
