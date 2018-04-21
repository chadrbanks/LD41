using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEngine : MonoBehaviour
{
	public TetShape Bar, Box, Z, S, T, J, L, Single;
	public MenuButton b1, b2, b3, back;
	public TextMesh creds;
	public AudioSource mainsong;
	//float StepTime = 0;

	void Start ()
	{
		SpawnTet (10);
		SpawnTet (10);
		SpawnTet (10);
		SpawnTet (10);
		SpawnTet (20);
		SpawnTet (20);
		SpawnTet (20);
		SpawnSingle (0);
		SpawnSingle (0);
		SpawnSingle (10);
		SpawnSingle (20);
		SpawnSingle (30);
		SpawnSingle (30);
		SpawnSingle (30);
		SpawnSingle (30);
		SpawnSingle (40);

		ToggleCredits( true );
	}

	public void ToggleCredits( bool c )
	{
		if (c)
		{
			creds.GetComponent<MeshRenderer> ().enabled = false;
			b1.transform.position = new Vector3 ( 0, b1.transform.position.y, b1.transform.position.z );
			b2.transform.position = new Vector3 ( 0, b2.transform.position.y, b2.transform.position.z );
			b3.transform.position = new Vector3 ( 0, b3.transform.position.y, b3.transform.position.z );
			back.transform.position = new Vector3 ( -1000, back.transform.position.y, back.transform.position.z );
		}
		else
		{
			creds.GetComponent<MeshRenderer> ().enabled = true;
			b1.transform.position = new Vector3 ( -1000, b1.transform.position.y, b1.transform.position.z );
			b2.transform.position = new Vector3 ( -1000, b2.transform.position.y, b2.transform.position.z );
			b3.transform.position = new Vector3 ( -1000, b3.transform.position.y, b3.transform.position.z );
			back.transform.position = new Vector3 ( 0, back.transform.position.y, back.transform.position.z );
		}
	}

	void SpawnSingle( int y )
	{
		Vector3 nv = new Vector3 (Random.Range(-40, 40), y, 10);
		TetShape b = Instantiate(Single, nv, Quaternion.identity) as TetShape;
		b.Waste ();
	}

	void SpawnTet( int y )
	{
		Vector3 nv = new Vector3 (Random.Range(-40, 40), y, 10);
		TetShape b;

		switch (Random.Range (1, 10))
		{
		case 1:
			b = Instantiate(Bar, nv, Quaternion.identity) as TetShape;
			break;
		case 2:
			b = Instantiate(Box, nv, Quaternion.identity) as TetShape;
			break;
		case 3:
			b = Instantiate(Z, nv, Quaternion.identity) as TetShape;
			break;
		case 4:
			b = Instantiate(S, nv, Quaternion.identity) as TetShape;
			break;
		case 5:
			b = Instantiate(J, nv, Quaternion.identity) as TetShape;
			break;
		case 6:
			b = Instantiate(L, nv, Quaternion.identity) as TetShape;
			break;
		case 7:
			b = Instantiate(T, nv, Quaternion.identity) as TetShape;
			break;
		case 8:
			b = Instantiate(Single, nv, Quaternion.identity) as TetShape;
			break;
		case 9:
			b = Instantiate(Single, nv, Quaternion.identity) as TetShape;
			break;
		default:
			b = Instantiate(Single, nv, Quaternion.identity) as TetShape;
			break;
		}

		b.Waste ();
	}

	bool falling = true;
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.P))
		{
			if (falling)
				falling = false;
			else
				falling = true;
		}

		if (falling)
		{
			SpawnTet (30);
			SpawnSingle (30);
			SpawnSingle (30);
		}



		if (Input.GetKeyDown (KeyCode.M))
		{
			if ( mainsong.isPlaying )
			{
				mainsong.Stop ();
			}
			else
			{
				mainsong.Play ();
			}
		}
	}
}
