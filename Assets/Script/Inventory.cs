using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int SparklePower = 10;
    public Image image;

    private void Update()
    {
        image.fillAmount = MapValues(SparklePower, 0, 50, 0, 1.0f);
    }


    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
