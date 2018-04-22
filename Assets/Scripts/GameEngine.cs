using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
	public bool GameOver = false;
	public Coin c;
	Dictionary <int, Coin> coins = new Dictionary<int, Coin>();
    public int cash;
	public FloatText ft;
	//public TextMesh got, next, CashText, CostText, CostText2;

	//public AudioSource failure, mainsong;

	void Start ()
	{
        cash = 1000;
        /*
        Vector3 v = new Vector3 (x, 0, 10);
        FloatText g = Instantiate(ft, v, Quaternion.identity) as FloatText;
        g.SetText( "+ $" + reward );
        g.SetColor( Color.green );
        */

        for (int x = 0; x < 200; x++ )
        {
            SpawnSetup( Random.Range(-4, 5), 5, Random.Range(-4, 5));
        }
    }

    void SpawnSetup(int x, int y, int z)
    {
        Vector3 nv = new Vector3(x,y,z);
        Coin b = Instantiate(c, nv, Quaternion.identity) as Coin;
        b.Waste();
    }

    void SpawnSingle(int x)
    {
        Vector3 nv = new Vector3(x, 5, 4);
        Coin b = Instantiate(c, nv, Quaternion.identity) as Coin;
        b.Waste();
    }

	public bool Paused = false;
    float StepTime = 0, MoveSpeed = 1.5f;

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

		if (StepTime >= MoveSpeed)
		{
            //SpawnSingle(5);
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