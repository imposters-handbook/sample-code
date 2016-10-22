var list = [1,2,3,4,5,6];

function binarySearch(list, lookFor) {
  var min = 0, max = list.length -1;
  var middle;

  while (min <= max) {
    //find the middle of the list
    middle = Math.floor((min + max) / 2);

    //if we just happen to land on it...
    if (list[middle] === lookFor) {
      return middle;
    }
    else {
      //the list is sorted, so if we're looking too low...
      if (list[middle] < lookFor) {
        //increase the mininum
        min++;
      }
      else {
        //decrease the max
        max--;
      }
    }
  }
  return -1;
}

console.log(binarySearch(list,3));
