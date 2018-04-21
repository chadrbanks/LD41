using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetCube : MonoBehaviour
{
	int mid = 0;
	int tid = 0;
	GameEngine engn;
	public bool border, pivot;
	[SerializeField] private Material[] mats;
	[SerializeField] private Renderer m_Renderer;

	public bool falling = false;

	void Start ()
	{
		//mid = 0;
	}

	public void SetEngine( GameEngine e )
	{
		engn = e;
	}

	public int GetMat(  )
	{
		return mid;
	}

	public int GetTid(  )
	{
		return tid;
	}

	public void SetMat( int m )
	{
		mid = m;
	}

	public void SetTet( int t )
	{
		tid = t;
		pivot = false;
		border = false;

		//if (tid >= 210)
		//	GetComponent<Renderer> ().enabled = false;
	}

	void OnMouseUp()
	{
		if( !engn.GameOver && !border && !engn.Paused )
		{
			if(!falling)
			{
				if(engn.BuyBreak())
				{
					mid = 0;
					falling = false;
				}
			}
			else
			{
				Vector3 v = new Vector3 (0, 0, 10);
				FloatText g = Instantiate(engn.ft, v, Quaternion.identity) as FloatText;
				g.SetText( "Not landed!" );
				g.SetColor( Color.red );
			}
		}
	}

	void Update ()
	{
		if (border)
			mid = 12;
		
		m_Renderer.material = mats[mid];
	}
}
