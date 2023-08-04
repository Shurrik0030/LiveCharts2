﻿using System.Collections.Generic;
using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Extensions;

namespace ViewModelsSamples.Pies.Gauge1;

public partial class ViewModel : ObservableObject
{
    public IEnumerable<ISeries> Series { get; set; } =
        GaugeGenerator.Build(
            new GaugeItem(
                30,          // the gauge value
                series =>    // the series style
                {
                    series.MaxRadialColumnWidth = 50;
                    series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle;
                }));
}
