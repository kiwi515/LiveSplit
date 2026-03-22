using System;
using System.Diagnostics;
using System.Drawing;

namespace LiveSplit.Model;

/// <summary>
/// Random delta color helper functions
/// </summary>
internal static class RandomDeltaColorHelper
{
    /// <summary>
    /// Maximum split number supported before colors loop around
    /// </summary>
    private const int MAX_SPLITNO = 1024;

    /// <summary>
    /// Random delta color saturation
    /// </summary>
    private const float COLOR_SATURATION = 1.0f;

    /// <summary>
    /// Random delta color value (brightness)
    /// </summary>
    private const float COLOR_VALUE = 0.8f;

    /// <summary>
    /// Random delta color table
    /// </summary>
    private static readonly Color[] _randomColors = new Color[MAX_SPLITNO];

    /// <summary>
    /// Initializes the set of random delta colors
    /// </summary>
    public static void Initialize()
    {
        Random r = new();

        for (int i = 0; i < MAX_SPLITNO; i++)
        {
            float hue = (float)r.NextDouble();
            _randomColors[i] = ColorFromHsv(hue, COLOR_SATURATION, COLOR_VALUE);
        }
    }

    /// <summary>
    /// Gets the random delta color associated with the specified split
    /// </summary>
    /// <param name="splitNo">Split number</param>
    /// <returns>Split delta color</returns>
    public static Color GetColor(int splitNo)
    {
        // Wrap around if we don't have enough colors
        splitNo %= MAX_SPLITNO;

        return _randomColors[splitNo];
    }

    /// <summary>
    /// Creates a RGB color from HSV components
    /// </summary>
    /// <param name="h">Hue [0, 1]</param>
    /// <param name="s">Saturation [0, 1]</param>
    /// <param name="v">Value [0, 1]</param>
    /// <returns></returns>
    private static Color ColorFromHsv(float h, float s, float v)
    {
        Debug.Assert(h >= 0.0f && h <= 1.0f);
        Debug.Assert(s >= 0.0f && s <= 1.0f);
        Debug.Assert(v >= 0.0f && v <= 1.0f);

        float r = 0.0f;
        float g = 0.0f;
        float b = 0.0f;

        int i = (int)(h * 6.0f);
        float f = (h * 6.0f) - i;

        float p = v * (1.0f - s);
        float q = v * (1.0f - (f * s));
        float t = v * (1.0f - ((1.0f - f) * s));

        switch (i % 6)
        {
            case 0:
                r = v;
                g = t;
                b = p;
                break;

            case 1:
                r = q;
                g = v;
                b = p;
                break;

            case 2:
                r = p;
                g = v;
                b = t;
                break;

            case 3:
                r = p;
                g = q;
                b = v;
                break;

            case 4:
                r = t;
                g = p;
                b = v;
                break;

            case 5:
                r = v;
                g = p;
                b = q;
                break;
        }

        r *= 255;
        g *= 255;
        b *= 255;

        return Color.FromArgb(alpha: 255, (int)r, (int)g, (int)b);
    }
}
