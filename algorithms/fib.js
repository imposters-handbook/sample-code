var calculateFibAt = function(n){
  fibCount = fibCount+1;
  var calc;
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
  console.log("The Fibonacci number at position " + i +
  " is " + fib + "; It took " + fibCount + " calls to fib to get here");
}


var fibFaster =function(n){
  var sequence = [0,1];
  var fibs
  for(var i=2; i<=n; i++){
    sequence.push(sequence[i -2] + sequence[i-1]);
  }
  return sequence;
}

//run it the fast way
console.log(fibFaster(10));
