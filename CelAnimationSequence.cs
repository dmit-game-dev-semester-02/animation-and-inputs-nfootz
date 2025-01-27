using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;

namespace assignment01;
    
/// <summary>
/// Represents a cel animated texture.
/// </summary>
public class CelAnimationSequence
{
    // The texture containing the animation sequence...
    protected Texture2D texture;

    // The length of time a cel is displayed...
    protected float celTime;

    // Sequence metrics
    protected int celWidth;
    protected int celHeight;
    protected int y;

    // Calculated count of cels in the sequence
    protected int celCount;

    /// <summary>
    /// Constructs a new CelAnimationSequence.
    /// </summary>        
    public CelAnimationSequence(Texture2D texture, int celWidth, int celHeight, int celCount, float celTime, int y = 0)
    {
        this.texture = texture;
        this.celWidth = celWidth;
        this.celTime = celTime;
        this.y = y;

        if (celHeight <= 0)
            this.celHeight = Texture.Height;
        else
            this.celHeight = celHeight;
        
        if (celCount <= 0)
            this.celCount = Texture.Width / celWidth;
        else
            this.celCount = celCount;
    }

    /// <summary>
    /// All frames in the animation arranged horizontally.
    /// </summary>
    public Texture2D Texture
    {
        get { return texture; }
    }

    /// <summary>
    /// Duration of time to show each cel.
    /// </summary>
    public float CelTime
    {
        get { return celTime; }
    }

    /// <summary>
    /// Gets the number of cels in the animation.
    /// </summary>
    public int CelCount
    {
        get { return celCount; }
        set { celCount = value; }
    }

    /// <summary>
    /// Gets the width of a frame in the animation.
    /// </summary>
    public int CelWidth
    {
        get { return celWidth; }
        set { celWidth = value; }
    }

    /// <summary>
    /// Gets the height of a frame in the animation.
    /// </summary>
    public int CelHeight
    {
        get { return celHeight; }
        set { celHeight = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }
}
