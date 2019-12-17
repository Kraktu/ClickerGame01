using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LumberManager : RessourcesBuildingsManagers
{
	private void Start()
	{
		_gameManager = FindGameManager();
	}
	private void Update()
	{
		UpdateText(_ressourceText, _gameManager._wood._name, _gameManager._wood._value);
	}
	public void OnClickGatherWood()
	{
		OnClickGatherRessource(ref _gameManager._wood._value, _gameManager._wood._valuePerClick, _gameManager);
	}
	public void OnClickAddAnElfToLumberCamp()
	{
		OnClickAddElfToBuilding(_gameManager,ref _gameManager._lumberElf._value);
		if (!_gameManager._isTutorialEnded && _gameManager._lumberElf._value==1)
		{
			_gameManager._isTutorialEnded = true;
			_gameManager._livingSpace._value += 7;
			_gameManager._minWaitTimeToRecruit = 60;
			_gameManager._maxWaitTimeToRecruit = 600;
			_gameManager._huts._woodUpgradeCost =500;
			_gameManager._huts._woodUpgradeCost =500;
			_gameManager._chatManager.SendMessageToChat("Everything comes to an end. Even a good tutorial. Congratulation ! You know all the basics of the game, you are ready to manager your people how you desire. Good luck in your adventure !", Message.MessageType.info, "info");
			_gameManager._chatManager.SendMessageToChat("- Higher time to find Elves\n- Higher cost to build Huts\n- You can build more Huts\n- A lot more things unlocked in menus, find out by yourself !\n When you think you can't unlock anything else... Think... until TRANSCENDENCE.", Message.MessageType.info, "info");
		//Show all the new menu buttons
		}
	}
	public void LumberCampMenuSizeButtonClick()
	{
		if (!_gameManager._isLumberCampBuilt)
		{
			BuildRessourceBuilding(_gameManager, 200, 200, _menuButton.GetComponentInChildren<Text>(), "Lumber Camp", ref _gameManager._isLumberCampBuilt,
				"The new Lumber Camp is up to work, maybe some Elves can gather wood for me ?",
				"-Open Lumber Camp menu and send an Elf to work",
				_gameManager.GatheringWood());
		}
		else
		{
			if (_isMenuExpended)
			{
				RetractMenu(_menuUi, _menuButton, new Vector3(38, -65, 0), "Lumber Camp");
			}
			if (!_isMenuExpended)
			{
				ExpendMenu(_menuUi,_menuButton);
			}
			_isMenuExpended = !_isMenuExpended;
		}
	}
}
