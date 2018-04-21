using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TetButtonType
{
	BuyZ, BuyS, BuyBar, BuyBox, BuyJ, BuyL, BuyT
}

public class TetButton : MonoBehaviour
{
	GameEngine engn;
	public TetButtonType bt;

	[SerializeField] private Material m_NormalMaterial;
	[SerializeField] private Material m_OverMaterial;
	[SerializeField] private Material m_ClickedMaterial;
	[SerializeField] private Renderer m_Renderer;

	bool over = false;

	public void SetEngine( GameEngine m )
	{
		engn = m;
		m_Renderer.material = m_NormalMaterial;
	}

	void OnMouseOver()
	{
		if (!over)
		{
			m_Renderer.material = m_OverMaterial;
			engn.Hover (bt);
		}

		over = true;
	}

	void OnMouseExit()
	{
		m_Renderer.material = m_NormalMaterial;
		engn.Unhover ();
		over = false;
	}

	void OnMouseDown()
	{
		m_Renderer.material = m_ClickedMaterial;
	}

	void OnMouseUp()
	{
		m_Renderer.material = m_OverMaterial;//m_NormalMaterial;

		if (!engn.GameOver && !engn.Paused)
		{
			engn.Purchase (bt);
		}
	}
}