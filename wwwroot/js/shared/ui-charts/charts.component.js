var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
class SeriesDataPoint {
    constructor() {
        this.name = 'data point';
        this.data = [1, 2, 3];
    }
}
let ChartsComponent = class ChartsComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, container, $charts) {
        super($scope, $element, $attrs, $injector);
        this.type = 'area';
        this.title = 'column chart';
        this.xAxisTitle = '';
        this.xAxisValues = [];
        this.yAxisTitle = '';
        this.yAxisValues = [];
        this.series = [
            { name: 'Subject 1', data: [130, 422, 123, 232] },
            { name: 'Subject 2', data: [230, 420, 523, 432] },
            { name: 'Subject 3', data: [130, 320, 123, 432] },
        ];
        this.credits = {
            enabled: false
        };
        this.tooltip = {
            formatter: function () {
                return 'x: ' + this.charts.dateFormat('%e %b %y %H:%M:%S', this.x) +
                    ' y: ' + this.y.toFixed(2);
            }
        };
        this.xAxis = {
            labels: {
                formatter: function () {
                    return this.charts.dateFormat('%e %b %y', this.value);
                }
            }
        };
        this.$charts = $charts;
    }
    ngOnInit() {
        this.update();
    }
    ngOnChanges(changes) {
        console.log('changes', this);
        this.update();
    }
    update() {
        const options = new Object({
            chart: { type: this.type },
            title: { text: this.title },
            credits: this.credits,
            tooltip: this.tooltip,
            xAxis: {
                text: this.xAxisTitle,
            },
            yAxis: {
                title: this.yAxisTitle,
                categories: this.yAxisValues
            },
            series: this.series
        });
        if (!this.$element[0]) {
            console.error('chartElement undefined in StructureChartComponent');
        }
        else {
            const widget = this.$charts.chart(this.$element[0], options);
        }
    }
};
__decorate([
    controlTypes.selectbox(['area', 'pie', 'line', 'bar', 'spline', 'column'])
], ChartsComponent.prototype, "type", void 0);
__decorate([
    validators.required(true),
    validators.minLength(5)
], ChartsComponent.prototype, "title", void 0);
__decorate([
    validators.required(true),
    inputTypes.text()
], ChartsComponent.prototype, "xAxisTitle", void 0);
__decorate([
    validators.required(true)
], ChartsComponent.prototype, "xAxisValues", void 0);
__decorate([
    validators.required(true),
    inputTypes.text()
], ChartsComponent.prototype, "yAxisTitle", void 0);
__decorate([
    validators.required(true)
], ChartsComponent.prototype, "yAxisValues", void 0);
__decorate([
    structureTypes.array(new SeriesDataPoint())
], ChartsComponent.prototype, "series", void 0);
ChartsComponent = __decorate([
    specification({
        icon: 'insert_chart',
        label: 'Chart component',
        tooltip: 'a'
    }),
    Component({
        selector: 'chart',
        template: '<div #node style="width: 100%; height: 100%;"></div>',
        input: ['title',
            'type',
            'series',
            'xAxisTitle',
            'xAxisValues',
            'yAxisTitle',
            'yAxisValues',
        ]
    })
], ChartsComponent);
