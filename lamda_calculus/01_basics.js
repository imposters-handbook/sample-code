//var lambda = (x => x)(5);
//var lambda = (x => x)(y => y)(5);
function thing(x){return x};

(x => x)

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
console.log((x => x)(y => y)(30));

//x is both bound and free:
let x = 10;
console.log((x => x)(y => x)(5));


λx.x

λx.x (y)

(x => x)(y)
//or
function thing(x){return x}(y) //returns y;

λx.y (z)

let z = 3;
function thing(x){return y}(z);

λz.z y 

λx.x 3

λx.x 3
x[x:=3]
3

let y = 3;
const fn = (x => y)(1);

let y = 3;
const fn = (x => x)(1);

λxy.t

λx.λy.t

(x => y => x + y);

λx.λy.y x

λx.λy.y x
λy.y[x:=x]
λy.y

const first = (y => y);
const second = (x => first(x));
console.log(second(first));
//[Function: first]


(x => y => x + y)(2)(3);

(x => x)(y => y)(2)(3);

(x => x)(y => y)(2); //2


λx.(λy.y x)


λx.(λy.y x)
λx.(y[y:=x])
λx.x 


λx.λy.y x
(λy.y)[x:=x]
λy.y


if(true) x
else y

λx.λy.x

λx.λy.y

let True = (x => y => x);
let False = (x => y => y);
True(true)(false) //true 
False(true)(false) //false

λx.λy.λz.x y z

let If = (x => y => z => x(y)(z));

let True = (x => y => x);
let False = (x => y => y);
let If = (x => y => z => x(y)(z));

If(True)("TRUE")("oops..");//TRUE
If(False)("oops")("FALSE");//FALSE

