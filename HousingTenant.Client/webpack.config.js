var path = require('path');

module.exports = {
    entry: "./ngapp/index.ts",
    output: {
        filename: "js/script.bundle.js",
        path: path.resolve(__dirname, './public')
    },
    resolve: {
    // Add `.ts` and `.tsx` as a resolvable extension.
    extensions: ['.ts', '.tsx', '.js']
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use: [
                    'file-loader?name=[name].[ext]&outputPath=css/'
                ]
            },
            // {
            //     test: /\.html$/,
            //     use: [
            //         'file-loader?name=[name].[ext]&outputPath=html/'
            //     ]
            // },
            {
                test: /\.ts$/,
                use: [
                    'ts-loader'
                ]
            }

        ]
    }
}
