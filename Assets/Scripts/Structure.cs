using System;

[Serializable]
public struct Structure
{
    public byte width, height;
    public bool[] composition;

    public bool CanPlaceIn(Field field, int baseX, int baseY)
    {
        if (baseX + width >= field.width)
        {
            return false;
        }
        if (baseY + height >= field.height)
        {
            return false;
        }
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (field.Grid[baseX + x, baseY + y].unit != null)
                {
                    return false;
                }
            }
        }
        return true;
    }
}