module.exports = function(config) {
  config.set({
    basePath: '.',

    frameworks: [
      'jasmine'
    ],

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
