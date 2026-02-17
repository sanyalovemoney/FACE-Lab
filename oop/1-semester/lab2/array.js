const phoneBook = [ // масив обєктів
    {name : "Andrey" , phone : "+491517244980" },
    {name : "Oleksandr" , phone : "+380689980025"}, 
    {name : "Oleksiy" , phone : "+38098065684"},
    {name : "Maksim" , phone : "+380967164101"}
];

function findPhoneByName(name) { // пошук телефону по імені
    for (let i = 0; i < phoneBook.length; i++) {
        if (phoneBook[i].name === name) {
            return phoneBook[i].phone;
        }
    }
    return "Name not found";
}
function findNameByPhone(phone) { // пошук імені по телефону
    for (let i = 0; i < phoneBook.length; i++) { 
        if (phoneBook[i].phone === phone) { 
            return phoneBook[i].name; 
        }
    }
    return "phone not found";
}

console.log(findPhoneByName("Oleksandr")); // +380689980025
console.log(findPhoneByName("Oleksiy")); // +38098065684
console.log(findPhoneByName("Taras")); // Name not found

console.log(findNameByPhone("+491517244980")); // Andrey
console.log(findNameByPhone("+380967164101")); // Maksim
console.log(findNameByPhone("+380123456789")); // Phone not found