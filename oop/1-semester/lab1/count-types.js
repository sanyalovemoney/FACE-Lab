const arr = [true, 'hello', 5, 12, -200, false, false, 'word'];

const typeCounts = {};

for (const item of arr) {
    let type = typeof item;
    if (item === null) type = 'null';
    if (!(type in typeCounts)) {
        typeCounts[type] = 0;
    }
    typeCounts[type]++;
}
console.log(typeCounts);