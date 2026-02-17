
// цикл for
function sumFor(...args)   {
    let sum = 0;
    for (let i=0; i <args.length; i++){
        sum += args[i];
    }
return sum;
} 
console.log(sumFor(1, 2, 3)) // 6


// цикл for..of
function sumForOf(...args) {
    let sum = 0;
    for (const num of args) {
        sum += num
    }
    return sum;
}
console.log(sumForOf(0)) // 0 


// цикл while
function sumWhile(...args) {
    let sum = 0, i =0
    while ( i < args.length){
        sum += args[i];
        i++;
    }
    return(sum)
}
console.log(sumWhile()) // 0


// цикл do..while
function sumDoWhile(...args) {
    let sum = 0, i = 0;
    if(args.length === 0) return 0;
    do{
        sum += args[i];
        i++;
    } while (i < args.length);
    return sum;
}
console.log(sumDoWhile(1, -1, 1)) // 1

// метод reduce
function sumReduce(...args) {
    return args.reduce((acc, val) => acc + val, 0);
}
console.log(sumReduce(10, -1, -1, -1)) // 7


module.exports = { sumFor, sumForOf, sumWhile, sumDoWhile, sumReduce };