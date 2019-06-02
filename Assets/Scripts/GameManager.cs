using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JBN/Deck")]
public class Deck : ScriptableObject {
    public List<Unit> availableUnits;
}

public class GameManager : MonoBehaviour {
    public GridSlot slotPrefab;
    private GridSlot[,] grid;
    public Grid layout;
    public byte width, height;

    private void Start() {
        grid = new GridSlot[width, height];
        for (var x = 0; x < width; x++) {
            for (var y = 0; y < height; y++) {
                var obj = grid[x, y] = Instantiate(slotPrefab, layout.transform);
                obj.transform.position = layout.GetCellCenterWorld(new Vector3Int(x, y, 0));
            }
        }
    }
}