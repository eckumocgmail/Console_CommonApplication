var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ColumnChartComponent = class ColumnChartComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $charts) {
        super($scope, $element, $attrs, $injector);
        this.type = 'column';
        this.title = '�������� ���������';
        this.yaxis = '���� � ������';
        this.series = [
            { name: 'Subject 1', data: [123, 232] },
            { name: 'Subject 2', data: [523, 432] }
        ];
        this.id = 'undefined';
        this.id = $element[0].id = 'scope-' + $scope.$id;
        $element[0].style.height = '1000px';
        this.$charts = $charts;
        $scope.chart = this;
        window['chart'] = this;
        const ctrl = this;
        ctrl.update();
        setTimeout(() => { ctrl.update(); }, 1500);
    }
    update() {
        console.log(this);
        const options = new Object({
            chart: { type: this.type },
            title: { text: this.title },
            series: this.$scope.chart.series,
            yAxis: {
                title: {
                    text: this.yaxis
                },
                labels: {
                    formatter: function () {
                        return this.value;
                    }
                },
                min: 0
            },
        });
        if (!this.$element[0]) {
            console.error('chartElement undefined in StructureChartComponent');
        }
        else {
            const widget = this.$charts.chart(document.getElementById(this.id), options);
        }
    }
    $onInit() {
        this.$scope.$emit({
            event: 'init',
            source: this
        });
    }
    $onDestroy() {
        this.$scope.$emit({
            event: 'destroy',
            source: this
        });
    }
    $onChanges(changes) {
        Object.assign(this.$scope, this.ctrl);
        this.update();
    }
};
ColumnChartComponent = __decorate([
    specification({
        icon: 'insert_chart',
        label: 'Chart component',
        tooltip: 'a'
    }),
    Component({
        selector: 'columnChart',
        template: '<div #node style="width: 1000px; height: 1000px;"></div>',
        input: []
    })
], ColumnChartComponent);
