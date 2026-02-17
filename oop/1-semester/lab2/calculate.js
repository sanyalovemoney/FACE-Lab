'use strict';
const average = (a, b) => (a + b) / 2; // функція для обчислення середнього арифметичного
console.log(average(2, 6));

const square = x => x * x;  // функція для обчислення квадрата числа
console.log(square(5)); 

const cube = x => x ** 3; // функція для обчислення куба числа
console.log(cube(3)); 

// Додаємо функцію calculate
function calculate () { 
    const result = []; 
    for (let i = 0; i <= 9; i++) { 
        const sq = square(i);
        const cb = cube(i); 
        const avg = average(sq, cb);  
        result.push(avg);  
    }
    return result;
}
console.log(calculate()); 

module.exports = { average, square, cube, calculate }; // експорт функцій для використання в інших файлах