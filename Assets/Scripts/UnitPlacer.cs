using UnityEngine;
using UnityEngine.UI;

public class UnitPlacer : MonoBehaviour {
    public Text label;
    public Image icon;

    public void Init(Unit placer) {
        label.text = placer.alias;
    }
}