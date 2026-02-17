function difference(array1, array2) { 
    return array1.filter(item => !array2.includes(item)); 
}

const array1 = [7, -2, 10, 5, 0];
const array2 = [0, 10];
const result = difference(array1, array2);  // удалит 0 и 10 из первого массива
console.log(result);
// Результат: [7, -2, 5]

const array3 = ['Beijing', 'Kiev'];
const array4 = ['Kiev', 'London', 'Baghdad'];
const result2 = difference(array3, array4);  // удалит 'Kiev' из первого массива
console.log(result2);
// Результат: ['Beijing']



module.exports = { difference };