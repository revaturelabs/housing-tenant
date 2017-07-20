var unitTestSuite = require.context(".", true, /\.spec.js$/);
unitTestSuite.keys().forEach(unitTestSuite);
