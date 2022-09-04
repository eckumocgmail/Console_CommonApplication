using HospitalConstructor.Shared.HealthIndicators;
using System;

[Icon("bar-chart")]
[Label(@"Монитор показателей жизнедейятельности организма. ")]
[Description("Показатели: дыхание, пульс, температура, сердечный ритм")]
public class HealthMonitor
{

    [NotNullNotEmpty()]
    public TemperatureIndicator Temperature { get; set; }

    [NotNullNotEmpty()]
    public PressureIndicator Presure { get; set; }



    public Action<PropertyChangedMessage> OnChanges { get; set; } = (evt) => { };


}
