module.exports = {
  entry: "./jsbin/index.js",
  output: {
    filename: "./public/js/script.bundle.js"
  },
   module: {
        loaders: [
            { test: /\.html$/, loader: "html" }
        ]
    }
}
