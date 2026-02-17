const inc = x => ++x;
const twice = x => x * 2;
const cube = x => x ** 3;

const pipe = (...fns) => {
    for (const fn of fns) {
        if (typeof fn !== "function")
            throw new Error("Argument is not a function");
    }
    return (x) => fns.reduce((acc, fn) => fn(acc), x);
}
const fn1 = pipe(inc, twice, cube);
const fn2 = pipe(inc, inc);
// const fn3 = pipe(inc, 7, cube); - Один із аргументів не є функцією

console.log(fn1(5)); // 1728
console.log(fn2(7)); // 9
// console.log(fn3(1)); - Виводить помилку, тому що один із аргументів не є функція