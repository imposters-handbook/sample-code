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
