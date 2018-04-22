using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
	public bool GameOver = false;
	public Coin c;
	float StepTime = 0, MoveSpeed = 1.5f;
	Dictionary <int, Coin> coins = new Dictionary<int, Coin>();

	public FloatText ft;
	//public TextMesh got, next, CashText, CostText, CostText2;

	//public AudioSource failure, mainsong;

	void Start ()
	{
		//cash = 1000;
		//reward = 9;
		//NextShape = Random.Range (1, 8);
		//NextAd = Random.Range( NextAdMin, NextAdMax );
		/*
		foreach (TetButton btn in btns)
		{
			btn.SetEngine (this);
		}
		*/
	}
	/*
	void SpawnCube( )
	{
		if (cubes [219].GetMat () == 0 && cubes [218].GetMat () == 0 && cubes [217].GetMat () == 0 && cubes [216].GetMat () == 0)
		{
			CurrShape = NextShape;
			NextShape = Random.Range (1, 8);
			int m = Random.Range (1, 12);
			pos = 1;

			switch (CurrShape)
			{
			case 1: // Bar
				cubes [216].SetMat (m);
				cubes [215].SetMat (m);
				cubes [214].SetMat (m);
				cubes [213].SetMat (m);
				cubes [216].falling = true;
				cubes [215].falling = true;
				cubes [214].falling = true;
				cubes [213].falling = true;
				cubes [214].pivot = true;
				break;
			case 2: // J
				cubes [215].SetMat (m);
				cubes [205].SetMat (m);
				cubes [195].SetMat (m);
				cubes [194].SetMat (m);
				cubes [215].falling = true;
				cubes [205].falling = true;
				cubes [195].falling = true;
				cubes [194].falling = true;
				cubes [195].pivot = true;
				break;
			case 3: // L
				cubes [214].SetMat (m);
				cubes [204].SetMat (m);
				cubes [194].SetMat (m);
				cubes [195].SetMat (m);
				cubes [214].falling = true;
				cubes [204].falling = true;
				cubes [194].falling = true;
				cubes [195].falling = true;
				cubes [194].pivot = true;
				break;
			case 4: // Box
				cubes [215].SetMat (m);
				cubes [205].SetMat (m);
				cubes [214].SetMat (m);
				cubes [204].SetMat (m);
				cubes [215].falling = true;
				cubes [205].falling = true;
				cubes [214].falling = true;
				cubes [204].falling = true;
				cubes [214].pivot = true;
				break;
			case 5: // S
				cubes [216].SetMat (m);
				cubes [205].SetMat (m);
				cubes [215].SetMat (m);
				cubes [204].SetMat (m);
				cubes [216].falling = true;
				cubes [205].falling = true;
				cubes [215].falling = true;
				cubes [204].falling = true;
				cubes [215].pivot = true;
				break;
			case 6: // Z
				cubes [215].SetMat (m);
				cubes [206].SetMat (m);
				cubes [214].SetMat (m);
				cubes [205].SetMat (m);
				cubes [215].falling = true;
				cubes [206].falling = true;
				cubes [214].falling = true;
				cubes [205].falling = true;
				cubes [215].pivot = true;
				break;
			case 7: // T
				cubes [216].SetMat (m);
				cubes [215].SetMat (m);
				cubes [214].SetMat (m);
				cubes [205].SetMat (m);
				cubes [216].falling = true;
				cubes [215].falling = true;
				cubes [214].falling = true;
				cubes [205].falling = true;
				cubes [215].pivot = true;
				break;
			}

			UpdateNextDisplay ();
		}
		else
		{
			GameOver = true;
			got.text = "Game Over!";
		}
	}
	
	void Move( string dir )
	{
		bool WillMove = true;
		switch (dir)
		{
		case "left":
			for (int x = 0; x < 220; x++)
			{
				int d = x - 1;
				if (cubes [x].falling && (d % 10) == 9 )
				{
					WillMove = false;
				}
				if (cubes [x].falling && cubes[ d ].falling == false && cubes[ d ].GetMat() != 0 )
				{
					WillMove = false;
				}
			}

			if( WillMove )
			{
				if (BuyMove (1))
				{
					for( int x = 0; x < 220; x++ )
					{
						int d = x - 1;
						if (cubes [x].falling )
						{
							SwapTets ( x, d );
						}
					}
				}
			}
			break;
		case "right":
			for (int x = 0; x < 220; x++)
			{
				int d = x + 1;
				if( d < 220 )
				{
					if (cubes [x].falling && (d % 10) == 0 )
					{
						WillMove = false;
					}
					if (cubes [x].falling && cubes[ d ].falling == false && cubes[ d ].GetMat() != 0 )
					{
						WillMove = false;
					}
					if (cubes [x].falling && cubes [x].GetTid() >= 210 )
					{
						WillMove = false;
					}
				}
			}

			if( WillMove )
			{
				if (BuyMove (1))
				{
					for( int x = 219; x > 0; x-- )
					{
						int d = x + 1;
						if (d > 219)
							d -= 10;
						
						if (cubes [x].falling )
						{
							SwapTets ( x, d );
						}
					}
				}
			}
			break;
		case "down":
			UpdateCube ();
			break;
		case "up":
			switch (CurrShape)
			{
			case 1:
				// Bar
				if( pos == 1 )
				{
					pos = 2;
					int x = FindPivot ();
					SwapTets ( x+2, x+20 );
					SwapTets ( x+1, x+10 );
					SwapTets ( x-1, x-10 );
				}
				else
				{
					pos = 1;
					int x = FindPivot ();
					SwapTets ( x+20, x+2 );
					SwapTets ( x+10, x+1 );
					SwapTets ( x-10, x-1 );
				}
				break;
			case 2:
				// J
				if (pos == 1)
				{
					pos = 2;
					int x = FindPivot ();
					SwapTets (x + 10, x + 1);
					SwapTets (x - 1, x + 10);
					SwapTets (x + 20, x + 2);
				}
				else if (pos == 2)
				{
					pos = 3;
					int x = FindPivot ();
					SwapTets ( x+1, x-10 );
					SwapTets ( x+10, x+1 );
					SwapTets ( x+2, x-20 );
				}
				else if( pos == 3 )
				{
					pos = 4;
					int x = FindPivot ();
					SwapTets ( x-10, x-1 );
					SwapTets ( x+1, x-10 );
					SwapTets ( x-20, x-2 );
				}
				else
				{
					pos = 1;
					int x = FindPivot ();
					SwapTets ( x-1, x+10 );
					SwapTets ( x-10, x-1 );
					SwapTets ( x-2, x+20 );
				}
				break;
			case 3:
				// L
				if (pos == 1)
				{
					pos = 2;
					int x = FindPivot ();
					SwapTets (x + 1, x - 10);
					SwapTets (x + 10, x + 1);
					SwapTets (x + 20, x + 2);
				}
				else if (pos == 2)
				{
					pos = 3;
					int x = FindPivot ();
					SwapTets ( x-10, x-1 );
					SwapTets ( x+1, x-10 );
					SwapTets ( x+2, x-20 );
				}
				else if( pos == 3 )
				{
					pos = 4;
					int x = FindPivot ();
					SwapTets ( x-1, x+10 );
					SwapTets ( x-10, x-1 );
					SwapTets ( x-20, x-2 );
				}
				else
				{
					pos = 1;
					int x = FindPivot ();
					SwapTets ( x+10, x+1 );
					SwapTets ( x-1, x+10 );
					SwapTets ( x-2, x+20 );
				}
				break;
			case 4:
				// Box
				break;
			case 5:
				// S
				if( pos == 1 )
				{
					pos = 2;
					int x = FindPivot ();
					SwapTets ( x-11, x+9 );
					SwapTets ( x-10, x-1 );
					SwapTets ( x+1, x-10 );
				}
				else
				{
					pos = 1;
					int x = FindPivot ();
					SwapTets ( x-10, x+1 );
					SwapTets ( x-1, x-10 );
					SwapTets ( x+9, x-11 );
				}
				break;
			case 6:
				// Z
				if( pos == 1 )
				{
					pos = 2;
					int x = FindPivot ();
					SwapTets ( x-1, x+10 );
					SwapTets ( x-10, x-1 );
					SwapTets ( x-9, x-11 );
				}
				else
				{
					pos = 1;
					int x = FindPivot ();
					SwapTets ( x-1, x-10 );
					SwapTets ( x+10, x-1 );
					SwapTets ( x-11, x-9 );
				}
				break;
			case 7:
				// T
				if (pos == 1)
				{
					pos = 2;
					int x = FindPivot ();
					SwapTets (x + 1, x + 10);
				}
				else if (pos == 2)
				{
					pos = 3;
					int x = FindPivot ();
					SwapTets ( x-10, x+1 );
				}
				else if( pos == 3 )
				{
					pos = 4;
					int x = FindPivot ();
					SwapTets ( x-1, x-10 );
				}
				else
				{
					pos = 1;
					int x = FindPivot ();
					SwapTets ( x+10, x-1 );
				}
				break;
			}
			break;
		}
	}
	*/

	/*
	Vector3 v = new Vector3 (x, 0, 10);
	FloatText g = Instantiate(ft, v, Quaternion.identity) as FloatText;
	g.SetText( "+ $" + reward );
	g.SetColor( Color.green );
	*/

	int CanMove = 10;
	bool ShowMainText = true;
	public bool Paused = false;
	float fasting = 0;
	void Update ()
	{
		if( Input.GetKeyDown( KeyCode.P ) && !GameOver )
		{
			if (Paused) {
				Paused = false;
				//got.text = "";
			} else {
				Paused = true;
				//got.text = "PAUSED!";
			}
		}
		/*
		if (Input.GetKeyDown (KeyCode.M))
		{
			if ( mainsong.isPlaying && !GameOver )
			{
				mainsong.Stop ();
			}
			else
			{
				mainsong.Play ();
			}
		}
		*/

		if (StepTime >= MoveSpeed)
		{
			StepTime = 0;
		}
		else// if(playing)
		{
			StepTime += Time.deltaTime;
		}
	
		if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			SceneManager.LoadScene ("MainScene", LoadSceneMode.Single);
		}
	}
}