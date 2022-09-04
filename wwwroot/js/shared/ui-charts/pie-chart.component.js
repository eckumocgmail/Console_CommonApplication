var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let PieChartComponent = class PieChartComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $charts) {
        super($scope, $element, $attrs, $injector);
        this.type = 'pie';
        this.title = 'column chart';
        this.series = [{
                name: 'Brands',
                colorByPoint: true,
                data: [{
                        name: 'Sogou Explorer',
                        y: 1.64
                    }, {
                        name: 'Opera',
                        y: 1.6
                    }, {
                        name: 'QQ',
                        y: 1.2
                    }, {
                        name: 'Other',
                        y: 2.61
                    }]
            }];
        window['chart'] = this;
        this.$charts = $charts;
        setTimeout(() => { this.update(); }, 2000);
    }
    update() {
        const options = new Object({
            series: this.series,
            title: { text: this.title }
        });
        if (!this.$element[0]) {
            console.error('chartElement undefined in StructureChartComponent');
        }
        else {
            this.$charts.chart(this.$element[0], options);
        }
    }
};
PieChartComponent = __decorate([
    specification({
        icon: 'insert_chart',
        label: 'Chart component',
        tooltip: 'a'
    }),
    Component({
        selector: 'pieChart',
        template: '<div #node style="width: 100%; height: 100%;"></div>',
        input: ['title', 'type', 'series']
    })
], PieChartComponent);
