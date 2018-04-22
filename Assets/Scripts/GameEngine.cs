using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
	public bool GameOver = false;
	public Coin c;
    //Dictionary <int, Coin> coins = new Dictionary<int, Coin>();
    //public int cash;
    int Prize = 20;
	public FloatText ft;
    public TextMesh cointxt;//got, next, CashText, CostText, CostText2;

	//public AudioSource failure, mainsong;

	void Start ()
	{
        //cash = 10;

        int r = Random.Range(120, 180);
        for (int x = 0; x < r; x++ )
        {
            SpawnSetup( Random.Range(-4, 5), 0, Random.Range(-4, 3));
        }

        Prize = Random.Range( 5, 90 );
    }

    public void addCash( int val )
    {
        Vector3 v = new Vector3(-12, 0, 0);
        FloatText g = Instantiate(ft, v, Quaternion.identity) as FloatText;
        g.SetText("+" + val + " Coins");
        g.SetColor(Color.yellow);
        Singleton.data.cc += val;
    }

    void SpawnSetup(int x, int y, int z)
    {
        Vector3 nv = new Vector3(x,y,z);
        Coin b = Instantiate(c, nv, Quaternion.identity) as Coin;
        b.Link(this);
    }

    void SpawnPrize()
    {
        Prize = Random.Range(180, 1200);
        Vector3 nv = new Vector3(Random.Range(-5, 5), 6, 2);
        Coin b = Instantiate(c, nv, Quaternion.identity) as Coin;
        b.Link(this);
        b.SetPrize();
    }

    void SpawnSingle(int x)
    {
        if (Singleton.data.cc > 0)
        {
            Vector3 nv = new Vector3(x, 6, 4);
            Coin b = Instantiate(c, nv, Quaternion.identity) as Coin;
            b.Link(this);
            Singleton.data.cc--;
        }
        else
        {
            Vector3 v = new Vector3(-12, 0, 0);
            FloatText g = Instantiate(ft, v, Quaternion.identity) as FloatText;
            g.SetText("No more coins!");
            g.SetColor(Color.red);
        }
    }

	public bool Paused = false, Added = false;
    float StepTime = 0, MoveSpeed = 1.5f;
    //int Steps = 0;

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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnSingle(-4);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpawnSingle(-3);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnSingle(-2);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SpawnSingle(-1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnSingle(0);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnSingle(1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnSingle(2);
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            SpawnSingle(3);
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            SpawnSingle(4);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Singleton.data.cc += 1000;
        }

		if (StepTime >= MoveSpeed)
		{
            if( !Added )
            {
                Added = true;
                Singleton.data.cc++;
            }
            else
            {
                Added = false;
            }

			StepTime = 0;

            //Steps++;

            Prize--;
            if( Prize <= 0 )
            {
                SpawnPrize();
            }
		}
		else// if(playing)
		{
			StepTime += Time.deltaTime;
		}

        cointxt.text = "Coins: " + Singleton.data.cc;
	
		if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			SceneManager.LoadScene ("MainScene", LoadSceneMode.Single);
		}
	}
}