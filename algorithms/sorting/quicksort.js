const list = [23,4,42,8,16,15];
const quickSort = (list) => {
  //recursion check. If list is empty or of length 1, return
  if(list.length < 2) return list;
  //these are the partition lists we'll need to use
  var left=[], right=[];
  //default the pivot to the last item in the list
  const pivot = list.length -1;
  //set the pivot value
  const pivotValue = list[pivot];
  //remove the pivot from the list as we don't want to compare it
  list = list.slice(0,pivot).concat(list.slice(pivot + 1));
  //loop the list, comparing the partition values
  for (var item of list) {
    item < pivotValue ? left.push(item) : right.push(item);
  }
  //recursively move through left/right lists
  return quickSort(left).concat([pivotValue], quickSort(right));
};

console.log(quickSort(list));
