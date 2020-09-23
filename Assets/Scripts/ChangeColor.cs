using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Windows;

public class ChangeColor : MonoBehaviour {
    public bool bright;
    private LightSwitchManager lsm;

    private void Start() {
        lsm = FindObjectOfType<LightSwitchManager>();
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        foreach (RaycastHit hit in Physics.RaycastAll(ray)) {
            if (hit.collider == gameObject.GetComponent<Collider>()) {
                Debug.Log(name + "mouse entered");
                if (lsm.bright != bright) {
                    //lsm.bright = bright;
                    lsm.switchLight = true;
                }
            }
        }
    }

    private void OnMouseDown() {
        Debug.Log("FUCK!");
        lsm.switchLight = true;
    }
}
