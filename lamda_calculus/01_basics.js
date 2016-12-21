//var lambda = (x => x)(5);
//var lambda = (x => x)(y => y)(5);

//the identity function
console.log((x => x)(5));

//the constant function
let y=5;
console.log((x => y)(100));

//multiple arguments, the ugly way
console.log(((x,y) => x)(5));

//the Lambda Calculus way
console.log((x => x)(y => y)(5));

//substitution
//this function will always return 5 because we set y above to 5
console.log((x => x)(y => y)(30));

//x is both bound and free:
let x = 10;
console.log((x => x)(y => x)(5));
