using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : RessourcesBuildingsManagers
{
	private void Start()
	{
		_gameManager = FindGameManager();
	}
	private void Update()
	{
		UpdateText(_ressourceText, _gameManager._dirt._name, _gameManager._dirt._value);
	}
	public void OnClickGatherDirt()
	{
		OnClickGatherRessource(ref _gameManager._dirt._value, _gameManager._dirt._valuePerClick, _gameManager);
	}
	public void OnClickAddAnElfToFarm()
	{
		OnClickAddElfToBuilding(_gameManager,ref _gameManager._farmerElf._value);
		if (_gameManager._farmerElf._value==1)
		{
			_gameManager._chatManager.SendMessageToChat("The new farmer should gather some dirt for me ! It'll ease the work to build more huts or continue Thinking.", Message.MessageType.advencement, "Advencement");
			_gameManager._chatManager.SendMessageToChat("Wood + 150\n-Think\n-Build more huts to welcome more Elves in the community", Message.MessageType.info, "info");
			_gameManager._wood._value += 150;
		}
	}
	public void FarmMenuSizeButtonClick()
	{
		if (!_gameManager._isFarmBuilt)
		{
			BuildRessourceBuilding(_gameManager, 100, 100, _menuButton.GetComponentInChildren<Text>(), "Farm", ref _gameManager._isFarmBuilt,
			"The new farm is up to work, maybe some Elves can gather dirt for me ?",
			"-Open Farm menu and send an Elf to work",
			_gameManager.GatheringDirt());
		}
		else
		{
			if (_isMenuExpended)
			{
				RetractMenu(_menuUi, _menuButton, new Vector3(345, -618, 0), "Farm");
			}
			if (!_isMenuExpended)
			{
				ExpendMenu(_menuUi, _menuButton);
			}
			_isMenuExpended = !_isMenuExpended;
		}
	}
}
