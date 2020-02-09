<b>Install the Azure FUnctions Extension</b>
1. In Visual Studio Code, open Extensions and search for azure functions, or select this link in Visual Studio Code.
2. Select Install to install the extension
3. After installation, select the Azure icon on the Activity bar. You should see an Azure FUnctions area in the side bar. 

<b> Install the Durable Functions npm Package</b><br> 
1.Install the durable-functions npm package by running npm install durable-functions in the root directory of the function app.

<b> Create your Local Project</b>
1. Open up the command palette or type COMMAND + SHIFT + P.
2. Select Axure Functions: Create New Project
3. Next it will ask you to choose a language, choos javascript 
4. We will need an entry point so choose Durable Functions HTTP Start
5. Next up let's create our orchestrator function, again hit COMMAND + SHIFT + P and select Azure Functions: Create Function and select Durable Functions Orchestrator
6. Upon doing so you will be asked to select a storage account
7. Finally let's create our activity function, again hit COMMAND + SHIFT + P and select Azure Functions: Create Function and select Durable Functions Activity

<b> Sign in to Azure </b> 
1. If you aren't already signed in, choose the Azure icon in the Activity bar, then in the Azure: Functions area, choose Sign in to Azure
2. When prompted in the browser, choose your Azure account and sign in using your Azure account credentials.
3. After you've successfully signed in, you can close the new browser window. The subscriptions that belong to your Azure account are displayed in the Side bar

<b>Publish the Project to Azure</b>
1. Choose the Azure icon in the Activity bar, then in the Azure: Functions area, choose the Deploy to function app button, which looks like an up arrow
2. Provide the following information at the prompts<br>
	-Select subscription: Choose the subscription to use. You won't see this if you only have one subscription.<br>
	-Select Function App in Azure: Choose + Create new Function App (not Advanced). <br>
	-Enter a globally unique name for the function app: Type a name that is valid in a URL path. The name you type is validated to make sure that it's unique in Azure Functions.<br>
	-Select a runtime: Choose the version of Node.js you've been running on locally. You can use the node --version command to check your version.<br>
	-Select a location for new resources: For better performance, choose a region near you.
 3. A notification is displayed after your function app is created and the deployment package is applied. Select View Output in this notification to view the creation and deployment results, including the Azure resources that you created. If you miss the notification, select the bell icon in the lower right corner to see it again.
 
<b> Test your Function in Azure </b>
1. Copy the URL of the HTTP trigger from the Output panel. The URL that calls your HTTP-triggered function should be in the following format:<br>
	http://<functionappname>.azurewebsites.net/orchestrators/<functionname> <br>
Put the name of the orchestration function in the <functionname> portion. 
2. Copy the URL value for statusQueryGetUri and paste it in the browser's address bar and execute the request. Alternatively you can also continue to use Postman to issue the GET request.
The request will query the orchestration instance for the status. You should get an eventual response, which shows us the instance has completed, and includes the outputs or results of the durable function.
 


