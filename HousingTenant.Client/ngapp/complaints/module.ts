import * as ng from 'angular';
import 'angular-material'

import 'file-loader?name=[name].[ext]&outputPath=ngapp/complaints/partials/!./partials/template.html';

var complaintModule = ng.module('complaintModule', ['ngMaterial'])

export{complaintModule};