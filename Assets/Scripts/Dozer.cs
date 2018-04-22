using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dozer : MonoBehaviour
{
    int back = 0;
    public GameEngine engn;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(transform.position.z);

        if (!engn.Paused)
        {
            if (transform.position.z < 16)
                back = 1;
            else if (transform.position.z > 20)
                back = 0;

            if (back == 0)
                transform.Translate(Vector3.back * 2 * Time.deltaTime);
            else
                transform.Translate(Vector3.back * -2 * Time.deltaTime);
        }
	}
}
