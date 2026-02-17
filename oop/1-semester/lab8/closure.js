function store(initialValue) {
    let value = initialValue;
    function getter() {
        return value;
    }
    getter.set = function(newValue) {
        value = newValue;
    };
    return getter;
}

const read = store(5);
console.log(read()); // 5
read.set(10);
console.log(read()); // 10