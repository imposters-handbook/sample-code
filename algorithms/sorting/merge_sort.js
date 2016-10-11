var list = [23,4,42,15,16,8,3];

var mergeSort = function(list){
  var left=[], right=[], result = [];
  //if there's only one item in the list
  //return
  if(list.length <= 1) return list;

  //cut the list in half
  var middle = list.length / 2;
  var left = list.slice(0, middle);
  var right = list.slice(middle, list.length);

  //recursively run through the splits
  //left and right will be separated down to single elements
  return merge(mergeSort(left), mergeSort(right));
};

var merge = function(left, right){
  var result = [];
  //if the left and right lists both have elements
  //run a comparison
  while(left.length || right.length) {
    //if there are items in both sides...
    if(left.length && right.length) {
      //if the first item on left is
      //less than right...
      if(left[0] < right[0]) {
        //take the first item on the left
        result.push(left.shift());
      } else {
        //otherwise take the first item
        //on the right
        result.push(right.shift());
      }
      //if the right list is empty and
      //the left is not...
    } else if (left.length) {
      result.push(left.shift());
    } else {
      //there are items remaining on the right
      result.push(right.shift());
    }
  }
  return result;
};

console.log(mergeSort(list));
