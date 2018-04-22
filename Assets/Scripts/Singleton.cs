using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReleasePlatform
{
	mac, windows
}
public enum ReleaseStatus
{
	development, production
}

[DisallowMultipleComponent]
public class Singleton : MonoBehaviour
{
	public static Singleton data;

	// CHANGE THESE IN UNITY!
	public string version = "0.0"; // CHANGE IN UNITY
	public ReleaseStatus status;
	public ReleasePlatform platform;
	public FloatText gft;

    public int cc = 0;

	void Awake()
	{
		if (data == null)
		{
			DontDestroyOnLoad(gameObject);
			data = this;
		}
		else if (data != this)
		{
			Destroy(gameObject);
		}
	}
}