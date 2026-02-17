'use strict';

const generateKey = (length, characters) => { // генерация ключа
    const chars = characters || 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789'; // набор символов по умолчанию
    const base = chars.length; 
    let key = ''; 
    for (let i = 0; i < length; i++) {  
        const index = Math.floor(Math.random() * base); 
        key += chars[index];  
    }

    return key; 
};
console.log(generateKey(16));
module.exports = { generateKey };
