const list = [23,4,42,8,16,15];
const selectionSort = (list) => {
  for (var i = 0; i < list.length; i++) {
    //default the min value to the first item in the list
    //all we need do is track the index for now
    var currentMinIndex = i;
    //loop over the list, skipping the currentMinIndex
    for(var x = currentMinIndex + 1; x < list.length; x++){
      //if the current list item is less than the current min value...
      if(list[x] < list[currentMinIndex]){
        //reset the index
        currentMinIndex = x;
      }
    }
    //has the index changed?
    if(currentMinIndex != i){
      //if yes, switch the values in the list
      var oldMinValue = list[i];
      list[i] = list[currentMinIndex];
      list[currentMinIndex] = oldMinValue;
    }
  }
  return list;
};
console.log(selectionSort(list));



const hasDuplicates = function(num){
  //loop the list, our O(n) op
  for(let i = 0; i < nums.length; i++){
    const thisNum = nums[i];
    //loop the list again, the O(n^2) op
    for(let j = 0; j < nums.length; j++){
      //make sure we're not checking same number
      if(j !== i){
        const otherNum = nums[j];
        //if there's an equal value, return
        if(otherNum === thisNum) return true;
      }
    }
  }
  //if we're here, no dups
  return false;
}
const nums = [1,2,3,4,5,5];
hasDuplicates(nums);//true
