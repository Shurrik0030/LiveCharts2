﻿using System;
using LiveChartsCore.Drawing;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.SkiaSharpView.VisualElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiaSharp;

namespace LiveChartsCore.UnitTesting.OtherTests;

[TestClass]
public class ScaleFunctionsTests
{
    [TestMethod]
    public void CartesianBasicScale()
    {
        var chart = new SKCartesianChart
        {
            Width = 500,
            Height = 500,
            Series = new[]
            {
                new ScatterSeries<double>
                {
                    Values = new double[] { 0, 1, 2 },
                    DataPadding = new LvcPoint(0, 0)
                }
            },
            DrawMarginFrame = new DrawMarginFrame() { Stroke = new SolidColorPaint(SKColors.Yellow, 5) }
        };

        _ = chart.GetImage();

        var location = chart.Core.DrawMarginLocation;
        var size = chart.Core.DrawMarginSize;

        var p00 = chart.ScaleDataToPixels(new LvcPointD(0, 0));
        Assert.IsTrue(
            Math.Abs(p00.X - location.X) < 0.01 &&
            Math.Abs(p00.Y - (location.Y + size.Height)) < 0.01);

        var p33 = chart.ScaleDataToPixels(new LvcPointD(2, 2));
        Assert.IsTrue(
            Math.Abs(p33.X - (location.X + size.Width)) < 0.01 &&
            Math.Abs(p33.Y - location.Y) < 0.01);

        var d00 = chart.ScalePixelsToData(new LvcPointD(location.X, location.Y + size.Height));
        Assert.IsTrue(
            Math.Abs(d00.X - 0) < 0.01 &&
            Math.Abs(d00.Y - 0) < 0.01);

        var d33 = chart.ScalePixelsToData(new LvcPointD(location.X + size.Width, location.Y));
        Assert.IsTrue(
            Math.Abs(d33.X - 2) < 0.01 &&
            Math.Abs(d33.Y - 2) < 0.01);
    }

    [TestMethod]
    public void CartesianTitleAndLegendsTopScale()
    {
        var chart = new SKCartesianChart
        {
            Width = 500,
            Height = 500,
            Series = new[]
            {
                new ScatterSeries<double>
                {
                    Values = new double[] { 0, 1, 2 },
                    DataPadding = new LvcPoint(0, 0)
                }
            },
            DrawMarginFrame = new DrawMarginFrame() { Stroke = new SolidColorPaint(SKColors.Yellow, 5) },
            LegendPosition = LegendPosition.Top,
            Title = new LabelVisual
            {
                Text = "My chart title",
                TextSize = 25,
                Padding = new Padding(10),
                Paint = new SolidColorPaint(SKColors.White),
                BackgroundColor = SKColors.Purple.AsLvcColor()
            }
        };

        _ = chart.GetImage();

        var location = chart.Core.DrawMarginLocation;
        var size = chart.Core.DrawMarginSize;

        var p00 = chart.ScaleDataToPixels(new LvcPointD(0, 0));
        Assert.IsTrue(
            Math.Abs(p00.X - location.X) < 0.01 &&
            Math.Abs(p00.Y - (location.Y + size.Height)) < 0.01);

        var p33 = chart.ScaleDataToPixels(new LvcPointD(2, 2));
        Assert.IsTrue(
            Math.Abs(p33.X - (location.X + size.Width)) < 0.01 &&
            Math.Abs(p33.Y - location.Y) < 0.01);

        var d00 = chart.ScalePixelsToData(new LvcPointD(location.X, location.Y + size.Height));
        Assert.IsTrue(
            Math.Abs(d00.X - 0) < 0.01 &&
            Math.Abs(d00.Y - 0) < 0.01);

        var d33 = chart.ScalePixelsToData(new LvcPointD(location.X + size.Width, location.Y));
        Assert.IsTrue(
            Math.Abs(d33.X - 2) < 0.01 &&
            Math.Abs(d33.Y - 2) < 0.01);
    }

    [TestMethod]
    public void CartesianTitleAndLegendsBottomScale()
    {
        var chart = new SKCartesianChart
        {
            Width = 500,
            Height = 500,
            Series = new[]
            {
                new ScatterSeries<double>
                {
                    Values = new double[] { 0, 1, 2 },
                    DataPadding = new LvcPoint(0, 0)
                }
            },
            DrawMarginFrame = new DrawMarginFrame() { Stroke = new SolidColorPaint(SKColors.Yellow, 5) },
            LegendPosition = LegendPosition.Bottom,
            Title = new LabelVisual
            {
                Text = "My chart title",
                TextSize = 25,
                Padding = new Padding(10),
                Paint = new SolidColorPaint(SKColors.White),
                BackgroundColor = SKColors.Purple.AsLvcColor()
            }
        };

        _ = chart.GetImage();

        var location = chart.Core.DrawMarginLocation;
        var size = chart.Core.DrawMarginSize;

        var p00 = chart.ScaleDataToPixels(new LvcPointD(0, 0));
        Assert.IsTrue(
            Math.Abs(p00.X - location.X) < 0.01 &&
            Math.Abs(p00.Y - (location.Y + size.Height)) < 0.01);

        var p33 = chart.ScaleDataToPixels(new LvcPointD(2, 2));
        Assert.IsTrue(
            Math.Abs(p33.X - (location.X + size.Width)) < 0.01 &&
            Math.Abs(p33.Y - location.Y) < 0.01);

        var d00 = chart.ScalePixelsToData(new LvcPointD(location.X, location.Y + size.Height));
        Assert.IsTrue(
            Math.Abs(d00.X - 0) < 0.01 &&
            Math.Abs(d00.Y - 0) < 0.01);

        var d33 = chart.ScalePixelsToData(new LvcPointD(location.X + size.Width, location.Y));
        Assert.IsTrue(
            Math.Abs(d33.X - 2) < 0.01 &&
            Math.Abs(d33.Y - 2) < 0.01);
    }

    [TestMethod]
    public void CartesianTitleAndLegendsLeftScale()
    {
        var chart = new SKCartesianChart
        {
            Width = 500,
            Height = 500,
            Series = new[]
            {
                new ScatterSeries<double>
                {
                    Values = new double[] { 0, 1, 2 },
                    DataPadding = new LvcPoint(0, 0)
                }
            },
            DrawMarginFrame = new DrawMarginFrame() { Stroke = new SolidColorPaint(SKColors.Yellow, 5) },
            LegendPosition = LegendPosition.Left,
            Title = new LabelVisual
            {
                Text = "My chart title",
                TextSize = 25,
                Padding = new Padding(10),
                Paint = new SolidColorPaint(SKColors.White),
                BackgroundColor = SKColors.Purple.AsLvcColor()
            }
        };

        _ = chart.GetImage();

        var location = chart.Core.DrawMarginLocation;
        var size = chart.Core.DrawMarginSize;

        var p00 = chart.ScaleDataToPixels(new LvcPointD(0, 0));
        Assert.IsTrue(
            Math.Abs(p00.X - location.X) < 0.01 &&
            Math.Abs(p00.Y - (location.Y + size.Height)) < 0.01);

        var p33 = chart.ScaleDataToPixels(new LvcPointD(2, 2));
        Assert.IsTrue(
            Math.Abs(p33.X - (location.X + size.Width)) < 0.01 &&
            Math.Abs(p33.Y - location.Y) < 0.01);

        var d00 = chart.ScalePixelsToData(new LvcPointD(location.X, location.Y + size.Height));
        Assert.IsTrue(
            Math.Abs(d00.X - 0) < 0.01 &&
            Math.Abs(d00.Y - 0) < 0.01);

        var d33 = chart.ScalePixelsToData(new LvcPointD(location.X + size.Width, location.Y));
        Assert.IsTrue(
            Math.Abs(d33.X - 2) < 0.01 &&
            Math.Abs(d33.Y - 2) < 0.01);
    }

    [TestMethod]
    public void CartesianTitleAndLegendsRightScale()
    {
        var chart = new SKCartesianChart
        {
            Width = 500,
            Height = 500,
            Series = new[]
            {
                new ScatterSeries<double>
                {
                    Values = new double[] { 0, 1, 2 },
                    DataPadding = new LvcPoint(0, 0)
                }
            },
            DrawMarginFrame = new DrawMarginFrame() { Stroke = new SolidColorPaint(SKColors.Yellow, 5) },
            LegendPosition = LegendPosition.Right,
            Title = new LabelVisual
            {
                Text = "My chart title",
                TextSize = 25,
                Padding = new Padding(10),
                Paint = new SolidColorPaint(SKColors.White),
                BackgroundColor = SKColors.Purple.AsLvcColor()
            }
        };

        _ = chart.GetImage();

        var location = chart.Core.DrawMarginLocation;
        var size = chart.Core.DrawMarginSize;

        var p00 = chart.ScaleDataToPixels(new LvcPointD(0, 0));
        Assert.IsTrue(
            Math.Abs(p00.X - location.X) < 0.01 &&
            Math.Abs(p00.Y - (location.Y + size.Height)) < 0.01);

        var p33 = chart.ScaleDataToPixels(new LvcPointD(2, 2));
        Assert.IsTrue(
            Math.Abs(p33.X - (location.X + size.Width)) < 0.01 &&
            Math.Abs(p33.Y - location.Y) < 0.01);

        var d00 = chart.ScalePixelsToData(new LvcPointD(location.X, location.Y + size.Height));
        Assert.IsTrue(
            Math.Abs(d00.X - 0) < 0.01 &&
            Math.Abs(d00.Y - 0) < 0.01);

        var d33 = chart.ScalePixelsToData(new LvcPointD(location.X + size.Width, location.Y));
        Assert.IsTrue(
            Math.Abs(d33.X - 2) < 0.01 &&
            Math.Abs(d33.Y - 2) < 0.01);
    }
}
