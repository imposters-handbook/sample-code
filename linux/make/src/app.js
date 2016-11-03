var products = db.getAllProducts();
var occurrences = [];
products.forEach(function(p){
  var occurrenceCount = db.getOrderItemsWithSkus("X", p.sku);
  if(occurrenceCount > 0){
    occurrences.push({target: "X", coSku: p.sku, count: occurrenceCount});
  }
});
if(occurrences.length > 0){
  //filter it and take only the top 3
}
