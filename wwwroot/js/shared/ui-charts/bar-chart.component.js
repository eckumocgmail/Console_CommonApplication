var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let BarChartComponent = class BarChartComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $charts) {
        super($scope, $element, $attrs, $injector);
        this.type = 'bar';
        this.title = 'column chart';
        this.series = [
            { name: 'Subject 1', data: [130, 422, 123, 232] },
            { name: 'Subject 2', data: [230, 420, 523, 432] },
            { name: 'Subject 3', data: [130, 320, 123, 432] },
        ];
        window['chart'] = this;
        this.$charts = $charts;
        setTimeout(() => { this.update(); }, 2000);
    }
    ngOnInit() {
        this.update();
    }
    ngOnChanges(changes) {
        this.update();
    }
    update() {
        const options = new Object({
            chart: { type: this.type },
            title: { text: this.title },
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
    controlTypes.selectbox(["area", "pie", "line", "bar", "spline", "column"])
], BarChartComponent.prototype, "type", void 0);
__decorate([
    validators.required(true),
    validators.minLength(5)
], BarChartComponent.prototype, "title", void 0);
BarChartComponent = __decorate([
    specification({
        icon: 'insert_chart',
        label: 'Chart component',
        tooltip: 'a'
    }),
    Component({
        selector: 'barChart',
        template: '<div #node style="width: 100%; height: 100%;"></div>',
        input: ['title',
            'series'
        ]
    })
], BarChartComponent);
