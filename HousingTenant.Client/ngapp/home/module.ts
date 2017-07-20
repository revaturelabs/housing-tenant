import * as ng from 'angular';
import 'angular-material';

import 'file-loader?name=[name].[ext]&outputPath=ngapp/home/partials/!./partials/template.html';

var home = ng.module('ngHome',['ngMaterial']);

export { home };