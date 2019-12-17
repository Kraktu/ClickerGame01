using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadquarterManager : Managers
{
	public Text _assignElfToHeadquarterText;
	public Button _electAMayorButton;

	private void Start()
	{
		_gameManager = FindGameManager();
	}

	public void OnClickAddAnElfToMayor()
	{
		if (_gameManager._unassignedElf._value > 0&&_gameManager._mayorElf._value==0)
		{
			_gameManager._unassignedElf._value -= 1;
			_gameManager._mayorElf._value += 1;
			_gameManager._isMayorElected = true;
			_electAMayorButton.gameObject.SetActive(false);
			_gameManager._chatManager.SendMessageToChat("Workers, a Mayor... It's a good Start, if only I could let the elves gather wood for me...", Message.MessageType.advencement, "Advencement");
			_gameManager._chatManager.SendMessageToChat("-Think", Message.MessageType.info, "info");
			_gameManager.UpdateNumberOfElf();
		}
		else if (_gameManager._mayorElf._value==0)
		{
			_gameManager._chatManager.SendMessageToChat("You need an Unassigned Elf to elect a Mayor. You need at least one Living Space to welcome an Elf to your Comunity. Build more houses to increase your chance of finding one Elf!", Message.MessageType.info, "info");
		}
	}
	public void HeadquarterMenuSizeButtonClick()
	{
		if (!_gameManager._isHeadquarterBuilt)
		{
			if (_gameManager._wood._value >= 150 && _gameManager._dirt._value >= 150)
			{
				_gameManager._wood._value -= 150;
				_gameManager._dirt._value -= 150;
				_menuButton.GetComponentInChildren<Text>().text = "Headquarter";
				_gameManager._isHeadquarterBuilt = true;
				_gameManager._chatManager.SendMessageToChat("New Headquarter built !! A mayor will surely Improvethe efficiency of Elves work...", Message.MessageType.building, "Building");
				_gameManager._chatManager.SendMessageToChat("-Open Headquarter menu and elect a Mayor", Message.MessageType.info, "info");
			}
			else
			{
				_gameManager._chatManager.SendMessageToChat("You need 150 wood and 150 dirt to build the Headquarter", Message.MessageType.building, "Building");
			}

		}
		else
		{

			if (_isMenuExpended)
			{
				RetractMenu(_menuUi, _menuButton, new Vector3(-845, -225, 0), "Headquarter");
			}
			if (!_isMenuExpended)
			{
				ExpendMenu(_menuUi, _menuButton);
			}
			_isMenuExpended = !_isMenuExpended;

		}
	}
}
