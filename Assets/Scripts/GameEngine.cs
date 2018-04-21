using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
	public bool GameOver = false;
	public TetCube tc;
	float StepTime = 0, MoveSpeed = 1.5f;
	float AdTime = 0, NextAdMin = 7, NextAdMax = 15, NextAd;
	bool NextPiece = true;
	Dictionary <int, TetCube> cubes = new Dictionary<int, TetCube>();
	
	public Ad ad1;

	public TetButton[] btns;

	int CurrShape, NextShape, cash, reward, pos;

	public FloatText ft;
	public TextMesh got, next, CashText, CostText, CostText2;

	public AudioSource failure, mainsong;

	void Start ()
	{
		cash = 1000;
		reward = 9;
		NextShape = Random.Range (1, 8);
		NextAd = Random.Range( NextAdMin, NextAdMax );

		foreach (TetButton btn in btns)
		{
			btn.SetEngine (this);
		}

		int c = 0;
		for (int x = -10; x < 12; x++)
		{
			for (int y = -15; y < -5; y++)
			{
				Vector3 nv = new Vector3 (y, x, 11);
				TetCube t = Instantiate(tc, nv, Quaternion.identity) as TetCube;
				t.SetEngine (this);
				t.falling = false;
				t.SetTet (c);

				cubes.Add( c, t );
				c++;
			}
		}
	}

	int barcost = 10, boxcost = 10, scost = 10, zcost = 10, tcost = 10, jcost = 10, lcost = 10;
	public void Hover( TetButtonType bt )
	{
		switch (bt)
		{
		case TetButtonType.BuyBar:
			CostText.text = "Click to buy a Bar : $" + barcost;
			break;
		case TetButtonType.BuyBox:
			CostText.text = "Click to buy a Box : $" + boxcost;
			break;
		case TetButtonType.BuyT:
			CostText.text = "Click to buy a T : $" + tcost;
			break;
		case TetButtonType.BuyJ:
			CostText.text = "Click to buy a J : $" + jcost;
			break;
		case TetButtonType.BuyL:
			CostText.text = "Click to buy a L : $" + lcost;
			break;
		case TetButtonType.BuyZ:
			CostText.text = "Click to buy a Z : $" + zcost;
			break;
		case TetButtonType.BuyS:
			CostText.text = "Click to buy a S : $" + scost;
			break;
		}

		ShowMainText = false;
	}

	public void Unhover()
	{
		ShowMainText = true;
	}

	int cost = 5;
	public bool BuyBreak( )
	{
		if( cash >= cost )
		{
			cash -= cost;
			cost++;
			return true;
		}
		else
		{
			Vector3 v = new Vector3 (0, 0, 10);
			FloatText g = Instantiate(ft, v, Quaternion.identity) as FloatText;
			g.SetText( "Not Enough Cash!" );
			g.SetColor( Color.red );
			return false;
		}
	}
	public bool BuyMove( int c )
	{
		if( cash >= c )
		{
			cash -= c;
			return true;
		}
		else
		{
			Vector3 v = new Vector3 (0, 0, 10);
			FloatText g = Instantiate(ft, v, Quaternion.identity) as FloatText;
			g.SetText( "Not enough cash to move!" );
			g.SetColor( Color.red );
			return false;
		}
	}

	public void Purchase( TetButtonType bt )
	{
		bool Failed = true;
		switch (bt)
		{
		case TetButtonType.BuyBar:
			if (cash >= barcost)
			{
				cash -= barcost;
				barcost *= 2;
				NextShape = 1;
				Failed = false;
				UpdateNextDisplay ();
			}
			break;
		case TetButtonType.BuyBox:
			if (cash >= boxcost)
			{
				cash -= boxcost;
				boxcost *= 2;
				NextShape = 4;
				Failed = false;
				UpdateNextDisplay ();
			}
			break;
		case TetButtonType.BuyT:
			if (cash >= tcost)
			{
				cash -= tcost;
				tcost *= 2;
				NextShape = 7;
				Failed = false;
				UpdateNextDisplay ();
			}
			break;
		case TetButtonType.BuyJ:
			if (cash >= jcost)
			{
				cash -= jcost;
				jcost *= 2;
				NextShape = 2;
				Failed = false;
				UpdateNextDisplay ();
			}
			break;
		case TetButtonType.BuyL:
			if (cash >= lcost)
			{
				cash -= lcost;
				lcost *= 2;
				NextShape = 3;
				Failed = false;
				UpdateNextDisplay ();
			}
			break;
		case TetButtonType.BuyZ:
			if (cash >= zcost)
			{
				cash -= zcost;
				zcost *= 2;
				NextShape = 6;
				Failed = false;
				UpdateNextDisplay ();
			}
			break;
		case TetButtonType.BuyS:
			if (cash >= scost)
			{
				cash -= scost;
				scost *= 2;
				NextShape = 5;
				Failed = false;
				UpdateNextDisplay ();
			}
			break;
		}

		if (Failed)
		{
			Vector3 v = new Vector3 (0, 0, 10);
			FloatText g = Instantiate (ft, v, Quaternion.identity) as FloatText;
			g.SetText ("Not enough cash!");
			g.SetColor (Color.red);
		}
	}

	void SpawnCube( )
	{
		/*
		for (int x = 0; x < 220; x++)
		{
			cubes [x].SetMat ( Random.Range( 1, 7 ) );
		}
		*/
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

	void UpdateNextDisplay( )
	{
		switch (NextShape)
		{
		case 1:
			next.text = "Next: Bar";
			break;
		case 2:
			next.text = "Next: J";
			break;
		case 3:
			next.text = "Next: L";
			break;
		case 4:
			next.text = "Next: Box";
			break;
		case 5:
			next.text = "Next: S";
			break;
		case 6:
			next.text = "Next: Z";
			break;
		case 7:
			next.text = "Next: T";
			break;
		}
	}

	int FindPivot()
	{
		for (int x = 0; x < 220; x++)
		{
			if (cubes [x].pivot)
			{
				return x;
			}
		}

		return -1;
	}

	void SwapTets( int o, int n )
	{
		int m = cubes[ o ].GetMat();
		cubes [n].SetMat (m);
		cubes [o].SetMat (0);
		cubes [n].falling = true;
		cubes [o].falling = false;

		if (cubes [o].pivot)
		{
			cubes [o].pivot = false;
			cubes [n].pivot = true;
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

	void StopFalling( int i )
	{
		/*
		if( i-11 >= 0 ) {cubes [i-11].falling = false;}
		if( i-10 >= 0 ) {cubes [i-10].falling = false;}
		if( i-9 >= 0 ) {cubes [i-9].falling = false;}
		if( i-1 >= 0 ) {cubes [i-1].falling = false;}
		cubes [i].falling = false;
		if( i+1 < 220 ) {cubes [i+1].falling = false;}
		if( i+9 < 220 ) {cubes [i+9].falling = false;}
		if( i+10 < 220 ) {cubes [i+10].falling = false;}
		if( i+11 < 220 ) {cubes [i+11].falling = false;}
		*/
		for( int x = 0; x < 220; x++ )
		{
			cubes [x].pivot = false;
			cubes [x].falling = false;
		}

		CheckForLines ();
		CheckForLines ();
		CheckForLines ();

		for (int x = 200; x < 220; x++)
		{
			if (cubes [x].GetMat () != 0)
			{
				GameOver = true;
				got.text = "Game Over!";

				mainsong.Stop ();
				failure.Play ();
			}
		}

		NextPiece = true;
	}

	void CheckForLines( )
	{

		//int c = 0;
		int fall = 0;
		for( int x = 0; x < 220; x += 10 )
		{
			bool die = true;
			for (int y = 0; y < 10; y++)
			{
				if (cubes [x+y].GetMat () == 0)
				{
					die = false;
				}
			}

			if (die)
			{
				fall++;
				reward++;
				cash += reward;
				for (int y = 0; y < 10; y++)
				{
					cubes [x + y].SetMat (0);
				}
				for( int z = (10+x); z < 220; z++ )
				{
					cubes [z-10].SetMat (cubes [z].GetMat ());
					cubes [z].SetMat (0);
				}
				
				MoveSpeed -= .1f;
				if( MoveSpeed <= .1f )
					MoveSpeed = .1f;

				Vector3 v = new Vector3 (x, 0, 10);
				FloatText g = Instantiate(ft, v, Quaternion.identity) as FloatText;
				g.SetText( "+ $" + reward );
				g.SetColor( Color.green );
			}
		}
	}

	void UpdateCube( )
	{
		bool WillStop = false;
		for (int x = 0; x < 220; x++)
		{
			if( x > 9 )
			{
				int l = x - 10;
				int m = cubes[ x ].GetMat();
				int b = cubes[ l ].GetMat();
				if( b == 0 && m != 0 )
				{
					if( cubes [x].falling )
					{
						cubes [l].SetMat (m);
						cubes [x].SetMat (0);
						cubes [l].falling = true;
						cubes [x].falling = false;

						if (cubes [x].pivot)
						{
							cubes [x].pivot = false;
							cubes [l].pivot = true;
						}

						int l2 = l - 10;
						if( l2 >= 0 )
						{
							if (!cubes [l2].falling && cubes [l2].GetMat () != 0)
								WillStop = true;
						}
						else
						{
							WillStop = true;
						}
					}
				}
				else if( m != 0 )
				{
					if( cubes [x].falling )
						WillStop = true;//StopFalling (x);
				}
			}
			else if( cubes [x].falling && cubes [x].GetMat() != 0 )
			{
				WillStop = true;
			}
		}

		if( WillStop )
			StopFalling (1);
	}

	public bool CanPay(int f)
	{
		if (cash >= f)
		{
			cash -= f;
			return true;
		}
		else
		{
			Vector3 v = new Vector3(0, 0, 10);
			FloatText g = Instantiate(ft, v, Quaternion.identity) as FloatText;
			g.SetText("Not enough funds!");
			g.SetColor(Color.red);

			return false;
		}

	}

	int adnum = 0;
	void SpawnAd()
	{
		Vector3 nv;// = new Vector3(Random.Range(-15, 21), Random.Range(-7, 7), 4);

		int adcost = Random.Range( 0, 3 ) + adnum;

		if (adnum == 0)
		{
			nv = new Vector3(0, 0, 4);
			Ad a = Instantiate(ad1, nv, Quaternion.identity) as Ad;
			a.transform.Rotate(new Vector3(90, 180, 0));
			a.SetData(0, 1, this);
			adnum++;
		}
		else
		{
			nv = new Vector3(Random.Range(-15, 21), Random.Range(-7, 7), Random.Range( 3.8f, 4.3f));
			Ad a = Instantiate(ad1, nv, Quaternion.identity) as Ad;
			a.transform.Rotate(new Vector3(90, 180, 0));
			a.SetData(-1, adcost, this);

			if (Random.Range(0, 3) == 0)
				adnum++;
		}


		NextAd = Random.Range(NextAdMin, NextAdMax);

		if (Random.Range(0, 2) == 0)
		{
			if (Random.Range(0, 2) == 0)
			{
				NextAdMin--;

				if (NextAdMin <= 1)
					NextAdMin = 1;
			}
			else
			{
				NextAdMax--;

				if (NextAdMax <= 4)
					NextAdMax = 4;
			}
		}
	}

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
				got.text = "";
			} else {
				Paused = true;
				got.text = "PAUSED!";
			}
		}

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

		if( !GameOver && !Paused )
		{
			if (CanMove > 0)
			{
				if( Input.GetKeyDown( KeyCode.LeftArrow ) )
				{
					//if (BuyMove (1)) {
						Move ("left");
					//}
				}
				else if( Input.GetKeyDown( KeyCode.RightArrow ) )
				{
					//if (BuyMove (1)) {
						Move ("right");
					//}
				}
				else if( Input.GetKey( KeyCode.DownArrow ) )
				{
					//if (BuyMove (1)) {
					Move ("down");
					if (!NextPiece){
						if (fasting > 0) {
							cash++;
							fasting = 0;
						} else {
							fasting++;
						}
					}
				}
				else if( Input.GetKeyDown( KeyCode.UpArrow ) )
				{
					if (FindPivot () < 200)
					{
						if (BuyMove (5))
						{
							Move ("up");
						}
					}
				}
			}

			if (StepTime >= MoveSpeed)
			{
				cash++;
				StepTime = 0;
				UpdateCube();
				if (NextPiece)
				{
					SpawnCube ();
					NextPiece = false;
				}
			}
			else// if(playing)
			{
				StepTime += Time.deltaTime;
			}
			
			if( AdTime >= NextAd )
			{
				AdTime = 0;
				SpawnAd();
			}
			else
			{
				AdTime += Time.deltaTime;
			}

			CashText.text = "$: " + cash;
			CostText2.text = "Next line will earn you : $" + (1+reward);

			if(ShowMainText)
				CostText.text = "Click any landed block to destory it : $" + cost;
		}
		else if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			SceneManager.LoadScene ("MenuScene", LoadSceneMode.Single);
		}
	}
}