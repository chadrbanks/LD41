using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    bool moved = false;

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseDown()
    {
        if (moved)
        {
            moved = false;
            transform.Translate(Vector3.right * -20);
        }
        else
        {
            moved = true;
            transform.Translate(Vector3.right * 20);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
