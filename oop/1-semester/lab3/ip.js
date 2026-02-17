
'use strict';

const ipToint = (ip = '127.0.0.1') => { // преобразование IP в число
    return ip
        .split('.') 
        .map(Number) // преобразование в число
        .reduce ((acc, octer, byte) => 
            acc + (octer << (( 3 - byte) * 8)), // сдвиг влево на 8 бит 
        0);
}
console.log(ipToint('10.0.0.1'));
console.log(ipToint('127.0.0.1'));
console.log(ipToint('192.168.1.10'));
console.log(ipToint('165.225.133.150'));
module.exports = { ipToint };
