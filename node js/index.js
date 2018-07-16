const fs = require("fs");

const [fileName, k] = process.argv.slice(-2);

const data = fs
  .readFileSync(fileName, "utf8")
  .replace(/[\W\s0-9]+/gi, " ")
  .toUpperCase()
  .trim()
  .split(" ");

[...new Set(data)]
  .map(element => [
    element,
    data.reduce((accumulator, currentValue) => {
      return currentValue === element ? ++accumulator : accumulator;
    }, 0)
  ])
  .sort((a, b) => b[1] - a[1])
  .forEach(
    (element, index) => index < k && console.log(`${element[1]} ${element[0]}`)
  );