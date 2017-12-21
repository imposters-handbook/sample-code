λf.λx.x = 0
λf.λx.f (x) = 1
λf.λx.f (f(x)) = 2
λf.λx.f (f(f(x))) = 3

f(x) = x

λf.λx.x

λf.λx.f x
(λx.f) x[f:=x]
λx.x

let calculate = f => f(x => x + 1)(0);


let calculate = f => f(x => x + 1)(0);

let zero = f => x => x;
let one = f => x => f(x);
let two = f => x => f(f(x));
let three = f => x => f(f(f(x)));

calculate(zero) // 0
calculate(one) // 1
calculate(two) // 2
calculate(three) // 3











const zero = f => x => x;
const one = f => x => f(x);
const two = f => x => f(f(x));
const three = f => x => f(f(f(x)));
const four = f => x => f(f(f(f(x))));

//a helper to show us an integer equivalent
//not Lambda Calc
const calculate = f => f(x => x + 1)(0);

console.log(calculate(one));
console.log(calculate(two));
console.log(calculate(three));
console.log(calculate(four));

//addition
//https://github.com/benji6/church/blob/master/src/numerals.js
const add = f => x => y => z => x(y)(f(y)(z));
const sum = add(one)(two);
console.log(calculate(sum));
