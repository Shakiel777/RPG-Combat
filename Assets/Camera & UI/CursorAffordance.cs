// Copyright 2017 - David Rood
// A-Gen-C Entertainment (AGC)
// Shakiel@roadrunner.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D enemyCursor = null;
    [SerializeField] Texture2D unknownCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

    [SerializeField] const int walkableLayerNumber = 8;
    [SerializeField] const int enemyLayerNumber = 9;

    CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start ()
    {
        cameraRaycaster = GetComponent<CameraRaycaster>();
        cameraRaycaster.notifyLayerChangeObservers += OnLayerChanged;
	}
	
	// Only called on Layer change
	void OnLayerChanged(int newLayer)
    {
        print("Cursor over new layer");
        switch (newLayer)
        {
            case walkableLayerNumber:
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case enemyLayerNumber:
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
                return;
        }
        
       // print(cameraRaycaster.layerHit);
	}
}
