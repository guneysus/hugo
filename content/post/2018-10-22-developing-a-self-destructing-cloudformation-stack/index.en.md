---

title: "Developing a Self Destructing Cloudformation Stack"
date: 2018-10-22T22:25:47+03:00
draft: false

description: 
summary: We will develop a cloudformation template that will delete itself and resources just after a specified duration of time.

tags: ['aws', 'cloud-formation', 'devops']

slug: 
keywords: []
publishDate: 2018-10-22T22:25:47+03:00
weight: 0

---

In this tutorial, we will develop a self destructing cloudformation stack.
The stack can ben named *harakiri* since it will delete not only the resources created but also itself after a specified duration.
The stack is best suited for timely.

For example, a potential customer wants to try your SaaS before paid subscription and you do not want to be charged for the unused resources.

It would be better have a basic knowledge about CloudFormation.

> AWS Cloud Formation is a infrastructure as a code that creates, updates and deletes resources with JSON or YAML  configuration files.

## Defining Stack

AWS Cloud Formation template has five sections:

- Mapping
- Parameters
- Conditions
- Resources
- Outputs

In the resources section we define the AWS Resources that will be created. I will keep it simple and focus on only the resources section.


## Trivial Section

```yml
AWSTemplateFormatVersion: "2010-09-09"

Mappings:
  RegionMap:
    us-east-1:
      AMI: "ami-0ff8a91507f77f867"

Parameters: {}

Conditions: {}
```

There is nothing fancy here. Although we are not going to create and EC2 instance, at least one region (the region you will be creating the stack)
is required. Also AMI (Amazon Machine Image) can be wrong. Just skip it.


## IAM Role for The Lambda

We use lambda for triggering the stack delete process. This IAM role must be priviled to delete all resources created with stack.
You would like give full privilege this role but be safe by giving fine grained privilege by giving privilege to this role for only the resources
created with stack.

We gave privilege to this role:

- Deleting all cloud formation stacks
- Deleting all IAM roles. (This role will able to delete itself)
- Deleting all lambda functions
- Deleting all cloudwatch events and rules


{{% attachment lang="yaml" path="src/cf-defining-the-iam-role.yml" title="Partial Template: Defining the IAM Role" name="cf-defining-the-iam-role.yml" /%}}

## Lambda Function
This lambda function will start stack delete process.

- How does this lambda function trigger?
- Cloud Watch Rules. 

We will define a cloud watch timer later. The cloud watch timer will trigger every X times but since the lambda function
will delete all resources created with stack, probably there would be no second execution.

> Boto is a Python package that provides interfaces to Amazon Web Services.

```python
import boto3
client = boto3.client('cloudformation')

def handler(event, context):
  return client.delete_stack(StackName=event.StackName)
```


Source code of lambda function is simple. It requires a simple JSON object with a `StackName` property which is the name of the
Cloud Formation stack.

{{% attachment lang="yaml" path="src/cf-defining-the-lambda-fn.yml" title="Partial Template: Defining the Lambda Function \"Harakiri\"" name="cf-defining-the-lambda-fn.yml" /%}}


## CloudWatch Timer (Rule)

We will define a cloud watch cron rule that will be executed every thirty minutes but we expect it does not executed twice about five or ten minutes after the first execution, all resources including this rule will be deleted.

We prepare a simple JSON object at line 107, for the lambda by substituting the stack name.

{{% attachment lang="yaml" path="src/cf-defining-the-cloud-watch-timer.yml" title="Partial Template: Defining the CloudWatch Timer" name="cf-defining-the-cloud-watch-timer.yml" /%}}


## Final

- Go to AWS Cloud Formation Console: [console.aws.amazon.com/cloudformation](https://console.aws.amazon.com/cloudformation/home?region=us-east-1)
- Click **Create Stack** button and upload the template.
- Hit the **Next** button and give a name to your stack.
- Watch the events tabs at the bottom.

You will see the stack create process, just after 2-3 minutes, **_stack delete in progress_** event will appear.

{{% attachment lang="yaml" path="src/template.yml" title="See the complete Harakiri Cloud Formation Template" name="template.yml" /%}}

From the CLI you can create the stack by typing:

```shell
aws cloudformation deploy \
    --stack-name myteststack \
	  --capabilities CAPABILITY_IAM \
--template-file template.yml
```

---

## Conclusion

I hope you enjoyed and learnt a lot.

Happy coding.