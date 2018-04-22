using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEngine : MonoBehaviour
{
	public Coin c;
	public MenuButton b1, b2, b3, back;
	//public TextMesh creds;
	//public AudioSource mainsong;
	//float StepTime = 0;

	void Start()
	{
		SpawnSingle(0);
		SpawnSingle(0);
		SpawnSingle(10);
		SpawnSingle(20);
		SpawnSingle(30);
		SpawnSingle(30);
		SpawnSingle(30);
		SpawnSingle(30);
		SpawnSingle(40);
	}

	void SpawnSingle(int y)
	{
		Vector3 nv = new Vector3(Random.Range(-40, 40), y, 5);
		Coin b = Instantiate(c, nv, Quaternion.identity) as Coin;
		b.Waste();
	}

	bool falling = true;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (falling)
				falling = false;
			else
				falling = true;
		}

		if (falling)
		{
			SpawnSingle(30);
			SpawnSingle(30);
			SpawnSingle(30);
			SpawnSingle(30);
		}
		/*
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (mainsong.isPlaying)
			{
				mainsong.Stop();
			}
			else
			{
				mainsong.Play();
			}
		}
		*/
	}
}
