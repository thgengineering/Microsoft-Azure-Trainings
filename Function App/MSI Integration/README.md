1. Create a Function App (C#) 
2. Create a storage account

<b>Turn on System Assigned Manged Identity for your Function App</b> 
1. Go to your function app 
2. Navigate to Platform Features and choose Identity 
3. Turn on the system assigned managed identity. 
4. A confirmation will come when you hit save.

<b> Add the managed identity to your storage account</b> 
1. Navigate to your Storage Account
2. Click on access control 
3. CLick on + Add the Add role assignment 
4. For role select Contributor 
5. Under select search for your Function App Name 
6. Click save

<b> Create File in storage account</b> 
1. Navigate to your storage account 
2. Go to containers and click on + Container. Give a name for your container

<b> Get the URL of your Storage<b> 
1. Navigate to your storage account 
2. Click on containers 
3. Next to your container name you will see ... towards the right hand side. Click on container properties.
4. Copy the URL 

<b> Change the Variables within the code</b> 
1. Navigate to the Function1.cs file. 
2. Change the variable of storageURL to the url of your storage account. 

<b> Push code to your Function App</b> 
1. Right click on your solution in Visual Studio 
2. Click on publish
3. Click on Azure Function Cosumption Plan 
4. Click on Select Existing 
5. Choose the subscription and resource group and the function app you have created. 
6. Hit okay 
7. Navigate to your function app and run the function app. Append.txt file will be created. 


