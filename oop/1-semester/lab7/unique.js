function unique(array) { 
    return [...new Set(array)]; 
}

const result = unique([2, 1, 1, 3, 2]);
console.log(result);
// Результат: [2, 1, 3]

const result2 = unique(['top', 'bottom', 'top', 'left']); 
console.log(result2); 
// Результат: ['top', 'bottom', 'left']


module.exports = {unique};