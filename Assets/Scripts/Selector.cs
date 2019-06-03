using System;
using UnityEngine;

public class Selector : MonoBehaviour {
    private void Update() {
        var gm = GameManager.Instance;
        if (gm == null) {
            return;
        }

        var sel = gm.selected;
        if (sel.x < 0 || sel.y < 0 || sel.x >= gm.width || sel.y >= gm.height) {
            return;
        }

        for (var x = 0; x < gm.width; x++) {
            for (var y = 0; y < gm.height; y++) {
                gm.CurrentField.Grid[x, y].isHovered = x == sel.x && y == sel.y && gm.allowInput;
            }
        }
    }
}