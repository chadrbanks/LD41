using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmaBtn : MonoBehaviour
{
    //int t, v = 10;
    //private bool setsy = false;
    //private MainEngine mainEngine;
    //private GameEngine gameEngine;
    //public Material[] mats;

    void Awake()
    {
        //t = Random.Range(0, 4);
        //SetCoin(t);
        //v = 10;
    }

    void Start()
    {
        // t = Random.Range(0, 4);
        //SetCoin(t);
        //v = 10;
    }

    public void Waste()
    {
        //transform.localScale += new Vector3(3F, 0, 2F);
    }

    void OnMouseDown()
    {
        gameObject.transform.position = new Vector3(13, 2000, 5);
         Singleton.data.cc = 20;
            //Destroy(gameObject);
    }

    void Update()
    {
        //
    }
}
