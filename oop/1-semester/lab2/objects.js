'use strict';

// обєкти 
const fn = () => {
    const obj1 = { name: "Oleksandr" };
    let obj2 = { name: "Ivan" };

    obj1.name = "Igor"; // змінюємо властивість name об'єкта obj1
    obj2.name = "Petro"; // змінюємо властивість name об'єкта obj2

    return { obj1, obj2 };
}

function createUser(name, city) {
    return { name, city };
}
console.log(createUser('Oleksand', 'Kyiv'));
module.exports = { fn, createUser };
