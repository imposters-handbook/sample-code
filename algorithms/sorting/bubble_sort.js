//the list we need to sort
var list = [23,4,42,15,16,8];

var bubbleSort = function(list){
  //a flag to tell us if we need to sort this list again
  var doItAgain = false;
  //loop variables
  var limit = list.length;
  var defaultNextVal = Number.POSITIVE_INFINITY;

  //loop  over the list entries...
  for(var i = 0; i < limit; i++){
    //the current list value
     var thisValue = list[i];
     //the next value inline, which we'll default to a really high number
     var nextValue = i + 1 < limit ? list[i + 1] : defaultNextVal;

     //is the next number lower than the current?
     if(nextValue < thisValue){
       //if yes, we switch the values
       list[i] = nextValue;
       list[i + 1] = thisValue;
       //since we made a switch we'll set a flag
       //as we'll need to execute the loop again
       doItAgain = true;
     }
  }
  //recurse over the list
  if(doItAgain) bubbleSort(list);
};

bubbleSort(list)
console.log(list);
