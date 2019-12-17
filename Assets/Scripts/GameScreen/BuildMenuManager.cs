using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BuildMenuManager : Managers
{
	public Text _hutText, _livingSpaceText, _elfText, _buildingMenuHeader;
	public Button _hutBuilding;

	private void Start()
	{
		_gameManager = FindGameManager();
	}

	private void Update()
	{
		// à mettre dans le people Manager
		_elfText.text = _gameManager._unassignedElf._name + " : " + _gameManager._unassignedElf._value + "/" + _gameManager._everyElf;
		//=================================
		_livingSpaceText.text = _gameManager._livingSpace._name + " : " + _gameManager._livingSpace._value;
		_hutText.text = "You own : " + _gameManager._huts._value + "\nBuy Cost : " + _gameManager._huts._dirtUpgradeCost + " dirt & " + _gameManager._huts._woodUpgradeCost + " wood\nLiving Space / Hut : " + _gameManager._huts._livingSpaceBonus;
	}
	public void CheckBuildingPossibilities()
	{
		if (_gameManager._wood._value >= _gameManager._huts._woodUpgradeCost && _gameManager._dirt._value >= _gameManager._huts._dirtUpgradeCost && !_gameManager._isHutBuildingUnlocked && _gameManager._isBuildingMenuUnlocked)
		{
			_hutBuilding.gameObject.SetActive(true);
			_hutText.gameObject.SetActive(true);
			_buildingMenuHeader.text = "Building Menu";
			_gameManager._chatManager.SendMessageToChat("That must be enough to build a little structure. Hopefully some creatures will join me in my journey...", Message.MessageType.discovery, "Discovery");
			_gameManager._chatManager.SendMessageToChat("- Go in Build menu and build your first structure", Message.MessageType.info, "Info");
			_gameManager._isHutBuildingUnlocked = true;
		}
	}
	public void OnClickBuildHut()
	{
		if (!_gameManager._isTutorialEnded && _gameManager._huts._value==5)
		{
			_gameManager._chatManager.SendMessageToChat("Building more huts is not important right now. I should focus on important things.", Message.MessageType.info, "Info");
			return;
		}
		if (_gameManager._dirt._value >= _gameManager._huts._dirtUpgradeCost && _gameManager._wood._value >= _gameManager._huts._woodUpgradeCost)
		{
			_gameManager._dirt._value -= _gameManager._huts._dirtUpgradeCost;
			_gameManager._wood._value -= _gameManager._huts._woodUpgradeCost;
			_gameManager._huts._dirtUpgradeCost = Math.Ceiling(_gameManager._huts._dirtUpgradeCost * 1.3);
			_gameManager._huts._woodUpgradeCost = Math.Ceiling(_gameManager._huts._woodUpgradeCost * 1.1);
			_gameManager._huts._value += 1;
			_gameManager._livingSpace._value += 1;
			
			if (_gameManager._huts._value == 1)
			{
				_elfText.gameObject.SetActive(true);
				StartCoroutine(_gameManager.GatheringPeople());
				_gameManager._chatManager.SendMessageToChat("It seems that this first hut interested some creature, it looks like an elf or something... Well it's better than nothing ! I should build some more huts in case other creatures wander around in the future, but I think I got lucky !", Message.MessageType.building, "Building");
				_gameManager._chatManager.SendMessageToChat("+1 Elf\n-Think\n-Build 5 Huts", Message.MessageType.info, "Info");
				_gameManager._isFirstHutBuilt = true;
			}
			if (_gameManager._huts._value == 5)
			{
				_gameManager._chatManager.SendMessageToChat("It start to look like a primitive village ! An Elf join the small comunity with some wood and dirt in his backpack !", Message.MessageType.advencement, "Advencement");
				_gameManager._chatManager.SendMessageToChat("+1 Elf, +300 dirt, +300 wood", Message.MessageType.info, "Info");
				_gameManager._unassignedElf._value += _gameManager._unassignedElf._valuePerTime;
				_gameManager.UpdateNumberOfElf();
				_gameManager._dirt._value += 300;
				_gameManager._wood._value += 300;
			}
		}
	}

	public void BuildingMenuSizeButtonClick()
	{
		if (_isMenuExpended)
		{

			RetractMenu(_menuUi,_menuButton,new Vector3(-109, -196, 0), "Build");
		}
		if (!_isMenuExpended)
		{
			ExpendMenu(_menuUi,_menuButton);
		}
		_isMenuExpended = !_isMenuExpended;
	}
}
