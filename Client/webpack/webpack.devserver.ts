import path from 'path';
import webpackMerge from 'webpack-merge';
import devConfig from './webpack.dev';

export default webpackMerge(devConfig, {
    devServer: {
        contentBase: path.resolve(__dirname, '../dist'),
        compress: true,
        port: 9000,
        hot: true,
        disableHostCheck: true,
        publicPath: '/',
        historyApiFallback: true,
    },
});
