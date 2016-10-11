var list = [23,4,42,15,16,8,3];

function quicksort(list) {
  //recursion check. If list is empty or of length 1, return
  if (list.length < 2) return list;

  //these are the partition lists we'll need to use
  var left = [], right = [];

  //default the pivot to the last item in the list
  var pivot = list.length - 1;

  //set the pivot value
  var pivotValue = list[pivot];

  //remove the pivot from the list as we don't want to compare it
  list = list.slice(0, pivot).concat(list.slice(pivot + 1));

  //loop the list, comparing the partition values
  for (var i = 0; i < list.length; i++) {
    if(list[i] < pivotValue){
      left.push(list[i])
    }else{
      right.push(list[i]);
    }
  }

  //do it all again
  return quicksort(left).concat([pivotValue], quicksort(right));
}

console.log(quicksort(list));
