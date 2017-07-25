import * as ng from 'angular';
import 'angular-material';

import 'file-loader?name=[name].[ext]&outputPath=ngapp/supplies/partials/!./partials/template.html';

var supplyModule = ng.module('supplyModule', ['ngMaterial']); 

export{supplyModule};