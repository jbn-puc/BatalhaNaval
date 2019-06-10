using System;
using System.Collections.Generic;
using UnityEngine;

public class Planner : MonoBehaviour
{
    public Unit currentlySelected;
    List<Unit> placed;
    void Start()
    {
        placed = new List<Unit>();
    }
    public bool Tick(GameManager gm)
    {
        var f = gm.CurrentField;
        var g = f.Grid;
        foreach (var e in g)
        {
            e.isAlly = e.unit != null;
        }
        if (currentlySelected != null)
        {
            var s = gm.selected;

            if (Input.GetMouseButtonDown(0) && currentlySelected.structure.CanPlaceIn(f, s.x, s.y))
            {
                placed.Add(currentlySelected);
                currentlySelected.PlaceIn(f, s.x, s.y);
                currentlySelected = null;
            }
        }
        foreach (var u in gm.deck.availableUnits)
        {

            if (!placed.Contains(u))
            {
                return false;
            }
        }
        return true;
    }

}
