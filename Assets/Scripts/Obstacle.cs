using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    private int globalColor;
    public int color;
    // Start is called before the first frame update
    void Start() {
        globalColor = Information.Color;
        if (globalColor == color) {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
        }
        else {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (globalColor != Information.Color) {
            globalColor = Information.Color;
            if (globalColor == color) {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
            }
            else {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Collider2D>().enabled = true;
            }
            
        }
    }
}
