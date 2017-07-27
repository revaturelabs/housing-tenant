import * as ng from 'angular';
import 'angular-material';

import 'file-loader?name=[name].[ext]&outputPath=ngapp/move/partials/!./partials/template.html';

var moveModule = ng.module('moveModule', ['ngMaterial']);

export{moveModule};