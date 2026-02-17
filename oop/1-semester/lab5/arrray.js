const array = () => {
    const arr = [];

    const get = (i) => arr[i];

    get.push = (x) => arr.push(x);
    get.pop = () => arr.pop();

    return get;
} ;

const arr = array();

arr.push('first'); 
arr.push('second'); 
arr.push('third'); 

console.log(arr(0)); 
console.log(arr(1));
console.log(arr(2));

console.log(arr.pop());
console.log(arr.pop());
console.log(arr.pop());

console.log(arr.pop());