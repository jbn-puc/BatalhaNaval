using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JBN/Deck")]
public class Deck : ScriptableObject {
    public List<Unit> availableUnits;
}