var list = [23,4,42,15,16,8,3];

function selectionSort(list) {

  for (var i = 0; i < list.length - 1; i++) {
    //default the min value to the first item in the list
    //all we need do is track the index for now
    var currentMinIndex = i;
    //loop over the list, skipping the currentMinIndex
    for (var x = currentMinIndex + 1; x < list.length; x++) {
      //if the current list item is less than the current min value...
      if (list[x] < list[currentMinIndex]) {
        //reset the index
        currentMinIndex = x;
      }
    }
    //has the index changed?
    if (currentMinIndex != i) {
        //if yes, switch the values in the list
        var oldMinValue = list[i];
        list[i] = list[currentMinIndex];
        list[currentMinIndex] = oldMinValue;
    }
  }
  return list;
}

console.log(selectionSort(list));
