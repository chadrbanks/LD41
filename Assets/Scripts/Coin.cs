using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int v = 10;
    private bool setsy = false;
    //private MainEngine mainEngine;
    private GameEngine gameEngine;

	void Start()
	{
        //v = 10;
    }

    public void Waste()
    {
        //transform.localScale += new Vector3(3F, 0, 2F);
    }

    public void SetPrize()
    {
        v = 100;
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

		if (gameObject.transform.position.y < -50)
		{
            if( setsy )
                gameEngine.addCash(v);
            
			Destroy(gameObject);
		}
	}
}
