(([f, k] = process.argv.slice(-2)) =>
  Object.entries(
    require("fs")
      .readFileSync(f, "utf8")
      .toUpperCase()
      .match(/[A-Z]+/g)
      .reduce((c, w) => ({ ...c, [w]: ++c[w] || 1 }), {})
  )
    .sort((a, b) => b[1] - a[1])
    .some((e, i) => (i < k ? console.log(`${e[1]} ${e[0]}`) : true)))();
