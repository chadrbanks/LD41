using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetShape : MonoBehaviour
{
	public TetCube t1, t2, t3, t4;
	int mat;

	void Start ()
	{
		mat = Random.Range (1, 10);

		t1.SetMat (mat);
		t2.SetMat (mat);
		t3.SetMat (mat);
		t4.SetMat (mat);
	}

	public void Waste()
	{
		//
	}

	void Update ()
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);

		if (gameObject.transform.position.y < -100)
		{
			Destroy (gameObject);
		}
	}
}
