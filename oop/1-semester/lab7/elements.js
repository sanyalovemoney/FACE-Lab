const removeElements = (array, ...items) => {
    items.forEach(item => {
        const index = array.indexOf(item);
        if (index !== -1) array.splice(index, 1);
    });
}

const array = [1, 2, 3, 4, 5, 6, 7];
removeElements(array, 5, 1, 6); // удалит 5, 1 и 6 из массива
console.log(array);
// Результат: [2, 3, 4, 7]

const array2 = ['Kiev', 'Beijing', 'Lima', 'Saratov'];
removeElements(array2, 'Lima', 'Berlin', 'Kiev'); // удалит 'Lima' и 'Kiev' из массива, 'Berlin' не удалит, так как его нет в массиве
console.log(array2)
// Результат: ['Beijing', 'Saratov']


module.exports = {removeElements};