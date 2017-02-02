//the slow way
const calculateFibAt = (n) => {
  fibCount = fibCount+1;
  if(n < 2){
    return n;
  }else{
    return calculateFibAt(n-2) + calculateFibAt(n-1);
  }
}

//run it the slow way
for(var i = 0; i<=10; i++){
  console.log(calculateFibAt(i));
}

//the ES6 lambda way...

const fib = n => n < 2 ? n : fib(n-2) + fib(n-1);

//the fast way
const calculateFibFaster = (n) =>{
  var memoTable = [0,1];
  for(var i=2;i<=n;i++){
    memoTable.push(memoTable[i-2] + memoTable[i-1]);
  }
  return memoTable;
};

//run it the fast way
console.log(fibFaster(10));
