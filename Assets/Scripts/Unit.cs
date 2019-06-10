using UnityEngine;

public class Unit : MonoBehaviour
{
    public Structure structure;
    public string alias;
    public void PlaceIn(Field field, int baseX, int baseY)
    {
        for (var x = 0; x < structure.width; x++)
        {
            for (var y = 0; y < structure.height; y++)
            {
                field.Grid[baseX + x, baseY + y].unit = this;
            }
        }
    }
}