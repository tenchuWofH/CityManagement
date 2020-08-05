module.exports = {
  configureWebpack: {
    devtool: 'source-map',
  },
  // devServer: {
  //   proxy: {
  //     '/api': {
  //       target: 'https://localhost:44347/', // http://localhost:8888', // target host
  //       ws: true, // proxy websockets
  //       changeOrigin: true, // needed for virtual hosted sites
  //     },
  //   },
  // },
};
