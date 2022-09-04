var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ChartService = class ChartService {
    chart(nativeElement, options) {
        console.log(options);
        return window['Highcharts'].chart(nativeElement, options);
    }
    column(title, series) {
        return new Object({
            chart: { type: 'column' },
            title: { text: title },
            series: series
        });
    }
    line(title, series) {
        return new Object({
            series: series,
            title: { text: title }
        });
    }
    pie(title, series) {
        return new Object({
            chart: { type: 'pie' },
            title: { text: title },
            series: [{
                    name: title,
                    colorByPoint: true,
                    data: series
                }]
        });
    }
};
ChartService = __decorate([
    Service({
        name: '$charts'
    })
], ChartService);
