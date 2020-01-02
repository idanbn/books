var express = require('express');
var router = express.Router();
// var connector = require('./mysqlConnector');

/* GET rgister page. */
router.get('/', function(req, res, next) {
  res.render('reg');
});

router.post('/', function(req, res, next) {
    console.log(req.body);
    
    var mysql = require('mysql')
var connection = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: 'password', //Mor19680
  database: 'local'
})

connection.connect((err) => {

  if(!err)
      console.log('Database is connected!');
  else
      console.log('Database not connected! : '+ JSON.stringify(err, undefined,2));
  });


console.log(`INSERT INTO local.users (name,email,password,favoriteBook) VALUES ('${req.body.name}', '${req.body.email}', '${req.body.password}', '${req.body.favoriteBook}');`);
    connection.query(`INSERT INTO local.users (name,email,password,favoriteBook) VALUES ('${req.body.name}', '${req.body.email}', '${req.body.password}', '${req.body.favoriteBook}');`, function (err, rows, fields) {
        if (err) {
          throw err;
        }
        console.log('success');
      });
    //password validatyion?
    //req.body
    //new user
    //connection.insert.user

  });

module.exports = router;
