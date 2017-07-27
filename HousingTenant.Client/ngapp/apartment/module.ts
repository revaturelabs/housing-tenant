import * as ng from 'angular';
   
import 'file-loader?name=[name].[ext]&outputPath=ngapp/apartment/partials/!./partials/template.html';

var apartmentModule = ng.module('aptModule', []);

export{apartmentModule}; 