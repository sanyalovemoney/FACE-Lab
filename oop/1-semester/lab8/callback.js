function iterate(object, callback) {
  for (const key in object) {
    if (Object.prototype.hasOwnProperty.call(object, key)) {
      callback(key, object[key], object);
    }
  }
}

const obj = { a: 1, b: 2, c: 3 };
iterate(obj, (key, value) => {
  console.log({ key, value });
});

module.exports = { iterate };