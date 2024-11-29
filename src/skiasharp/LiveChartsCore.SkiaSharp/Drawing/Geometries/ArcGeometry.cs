﻿// The MIT License(MIT)
//
// Copyright(c) 2021 Alberto Rodriguez Orozco & LiveCharts Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using LiveChartsCore.Drawing;
using LiveChartsCore.Painting;
using SkiaSharp;

namespace LiveChartsCore.SkiaSharpView.Drawing.Geometries;

/// <inheritdoc cref="CoreArcGeometry" />
public class ArcGeometry : CoreArcGeometry, ISkiaGeometry
{
    /// <inheritdoc cref="IDrawable{TDrawingContext}.Children" />
    public IDrawable<SkiaSharpDrawingContext>[] Children { get; set; } = [];

    /// <inheritdoc cref="IDrawable{TDrawingContext}.Draw(TDrawingContext)" />
    public void Draw(SkiaSharpDrawingContext ctx) =>
        OnDraw(ctx, ctx.Paint);

    /// <inheritdoc cref="ISkiaGeometry.OnDraw(SkiaSharpDrawingContext, SKPaint)" />
    public virtual void OnDraw(SkiaSharpDrawingContext context, SKPaint paint)
    {
        using var path = new SKPath();

        var cx = CenterX;
        var cy = CenterY;
        var r = Width * 0.5f;
        var startAngle = StartAngle;
        var sweepAngle = SweepAngle;
        const float toRadians = (float)(Math.PI / 180);

        path.MoveTo(
           (float)(cx + Math.Cos(startAngle * toRadians) * r),
           (float)(cy + Math.Sin(startAngle * toRadians) * r));
        path.ArcTo(
            new SKRect { Left = X, Top = Y, Size = new SKSize { Width = Width, Height = Height } },
            startAngle,
            sweepAngle,
            false);

        context.Canvas.DrawPath(path, context.Paint);
    }

    /// <inheritdoc cref="CoreGeometry.Measure(Paint)"/>
    public override LvcSize Measure(Paint paintTasks) =>
        new();
}
