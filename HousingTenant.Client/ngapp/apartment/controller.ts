import { apartmentModule as am } from './module';
import * as d3 from 'd3';
import './service';

var address = {
      Address1: "2100 Wilkes Court",
      Address2: "",
      ApartmentNumber: "102",
      City: "Herndon",
      State: "Virginia",
      ZipCode: "20170"
};

var apartmentController = am.controller('aptCtrl', ['$scope', 'aptFactory', function ($scope, aptFactory) {
      $scope.aptGuid = localStorage.getItem('aptGuid');
      console.log(localStorage.getItem('aptGuid'));
      $scope.getPie = function (data) {
            //basic info about the shape
            var width = 300;
            var height = 300;
            var radius = Math.min(width, height) / 2;
            //color palette
            var color = d3.scaleOrdinal().range(["#2C93E8", "#FF4C4C", "#838690", "#F56C4E"]);
            //console.log(color);
            //computes angles
            var pie = d3.pie().value(function (d) { return d.count; })(data);
            //console.log(pie);
            //arc for chart
            var pieArc = d3.arc().outerRadius(radius - 10).innerRadius(0);
            //console.log(pieArc);
            //arc for labels
            var labelArc = d3.arc().outerRadius(radius).innerRadius(radius - 100);
            //console.log(labelArc);
            //scalable vector graphic
            var svg = d3.select('#chart')
                  .append('svg')
                  .attr('width', width)
                  .attr('height', height)
                  .append('g')
                  .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");
            //console.log(svg);
            //generate groups to hold paths
            var g = svg.selectAll('arc')
                  .data(pie)
                  .enter().append('g')
                  .attr('class', 'arc');
            //console.log(g);
            //append colors
            g.append('path')
                  .attr('d', pieArc)
                  .style('fill', function (d) { return color(d.data.label); });
            //append labels
            g.append("text")
                  .attr("transform", function (d) { return "translate(" + labelArc.centroid(d) + ")"; })
                  .text(function (d) { return d.data.label; })
                  .style("fill", "#fff");
      }

      aptFactory.getApartmentByGuid($scope, $scope.aptGuid, $scope.getPie);

}]);