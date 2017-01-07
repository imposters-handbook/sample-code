//self-selecting function
const Omega = (x => x(x));

//run this to see an error
//this is the Omega Combinator
//console.log(Omega(Omega));

//the Y combinator
//basicall a Lambda Calculus "for loop"
const Y = f => (x => x(x))(x => f(y => x(x)(y)));

//some functions we can loop over with Y
const factorial = f => n => n > 1 ? n * f(n-1) : 1;
const fib = f => n => n <= 1 ? n : f(n-1) + f(n-2);

//declare a loop
const loopFactorial = Y(factorial);
const loopFib = Y(fib);

//execute, passing in the loop constraint
console.log(loopFactorial(10));
console.log(loopFib(10));
