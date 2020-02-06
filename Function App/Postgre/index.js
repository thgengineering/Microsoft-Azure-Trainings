const pg = require('pg');
const config = {
 host: process.env['host'],
 user: process.env['user'], 
 password: process.env['password'],
 database: process.env['database'],
 port: 5432,
 ssl: true
};
module.exports =function (context, req) {
 const client = new pg.Client(config);
 client.connect(err => {
 if (err){
 context.log(err);
 }
 else { 
 context.log("Connection is stablite");
 const query = 'SELECT * FROM staff;';
 client.query(query)
 .then(res => {
 const rows = res.rows;
 context.log(JSON.stringify(rows))
 context.res = {
 body: (JSON.stringify(rows))
 };
 context.done(); 
 })
 
 }
 });
 
};
