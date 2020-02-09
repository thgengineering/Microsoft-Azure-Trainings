1. Create an Azure Function App (C# HTTP Trigger Function) and Azure Key Vault 

<b>Add Secrets to the Azure Key Vault</b>
1. Navigate to the Azure Key Vault you created 
2. In the panel  on the left hand side click on secrets 
3. Click on Generate/Import
4. This is where you will be creating your secret: 
	-Upload Option: Choose manual
	-Name: Put the name as Username
	-Value: Enter a value for your username
5. Click Create 
6. Repeat the steps for your password but change the name to password

<b>Modify your HTTP Trigger Function</b>
1. Open up the run.csx file 
2. Copy the code and paste it to your Azure function. 

<b>Enable System-Assigned Managed Identity for the Function App</b>
1. Navigate to Platform Features within your Azure Function APp 
2. Select Identity 
3. Set Status to On and then click Save button 
4. A confirmation will pop up that it would be registered in the Azure Active Directory

<b>Add Key Vault Access Policy for the FUnction App</b>
1. Navigate to your Azure Key Vault 
2. Click on the access policies in the side panel 
3. Click on Add New
4. Find the Function App and select in the “Select Principal” section. Please note that we need to select “Get” and “List” permissions
5. Click the save button 

<b> Add the Key Vault Secrets reference in the Function App Configuration</b>
1. Navigate to the secrets tab in your Azure Key Vault 
2. Copy the secret identifier for both username and password
3. Add these identifiers to the "Configuration" of the Function App. There will be 2 settings added: 
	a. UsernameFromKeyVault: @Microsoft.KeyVault(SecretUri={copied identifier for the username secret})
	b. PasswordFromKeyVault: @Microsoft.KeyVault(SecretUri={copied identifier for the password secret})

Run the function app now and your username and password should be displayed. 




