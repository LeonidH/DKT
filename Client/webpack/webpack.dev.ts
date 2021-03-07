import DotenvWebpack from 'dotenv-webpack';
import path from 'path';
import sass from 'sass';
import { HotModuleReplacementPlugin } from 'webpack';
import webpackMerge from 'webpack-merge';
import commonConfig from './webpack.common';

export default webpackMerge(commonConfig, {
    mode: 'development',
    devtool: 'eval',
    output: {
        filename: '[name].bundle.js',
        chunkFilename: '[name].chunk.js',
    },
    plugins: [
        new HotModuleReplacementPlugin(),
        new DotenvWebpack({
            safe: true,
            silent: false,
            path: path.resolve(__dirname, '../.env.example'),
        }),
    ],
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: [
                    'style-loader',
                    {
                        loader: 'css-loader',
                        options: {
                            modules: true,
                            camelCase: true,
                            localIdentName: '[name]-[local]-[hash:base64:5]',
                        },
                    },
                    'resolve-url-loader',
                    {
                        loader: 'sass-loader',
                        options: {
                            implementation: sass,
                            sassOptions: {
                                includePaths: [path.resolve(__dirname, '../src/styles/theme')],
                            },
                        },
                    },
                ],
            },
        ],
    },
});
