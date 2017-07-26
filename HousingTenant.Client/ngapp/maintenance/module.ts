import * as ng from 'angular';
import 'angular-material';

import 'file-loader?name=[name].[ext]&outputPath=ngapp/maintenance/partials/!./partials/template.html';

var maintenanceModule = ng.module('maintenanceModule', ['ngMaterial']);

export{maintenanceModule};