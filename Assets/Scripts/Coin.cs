using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int t, v = 10;
    private bool setsy = false;
    //private MainEngine mainEngine;
    private GameEngine gameEngine;
    public Material[] mats;

    void Awake()
    {
        t = Random.Range(0, 4);
        SetCoin(t);
        //v = 10;
    }

    void Start()
    {
       // t = Random.Range(0, 4);
        //SetCoin(t);
        //v = 10;
    }

    public void Waste()
    {
        //transform.localScale += new Vector3(3F, 0, 2F);
    }

    public void SetCoin( int i )
    {
        t = i;
        GetComponent<Renderer>().material = mats[i];

        if (t == 3) // DOGE
            v = 1;
        else if (t == 2) // LTC
            v = 10;
        else if (t == 1) // USDT
            v = 20;
        else
            v = 30;
    }

    public void SetPrize()
    {
        v = v * 10;
        transform.localScale += new Vector3(2F, 0, 1.5F);
    }

    void OnMouseDown()
    {
        if (!setsy)
        {
            Singleton.data.cc++;
            Destroy(gameObject);
        }
    }
    /*
    public void LinkM(MainEngine e)
    {
        //setsy = true;
        mainEngine = e;
    }
    */
    public void Link(GameEngine e)
    {
        setsy = true;
        gameEngine = e;
    }

	void Update()
	{
		//transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

		if (gameObject.transform.position.y < -12)
		{
            if( setsy )
            {
                if (transform.position.z > -5.5)
                    gameEngine.addCash(v, false);
                else
                    gameEngine.addCash(v, true);
            }
            
			Destroy(gameObject);
		}
	}
}
