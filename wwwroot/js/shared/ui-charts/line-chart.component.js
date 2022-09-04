var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let LineChartComponent = class LineChartComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $charts) {
        super($scope, $element, $attrs, $injector);
        window['chart'] = this;
        this.$charts = $charts;
        setTimeout(() => { this.update(); }, 2000);
    }
    update() {
        if (!this.$element[0]) {
            console.error('chartElement undefined in StructureChartComponent');
        }
        else {
            this.$charts.chart(this.$element[0], {
                chart: this.chart,
                title: this.title,
                tooltip: this.tooltip,
                accessibility: this.accessibility,
                plotOptions: this.plotOptions,
                series: this.series
            });
        }
    }
};
LineChartComponent = __decorate([
    specification({
        icon: 'insert_chart',
        label: 'Chart component',
        tooltip: 'a'
    }),
    Component({
        selector: 'lineChart',
        template: '<div id="line-chart" style="width: 100%; height: 100%;"></div>',
        input: ['title', 'type',
            'series'
        ]
    })
], LineChartComponent);
