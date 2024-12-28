namespace Crony;

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class CircularProgressBar : Control
{
    private readonly Timer _animationTimer;
    private float _actualValue;
    private int _targetValue;

    public CircularProgressBar()
    {
        DoubleBuffered = true;
        _animationTimer = new Timer();
        _animationTimer.Interval = 15;
        _animationTimer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        float delta = (_targetValue - _actualValue) * 0.1f;
        _actualValue += delta;

        if (Math.Abs(_targetValue - _actualValue) < 0.5f)
        {
            _actualValue = _targetValue;
            _animationTimer.Stop();
        }

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        e.Graphics.Clear(BackColor);

        e.Graphics.FillEllipse(new SolidBrush(BarBackColor),
            Margin.Left,
            Margin.Top,
            Width - Margin.Left - Margin.Right,
            Height - Margin.Top - Margin.Bottom);

        e.Graphics.FillEllipse(new SolidBrush(InternalColor),
            Margin.Left + BarWidth,
            Margin.Top + BarWidth,
            Width - Margin.Left - Margin.Right - BarWidth * 2,
            Height - Margin.Top - Margin.Bottom - BarWidth * 2);

        using (Pen pen = new Pen(BarColor, BarWidth))
        {
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;

            e.Graphics.DrawArc(pen,
                Margin.Left + BarWidth / 2,
                Margin.Top + BarWidth / 2,
                Width - Margin.Left - Margin.Right - BarWidth,
                Height - Margin.Top - Margin.Bottom - BarWidth,
                -90,
                (int)Math.Round(360.0 / 100 * _actualValue));
        }

        StringFormat sf = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        e.Graphics.DrawString(Math.Round(_actualValue) + "%", Font,
                                new SolidBrush(ForeColor),
                                new RectangleF(0, 0, Width, Height), sf);
    }

    public int AnimationInterval { get; set; } = 2;

    public int Value
    {
        get { return _targetValue; }
        set
        {
            _targetValue = value;
            _animationTimer.Start();
        }
    }

    public Color BarColor { get; set; } = Color.LightGreen;
    public Color InternalColor { get; set; } = Color.White;
    private Color BarBackColor { get; set; } = Color.Silver;
    public int BarWidth { get; set; } = 6;

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Height = Width;
    }
}
