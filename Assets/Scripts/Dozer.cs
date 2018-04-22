using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dozer : MonoBehaviour
{
    int back = 0;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(transform.position.z);

        if (transform.position.z < 4)
            back = 1;
        else if (transform.position.z > 8)
            back = 0;

        if( back == 0 )
            transform.Translate(Vector3.back * 1 * Time.deltaTime);
        else
            transform.Translate(Vector3.back * -1 * Time.deltaTime);
	}
}
