using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchManager : MonoBehaviour {
    public GameObject darkObjects;
    public GameObject brightObjects;
    public bool switchLight = true;
    public bool bright = true;
    private SpriteRenderer[] darkLights;
    private SpriteRenderer[] brightLights;
    private SpriteRenderer[] allLights;
    public float brightnessValue;
    public float darknessValue;
    public float speed;
    // Start is called before the first frame update
    void Start() {
        darkLights = darkObjects.GetComponentsInChildren<SpriteRenderer>();
        brightLights = brightObjects.GetComponentsInChildren<SpriteRenderer>();
        
        allLights = new SpriteRenderer[darkLights.Length + brightLights.Length];
        for (int i = 0; i < darkLights.Length; i++) {
            allLights[i] = darkLights[i];
        }

        for (int i = 0; i < brightLights.Length; i++) {
            allLights[i+darkLights.Length] = brightLights[i];
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (switchLight) {
            Color temp;
            int length = darkLights.Length >= brightLights.Length ? darkLights.Length : brightLights.Length;
            
            if (bright) {
                for (int i = 0; i < length; i++) {
                    try {
                        temp = darkLights[i].color;
                        darkLights[i].color = new Color(temp.r, temp.g, temp.b, temp.a - speed);
                    } catch (IndexOutOfRangeException) { }

                    try {
                        temp = brightLights[i].color;
                        brightLights[i].color = new Color(temp.r, temp.g, temp.b, temp.a + speed);
                    } catch (IndexOutOfRangeException) { }
                }
            }
            else {
                for (int i = 0; i < length; i++) {
                    try {
                        temp = darkLights[i].color;
                        darkLights[i].color = new Color(temp.r, temp.g, temp.b, temp.a + speed);
                    } catch (IndexOutOfRangeException) { }

                    try {
                        temp = brightLights[i].color;
                        brightLights[i].color = new Color(temp.r, temp.g, temp.b, temp.a - speed);
                    } catch (IndexOutOfRangeException) { }
                }
            }
        }

        if ((darkLights[0].color.a <= darknessValue && bright) || (brightLights[0].color.a <= brightnessValue && !bright)) {
            switchLight = false;
            bright = !bright;
        }
    }
}
