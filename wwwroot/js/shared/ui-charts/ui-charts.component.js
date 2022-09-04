var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let UiChartsComponent = class UiChartsComponent {
    constructor() {
        this.components = [
            ChartsComponent,
            LineChartComponent,
            ColumnChartComponent,
            PieChartComponent,
            BarChartComponent,
            AreaChartComponent
        ];
    }
    ngOnInit() {
    }
};
UiChartsComponent = __decorate([
    specification({
        icon: 'view_headline',
        label: 'selectbox',
        tooltip: 'Selectbox element provider interface to select from drop-down list.'
    }),
    Component({
        selector: 'uiCharts',
        template: `
    <div>
      <h2> ui-charts </h2>
      <!-- <ui-radiogroup-element [options]="switch.types" [selected]="switch.type" (onChanged)="switch.type=$event;"></ui-radiogroup-element>
      <ui-selectbox-element [options]="switch.types" [selected]="switch.type" (onChanged)="switch.type=$event;"></ui-selectbox-element>
      <switch-component [components]="components" #switch></switch-component> -->
    </div>
  `
    })
], UiChartsComponent);
