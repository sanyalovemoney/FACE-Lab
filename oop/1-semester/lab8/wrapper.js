function contract(fn, ...types) {
    return function(...args) {
        for (let i = 0; i < types.length; i++) {
            if (typeof args[i] !== types[i]) {
                throw new TypeError(`Argument ${i + 1} is not of type ${types[i]}`);
            }
        }
        return fn(...args);
    };
}

const add = (a, b) => a + b;
const addNumbers = contract(add, 'number', 'number');
const res = addNumbers(2, 3);
console.dir(res);

const concat = (s1, s2) => s1 + s2;
const concatStrings = contract(concat, 'string', 'string');
const res2 = concatStrings('Hello ', 'world!');
console.dir(res2);