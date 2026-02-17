const inc = x => ++x;
const twice = x => x * 2;
const cube = x => x ** 3;

function compose(...fns) {
    return (x) => {
        try {
            for (const fn of[...fns].reverse()) {
                if (typeof fn !== "function") {
                    throw new Error("Argument is not a function");
                }
                x = fn(x);
            }
            return x;
        } catch (error) {
            return undefined;
        }
    };
}

const fn1 = compose(inc, twice, cube);
const fn2 = compose(inc, inc);
const fn3 = compose(inc, 7, cube);

console.log(fn1(5)); // 251
console.log(fn2(7)); // 9
console.log(fn3(1)); // undefined