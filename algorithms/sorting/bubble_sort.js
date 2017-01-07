//the list we need to sort
const list = [23,4,42,15,16,8];

const bubbleSort = (list) => {
  //a flag to tell us if we need to sort this list again
  var doItAgain = false;
  const limit = list.length;
  const defaultNextVal = Number.POSITIVE_INFINITY;
  //loop over the entries
  for (var i = 0; i < limit; i++) {
    let thisValue = list[i];
    let nextValue = i + 1 < limit ? list[i+1] : defaultNextVal;
    //compare values
    if(nextValue < thisValue){
      list[i] = nextValue;
      list[i+1] = thisValue;
      //since we made a switch we'll set a flag
      //as we'll need to execute the loop again
      doItAgain = true;
    }
  }
  if(doItAgain) bubbleSort(list);
}
bubbleSort(list);
console.log(list);
