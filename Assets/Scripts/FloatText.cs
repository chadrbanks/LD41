using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatText : MonoBehaviour
{
	public TextMesh ft;

	void Start ()
	{
		StartCoroutine(FadeTo(0.0f, 3.0f));
	}

	public void SetColor( Color c )
	{
		GetComponent<TextMesh> ().color = c;
		//GetComponent<Renderer> ().material.color = c;
	}

	public void SetText( string t )
	{
		ft.text = t;
	}

	// Fade Text Upward
	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = gameObject.GetComponent<MeshRenderer>().material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			gameObject.GetComponent<MeshRenderer>().material.color = newColor;
			yield return null;
		}
	}

	float AliveTime = 0;
	void Update ()
	{
		transform.Translate(Vector3.up * Time.deltaTime, Space.World);
		AliveTime += Time.deltaTime;

		if (AliveTime >= 4)
		{
			Destroy (gameObject);
		}
	}
}
