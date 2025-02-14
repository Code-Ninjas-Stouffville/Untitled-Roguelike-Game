using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yes : MonoBehaviour
{
    
    public Texture2D crosshairTex;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = new Vector2(16, 16);
        
    // Start is called before the first frame update
    void Start()
    {
        hotSpot = new Vector2(crosshairTex.width / 2, crosshairTex.height / 2);
        ChangeToCrosshair();
    }

    // Update is called once per frame
    void ChangeToCrosshair()
    {
        Cursor.SetCursor(crosshairTex, hotSpot, cursorMode);
    }
}
