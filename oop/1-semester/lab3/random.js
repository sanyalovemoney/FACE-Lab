'use strict';

const random =(min,max) => { // генерация случайного числа
    if (max === undefined) {
        max = min;
        min = 0;
    }
    return Math.floor(Math.random() * (max - min + 1)) + min; // случайное число от min до max включительно
};
console.log(random(10)); 
console.log(random(1,10)); 
console.log(random(100,1000)); 

module.exports = random;