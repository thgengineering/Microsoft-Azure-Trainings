1. Create a Postgre SQL database and add data into it. 
*Remember the user and password and the database name which you have created 
2. Create an Azure Function App (Node JS HTTP Trigger)

<b> Modify your HTTP Trigger </b> 
1. Open up the index.js file and copy it and paste it to your HTTP trigger. 
2. Go to your Function App and then go to the configurations of your function app 
3. In there add 4 new variable 
  a. host: The hostname of your Postgre SQL database that you can find in the overview of your resource 
  b. user: The username you have given to access your database
  c. password: The password you have given 
  d. database: The name of your database which you have created 
4. Run your HTTP trigger 
