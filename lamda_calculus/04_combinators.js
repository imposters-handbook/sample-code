//self-selecting function
let self = (x => x(x));
//pass in the identity function
console.log(self(x => x)(1));

//the omega combinator - uncomment as it will crash
//console.log(self(self)(1))

//the Y combinator
var yCombinator = f => self(y => f(x => y(y)(x)));


var factorial = f => n => n > 1 ? n * f(n-1) : 1;
var fib = f => n => n <= 1 ? n : f(n-1) + f(n-2);

var yFactorial = yCombinator(factorial);
var yFib = yCombinator(fib);

console.log(yFib(10));
