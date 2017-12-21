const calculateFibAt = (n) => {
  fibCount = fibCount+1;
  if(n < 2){
    return n;
  }else{
    return calculateFibAt(n-2) + calculateFibAt(n-1);
  }
}

for(var i = 0; i<=10; i++){
  console.log(calculateFibAt(i));
}

var fibCount=0;
var calculateFibAt = function(n){
  fibCount = fibCount+1;
  var calc;
  if(n < 2){
    return n;
  }else{
    return calculateFibAt(n-2) + calculateFibAt(n-1);
  }
}

for(var i = 0; i<=10; i++){
  var fib = calculateFibAt(i);
  console.log("The Fibonacci number at position " + i + " is " + fib + "; It took " + fibCount + " calls to fib to get here");
}



var fibFaster = function(n){
  var sequence = [0,1];
  for(var i=2; i<=n; i++){
    sequence.push(sequence[i -2] + sequence[i-1]);
  }
  return sequence;
}

console.log(fibFaster(10));

//
// //the ES6 lambda way...
//
// const fib = n => n < 2 ? n : fib(n-2) + fib(n-1);
//
// //the fast way
// const calculateFibFaster = (n) =>{
//   var memoTable = [0,1];
//   for(var i=2;i<=n;i++){
//     memoTable.push(memoTable[i-2] + memoTable[i-1]);
//   }
//   return memoTable;
// };
//

var fibConstantSpace= function(n, fn){
  let twoFibsAgo = 0, oneFibAgo=1, currentFib=0;
  //make sure to output the first two
  for(var i=2; i<=n; i++){
    currentFib = twoFibsAgo+oneFibAgo;
    twoFibsAgo = oneFibAgo;
    oneFibAgo = currentFib;
  }
  return currentFib;
}


var fibConstantSpace= function(n, fn){
  let twoFibsAgo = 0, oneFibAgo=1, currentFib=0;
  //make sure to output the first two
  if(fn){
    fn(0);
    fn(1);
  }
  for(var i=2; i<=n; i++){
    currentFib = twoFibsAgo+oneFibAgo;
    twoFibsAgo = oneFibAgo;
    oneFibAgo = currentFib;
    if(fn) fn(currentFib);
  }
}
fibConstantSpace(10, function(fib){
  console.log(fib);
});
// //run it the fast way

const fib = function(n, twice=0, last=1){
  if(n === 0) return last;
  return fib(n-1, twice + last, twice);
}

console.log(fib(10));
