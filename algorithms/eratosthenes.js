function sieve(n){

  var list = [];

  //load the list, defaulting to "true" as unmarked
  for(var i = 2; i <= n; i++){
    list[i]={index : i, value: true};
  }

  //figure out our multiplier limit
  var limit = Math.sqrt(n);

  //run over the list, starting at 2
  for(var i = 2; i <= limit; i++){
    for(var x = i + i; x <= n; x+=i){
      //set all multiples of i to false
      list[x]=false;
    }
  }
  //build an output array
  var out = [];
  for(var i = 2; i <= n; i++){
    //if the list value is true, push the index
    if(list[i]) out.push(i);
  }
  return out;
}

Array.prototype.head = function(){
  if(this.length > 0) return this[0];
  else return null;
}
Array.prototype.tail = function(){
  if(this.length > 0) return this.slice(1, this.length);
  else return null;
}


var recurseInto = function(list, fn, skip){
  var h = list.head();
  var t = list.tail();

  if(fn && h) fn(h);
  if(t) recurseInto(t, fn);
}


//recursive variety
var sieveTwo = function(n){
  var list = [];

  //load the list, defaulting to "true" as unmarked
  for(var i = 2; i <= n; i++){
    list[i]={index : i, value: true};
  }
  //figure out our multiplier limit
  var limit = Math.sqrt(n);

  //iterate over each multiplier, starting with 4
  for(var i = 2; i <= limit; i++){
    recurseInto(list, function(val){
      //is it eligible?
      if(val.index > i && val.value){
        //is it a multiple of i?
        if(val.index % i === 0) val.value = false;
      }
    });
  }

  //build an output
  var out = [];
  recurseInto(list, function(val){
    if(val.value) out.push(val.index);
  });
  return out;
}
