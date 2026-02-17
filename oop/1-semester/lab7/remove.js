const removeElement = (arr, element) => { 
    const index = arr.indexOf(element); 
    if (index !== -1) arr.splice(index, 1);
}

const array = [1, 2, 3, 4, 5, 6, 7]; 
removeElement(array, 5); // удалит 5 из массива
console.log(array);
// Результат: [1, 2, 3, 4, 6, 7]
const array2 = ['Kiev', 'Beijing', 'Lima', 'Saratov'];
removeElement(array2, 'Lima'); // удалит 'Lima' из массива
removeElement(array2, 'Berlin'); // не удалит ничего
console.log(array2);
// Результат: ['Kiev', 'Beijing', 'Saratov']


module.exports = {removeElement}; 