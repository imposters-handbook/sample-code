const list = [4,8,15,16,23,42];

const binarySearch = (list, lookFor) => {
  //define the range
  var min=0, max=list.length - 1;
  var middle;

  //while there is something to search for...
  while(min <= max){
    //define the middle of the range
    middle = Math.floor((min + max) / 2);

    //if we've landed on it...
    if(list[middle] === lookFor) return middle;

    //if we haven't landed on it, where is it?
    //if the middle is less than the value we're
    //looking for, reset the min
    //otherwise reset the max
    if (list[middle] < lookFor) {
      min = middle + 1; //move min past middle
    } else {
      max = middle - 1; //move max before middle
    }
  }
  return -1;
};

console.log(binarySearch(list,3));
