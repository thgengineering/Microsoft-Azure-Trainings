<b>Use Azure portal to create a Service Bus Topic</b>
1. Login to Azure Portal 

2. In the left navigation pane of the portal, select + Create a resource, select Integration, and then select Service Bus.

3. In the Create namespace dialog, do the following steps:

	a. Enter a name for the namespace. The system immediately checks to see if the name is available. For a list of rules for naming namespaces, see Create Namespace REST API.

	b. Select the pricing tier (Basic, Standard, or Premium) for the namespace. If you want to use topics and subscriptions, choose either Standard or Premium. Topics/subscriptions are not supported in the Basic pricing tier.

	c. If you selected the Premium pricing tier, follow these steps:
	
		i. Specify the number of messaging units. The premium tier provides resource isolation at the CPU and memory level so that each workload runs in isolation. 
		This resource container is called a messaging unit. A premium namespace has at least one messaging unit. You can select 1, 2, or 4 messaging units for each Service Bus Premium namespace. For more information, see Service Bus Premium Messaging.
		ii. Specify whether you want to make the namespace zone redundant. The zone redundancy provides enhanced availability by spreading replicas across availability zones within one region at no additional cost. For more information, see Availability zones in Azure.

	d. For Subscription, choose an Azure subscription in which to create the namespace.

	e. For Resource group, choose an existing resource group in which the namespace will live, or create a new one.

	f. For Location, choose the region in which your namespace should be hosted.

	g. Select Create. The system now creates your namespace and enables it. You might have to wait several minutes as the system provisions resources for your account.
	
<b>Get the Connection String</b>
1. Go to your resource group and select the service bus you just created 
2. Navigate to Shared Access Policies from the left panel 
3. In the Shared access policies screen, click RootManageSharedAccessKey.
4. In the Policy: RootManageSharedAccessKey window, click the copy button next to Primary Connection String, to copy the connection string to your clipboard for later use. Paste this value into Notepad or some other temporary location.
5. Repeat the previous step, copying and pasting the value of Primary key to a temporary location for later use.

<b>Create a Topic in the Azure Portal</b>
1. Select Topics in the left navigation 
2. On the Topics page, select + Topic on the toolbar.
3. Enter a name for the topic, and leave the other values with their defaults. Click Create. 

<b>Create subscriptions for the topic</b>
1. Select the topic that you created. 
2. On the Service Bus Topic page, select Subscriptions from the left menu, and then select + Subscription on the toolbar.
3. On the Create subscription page, enter a for name for the subscription, and then select Create.
4. Repeat the previous step 2 more times. 

<b>Send messsages to your Topic</b>
1. Open up OVCDemo.Sender folder and open up the solution file 
2. Open up the Program.cs file
3. Inside the Program.cs file change the ServiceBusConnectionString and TopicName variable to reflect your Service Bus Topic
4. Run the code 
5. Check in your Service Bus Topic to see that your messages have been delivered to your subscription. 

<b> Recieve Messages from your Topic</b>
1. Open up the OVCDemo.Receiver folder and open up the solution file. 
2. Open up the Program.cs file
3. Inside the Program.cs file change the ServiceBusConnectionString, TopicName and SubscriptionName variable to reflect your Service Bus Topic
4. Run the code 
5. Check in your Service Bus Topic to see that your messages have been received from the particular subscription.
