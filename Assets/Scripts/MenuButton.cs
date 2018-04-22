using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuButtonType
{
	Start, Quit, Credits, Back
}

public class MenuButton : MonoBehaviour
{
	public MainEngine engn;
	public MenuButtonType bt;

	[SerializeField] private Material m_NormalMaterial;
	[SerializeField] private Material m_OverMaterial;
	[SerializeField] private Material m_ClickedMaterial;
	[SerializeField] private Renderer m_Renderer;

	bool over = false;

	void Start()
	{
		m_Renderer.material = m_NormalMaterial;
	}

	void OnMouseOver()
	{
		if (!over)
		{
			m_Renderer.material = m_OverMaterial;
		}

		over = true;
	}

	void OnMouseExit()
	{
		m_Renderer.material = m_NormalMaterial;
		over = false;
	}

	void OnMouseDown()
	{
		m_Renderer.material = m_ClickedMaterial;
	}

	void OnMouseUp()
	{
		m_Renderer.material = m_OverMaterial;//m_NormalMaterial;

		if (bt == MenuButtonType.Start)
		{
			SceneManager.LoadScene ("GameScene", LoadSceneMode.Single);
		}
		else if (bt == MenuButtonType.Credits)
		{
			//engn.ToggleCredits (false);
		}
		else if (bt == MenuButtonType.Back)
		{
			//engn.ToggleCredits (true);
		}
		else if (bt == MenuButtonType.Quit)
		{
			UnityEngine.Application.Quit ();

			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
		}
	}
}