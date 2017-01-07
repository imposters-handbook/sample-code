const True = (x => y => x);

const False = (x => y => y);

//conditional statement
const If = (x => y => z => x(y)(z));

console.log(If(True)("TRUE")("FALSE"));
console.log(If(False)("TRUE")("FALSE"));
