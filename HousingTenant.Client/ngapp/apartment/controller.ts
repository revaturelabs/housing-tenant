import { apartmentModule as am } from './module';
import * as d3 from 'd3';
import './service';

var apartmentController = am.controller('aptCtrl', ['$scope', 'aptFactory', function ($scope, aptFactory) {
      $scope.aptGuid = localStorage.getItem('aptGuid');

      $scope.getPie = function (data) {
            //basic info about the shape
            var width = 300;
            var height = 300;
            var radius = Math.min(width, height) / 2;
            //color palette
            var color = d3.scaleOrdinal().range(["#2C93E8", "#FF4C4C", "#838690", "#F56C4E"]);
            //computes angles
            var pie = d3.pie().value(function (d) { return d.count; })(data);
            //arc for chart
            var pieArc = d3.arc().outerRadius(radius - 10).innerRadius(0);
            //arc for labels
            var labelArc = d3.arc().outerRadius(radius).innerRadius(radius - 100);
            //scalable vector graphic
            var svg = d3.select('#chart')
                  .append('svg')
                  .attr('width', width)
                  .attr('height', height)
                  .append('g')
                  .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");
            //generate groups to hold paths
            var g = svg.selectAll('arc')
                  .data(pie)
                  .enter().append('g')
                  .attr('class', 'arc');
            //append colors
            g.append('path')
                  .attr('d', pieArc)
                  .style('fill', function (d) { return color(d.data.label); });
            //append labels
            g.append("text")
                  .attr("transform", function (d) { return "translate(" + labelArc.centroid(d) + ")"; })
                  .text(function (d) {
                        if (d.data.count > 0)
                              return d.data.label;
                  })
                  .style("fill", "#fff");
      }

      aptFactory.getApartmentByGuid($scope, $scope.aptGuid, $scope.getPie);

}]);