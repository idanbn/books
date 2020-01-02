var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});

router.get('/:id', function(req, res, next) {
  var id = req.params.id;
  res.send(`User ID: ${id} will load shortly`);
  
});

module.exports = router;
