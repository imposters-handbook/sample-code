//Church encoding
//simple boolean construct
//λx.λy.x //true
//λx.λy.y //false
//if true, return first value
//if false, return second value
const True = (x => y => x);
const False = (x => y => y);
console.log(True(true)(false));
console.log(False(true)(false));

//λz.λx.λy.z (x)(y)
const If = (x => y => z => x(y)(z));
console.log(If(True)("TRUE")("oops"));
console.log(If(False)("oops")("FALSE"));














// const True = (x => y => x);
//
// const False = (x => y => y);
//
// //conditional statement
// const If = (x => y => z => x(y)(z));
//
// console.log(If(True)("TRUE")("FALSE"));
// console.log(If(False)("TRUE")("FALSE"));
