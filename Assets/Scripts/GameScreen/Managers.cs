using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Managers : MonoBehaviour
{
	public GameObject _menuUi;
	public Button _menuButton;
	protected GameManager _gameManager;
	protected bool _isMenuExpended=false;

	protected GameManager FindGameManager()
	{
		return FindObjectOfType<GameManager>();
	}

	protected void ExpendMenu(GameObject menuUI,Button menuButton)
	{
		menuUI.transform.localScale = Vector3.one;
		menuButton.transform.localPosition = new Vector3(744, 270, 0);
		menuButton.GetComponentInChildren<Text>().text = "Exit";
	}
	protected void RetractMenu(GameObject menuUI,Button menuButton,Vector3 originalButtonPos, string menuName)
	{
		menuUI.transform.localScale = Vector3.zero;
		menuButton.transform.localPosition = originalButtonPos;
		menuButton.GetComponentInChildren<Text>().text = menuName;
	}
}
