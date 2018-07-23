const fs = require("fs");

Object.prototype.toArray = function() {
  return Object.entries(this);
};

async function main() {
  const [f, k] = process.argv.slice(-2);
  if (process.argv.length != 4) throw "wrong number of arguments";
  if (!/^\+?(0|[1-9]\d*)$/.test(k)) throw "k is not a valid number";
  if (!/.txt$/.test(f)) throw `${f} is not a valid txt file`;
  fs.readFileSync(f, "utf8")
    .toUpperCase()
    .match(/[A-Z]+/g)
    .reduce((c, w) => ({ ...c, [w]: ++c[w] || 1 }), {})
    .toArray()
    .sort((a, b) => b[1] - a[1] || a[0].localeCompare(b[0]))
    .some((e, i) => (i < k ? console.log(`${e[1]} ${e[0]}`) : true));
}

main().catch(ex => console.log(`*** Error: ${ex.message || ex}`));
