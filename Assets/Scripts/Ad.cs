using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ad : MonoBehaviour
{
	int fee;
	int AdType;
	public TextMesh Cost;
	GameEngine engn;

	[SerializeField] private Material[] mats;
	[SerializeField] private Renderer m_Renderer;
	
	void Start ()
	{
		//cost = Random.Range( 1, 4 );
	}
	
	public void SetData( int img, int c, GameEngine e )
	{
		if (img == -1)
			img = Random.Range(0, mats.Length);
		
		AdType = img;
		engn = e;
		fee = c;
	}

	void OnMouseUp()
	{
		if (engn.CanPay(fee))
		{
			Destroy(gameObject);
		}
	}
	
	void Update ()
	{
		Cost.text = "$" + fee;
		m_Renderer.material = mats[AdType];
	}
}
