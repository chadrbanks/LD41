using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebRequest
{
	string url;
	WWWForm form = new WWWForm ();

	public void SetURL( string u )
	{
		url = u;
	}

	public void AddData( string name, string data )
	{
		form.AddField ( name, data );
	}

	public void AddData( string name, int data )
	{
		form.AddField ( name, data );
	}

	public WebResponse GetJson( WWW tokenRequest )
	{
		WebResponse jr = JsonUtility.FromJson<WebResponse>(tokenRequest.text);
		return jr;
	}

	public WWW SendRequest()
	{
		var headers = form.headers;
		headers.Add("Access-Control-Allow-Credentials", "true"); 
		headers.Add("Access-Control-Allow-Headers", "Accept"); 
		headers.Add("Access-Control-Allow-Methods", "POST"); 
		headers.Add("Access-Control-Allow-Origin", "*");

		WWW tokenRequest = new WWW( url, form.data, headers );

		WaitForSeconds w;
		while (!tokenRequest.isDone)
		{
			w = new WaitForSeconds (0.1f);
			if(Singleton.data.status == ReleaseStatus.development){Debug.Log (w);}
			/*
			if (c < 5000)
				c++;
			else
				break;
			*/
		}

		return tokenRequest;
	}
}

public class WebResponse
{
	public int id;
	public string status;
	public string message;
}
