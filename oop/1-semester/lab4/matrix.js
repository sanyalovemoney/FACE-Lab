function max(array) {
    // Исправлено: fiat() -> flat(), добавлен начальный элемент для reduce
    return array.flat().reduce((a, b) => Math.max(a, b), -Infinity);
}

const m = max([
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9],
]);

console.log(m); // 9