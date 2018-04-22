using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	void Start()
	{
		
	}

	public void Waste()
	{
		//
	}

	void Update()
	{
		//transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

		if (gameObject.transform.position.y < -100)
		{
			Destroy(gameObject);
		}
	}
}
