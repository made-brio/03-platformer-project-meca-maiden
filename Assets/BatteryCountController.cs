using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryCountController : MonoBehaviour
{
    public Sprite[] batterySprites; // assign your 5 sprites in inspector
    public Image batteryImage;  // assign the sprite renderer in inspector

    private void Start()
    {
        // Optional: initialize to the first sprite
        SetBatteryCount(0);
    }

    // Call this from your other script
    public void SetBatteryCount(int count)
    {
        // Clamp to ensure index is safe
        count = Mathf.Clamp(count, 0, batterySprites.Length - 1);
        batteryImage.sprite = batterySprites[count];
    }
}
