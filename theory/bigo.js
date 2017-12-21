const nums = [1,2,3,4,5];

const nums = [1,2,3,4,5];
const firstNumber = nums[0];

const nums = [1,2,3,4,5];
let sum = 0;
for(let num of nums){
  sum += num;
}


const sumContiguousArray = function(ary){
  //get the last item
  const lastItem = ary[ary.length - 1];
  //Gauss's trick
  return lastItem * (listItem + 1) / 2;
}
const nums = [1,2,3,4,5];
const sumOfArray = sumContiguousArray(nums);


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

const nums = [1,2,3,4,5];
const searchFor = function(items, num){
  //use binary search!
  //if found, return the number. Otherwise...
  //return null. We'll do this in a later chapter.
}
const hasDuplicates = function(nums){
  for(let num of nums){
    //let's go through the list again and have a look
    //at all the other numbers so we can compare
    if(searchFor(nums,num)){
      return true;
    }
  }
  //only arrive here if there are no dups
  return false;
}


const findDuplicate = function(ary){
  //sum what we're given
  let actualSum = 0;
  //our O(n) scan
  ary.forEach(x => actualSum += x);
  //get the last item
  const lastItem = ary[ary.length - 1];
  //create a new array
  const shouldBe = lastItem * (lastItem + 1) / 2;
  return actualSum - shouldBe;
}
const nums = [1,2,3,4,4,5];
const duplicate = findDuplicate(nums);