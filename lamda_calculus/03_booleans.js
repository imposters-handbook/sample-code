//represents 0, or false
let zero = (x => y => y);
console.log(zero(true)(false));

//represents 1, or true
let one = (x => y => x);
console.log(one(true)(false));

//conditional returning true
let trueCond = (b => x => y => b);
console.log(trueCond(true)(false)(0))

//conditional returning false
let falseCond = (b => x => y => b);
console.log(falseCond(false)(true)(0))
