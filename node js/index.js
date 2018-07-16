const fs = require("fs");
const [f, k] = process.argv.slice(-2);

const data = fs.readFileSync(f, "utf8").toUpperCase().match(/[A-Z]+/g);

[...new Set(data)]
  .map(e => [e, data.filter(w => w === e).length])
  .sort((a, b) => b[1] - a[1])
  .forEach((e, i) => i < k && console.log(`${e[1]} ${e[0]}`));