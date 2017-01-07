const list = [23,4,42,15,16,8,3];
const mergeSort = (list) => {
  //if there's only one item in the list
  //return. This is our recursion check.
  if(list.length <= 1) return list;

  //cut list in half
  const middle = list.length/2;
  const left = list.slice(0,middle);
  const right = list.slice(middle,list.length);

  //recursively run through the splits
  //left and right will be separated down to single elements
  return merge(mergeSort(left), mergeSort(right));
};

const merge = (left, right) => {
  var result = [];
  //if the left and right lists both have elements
  //run a comparison
  while(left.length || right.length){
    //if there are items in both sides...
    if(left.length && right.length){
      //if the first item on left is
      //less than right...
      if(left[0] < right[0]){
        //take the first item on the left
        result.push(left.shift());
      }else{
        //take the first item on the right
        result.push(right.shift());
      }
    }else if(left.length){
      //just take left
      result.push(left.shift());
    }else{
      //just take right
      result.push(right.shift());
    }
  }
  return result;
}

console.log(mergeSort(list));
