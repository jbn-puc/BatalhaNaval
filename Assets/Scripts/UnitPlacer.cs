using UnityEngine;
using UnityEngine.UI;

public class UnitPlacer : MonoBehaviour
{
    public Text label;
    public Image icon;
    public Toggle button;
    private Unit unit;
    public void Init(Unit placer)
    {
        label.text = placer.alias;
        unit = placer;
    }
    void Update()
    {
        var p = GameManager.Instance.CurrentPlanner;
        if (p == null) {
            return;
        }
        var b = button.isOn = p.currentlySelected == unit;
        label.color = b ? Color.white : Color.blue;
    }
    void Start()
    {
        button.onValueChanged.AddListener((p) =>
        {
            if (p)
            {
                GameManager.Instance.CurrentPlanner.currentlySelected = unit;
            }
        });
    }
}