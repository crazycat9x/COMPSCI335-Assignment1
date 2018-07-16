const fs = require("fs");
const [fileName, k] = process.argv.slice(-2);

const data = fs
  .readFileSync(fileName, "utf8")
  .toUpperCase()
  .split(/[^A-Z]+/)
  .filter(word => word);

[...new Set(data)]
  .map(element => [element, data.filter(word => word === element).length])
  .sort((a, b) => b[1] - a[1])
  .forEach((element, index) => index < k && console.log(`${element[1]} ${element[0]}`));