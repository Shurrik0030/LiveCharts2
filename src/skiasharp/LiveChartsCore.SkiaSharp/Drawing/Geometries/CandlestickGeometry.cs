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

/// <summary>
/// Defines a candlestick geometry.
/// </summary>
public class CandlestickGeometry : CoreCandlestickGeometry, ISkiaGeometry
{
    /// <inheritdoc cref="IDrawable{TDrawingContext}.Children" />
    public IDrawable<SkiaSharpDrawingContext>[] Children { get; set; } = [];

    /// <inheritdoc cref="IDrawable{TDrawingContext}.Draw(TDrawingContext)" />
    public void Draw(SkiaSharpDrawingContext ctx) =>
        OnDraw(ctx, ctx.Paint);

    /// <inheritdoc cref="ISkiaGeometry.OnDraw(SkiaSharpDrawingContext, SKPaint)" />
    public virtual void OnDraw(SkiaSharpDrawingContext context, SKPaint paint)
    {
        var w = Width;
        var cx = X + w * 0.5f;
        var h = Y;
        var o = Open;
        var c = Close;
        var l = Low;

        float yi, yj;

        if (o > c)
        {
            yi = c;
            yj = o;
        }
        else
        {
            yi = o;
            yj = c;
        }

        context.Canvas.DrawLine(cx, h, cx, yi, paint);
        context.Canvas.DrawRect(X, yi, w, Math.Abs(o - c), paint);
        context.Canvas.DrawLine(cx, yj, cx, l, paint);
    }

    /// <inheritdoc cref="CoreGeometry.Measure(Paint)" />
    public override LvcSize Measure(Paint paintTasks) =>
        new(Width, Math.Abs(Low - Y));
}
