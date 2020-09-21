using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Windows;

public class ChangeColor : MonoBehaviour {
    private Camera cam;
    public int color;
    public SpriteRenderer background;
    
    // Start is called before the first frame update
    void Start() {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnMouseDown() {
        if (color == 0) {
            background.color = Color.black;
        }
        else {
            background.color = Color.white;
        }

        Information.Color = color;
    }
}
