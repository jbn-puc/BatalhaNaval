using System;
using Lunari.Tsuki;
using UnityEngine;


public class GridSlot : MonoBehaviour {
    public Unit unit;
    public MeshRenderer renderer;
    public float hoverBrightnessIncrease = .25F;
    public Color normal, friendly, enemy, empty;
    public bool isHovered, isAlly, isExposed;
    private void Update() {
        Color c;
        if (isAlly) {
            c = friendly;
        }
        else {
            if (isExposed) {
                if (unit == null) {
                    c = empty;
                }
                else {
                    c = enemy;
                }
            }
            else {
                c = normal;
            }
        }

        if (isHovered) {
            float h, s, v;
            Color.RGBToHSV(c, out h, out s, out v);
            c = Color.HSVToRGB(h, s, Mathf.Clamp01(v + hoverBrightnessIncrease));
        }

        renderer.material.color = c;
    }
}