module.exports = function(config) {
  config.set({
    basePath: '.',

    frameworks: [
      'jasmine'
    ],

    ///used to put files together if webpack was not added
    files: [
      'test/index.js'
    ],

    exclude: [
    ],

    preprocessors: {
      'test/index.js': ['webpack']
    },

    reporters: [
      'progress'
    ],

    port: 9000,

    colors: true,

    logLevel: config.LOG_INFO,

    autoWatch: true,

    browsers: [
      'Chrome',
      'Firefox',
      'Safari'
    ],

    singleRun: false,

    concurrency: Infinity
  });
};
