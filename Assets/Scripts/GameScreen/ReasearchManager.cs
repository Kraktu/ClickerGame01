using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReasearchManager : MonoBehaviour
{
	public GameManager _gameManager;
	public Text _researchPointText;
	public Button _dirtGathering, _woodGathering, _buildingMenu,_farmMenu,_lumberCampMenu,_headquarterMenu;
	private void Update()
	{
		_researchPointText.text = _gameManager._researchPoint._name + " : " + _gameManager._researchPoint._value.ToString("f0");
	}
	void CheckResearchUpgrades()
	{
		if (_gameManager._researchPoint._value >= 5 && !_gameManager._isDirtUnlocked)
		{
			_dirtGathering.gameObject.SetActive(true);
			_gameManager._farmManager._ressourceText.gameObject.SetActive(true);
			_gameManager._chatManager.SendMessageToChat("By gathering dirt I'll create path, discover new places and maybe it'll help me build something later.", Message.MessageType.discovery, "Discovery");
			_gameManager._chatManager.SendMessageToChat("-Gather one dirt and Think", Message.MessageType.info, "Info");
			_gameManager._isDirtUnlocked = true;
		}
		if (_gameManager._researchPoint._value >= 20 && _gameManager._dirt._value > 0 && !_gameManager._isWoodUnlocked)
		{
			_woodGathering.gameObject.SetActive(true);
			_gameManager._lumberManager._ressourceText.gameObject.SetActive(true);
			_gameManager._chatManager.SendMessageToChat("I can see some places where the wood seems to grow very fast. Creatures can eventually gather it with bare hands.", Message.MessageType.discovery, "Discovery");
			_gameManager._chatManager.SendMessageToChat("-Gather one wood and Think", Message.MessageType.info, "Info");
			_gameManager._isWoodUnlocked = true;
		}
		if (_gameManager._researchPoint._value >= 50 && _gameManager._wood._value > 0 && !_gameManager._isBuildingMenuUnlocked)
		{
			_buildingMenu.gameObject.SetActive(true);
			_gameManager._buildMenuManager._livingSpaceText.gameObject.SetActive(true);
			_gameManager._chatManager.SendMessageToChat("I should start buildling something, but I need more wood and dirt first", Message.MessageType.discovery, "Discovery");
			_gameManager._chatManager.SendMessageToChat("-Gather "+ _gameManager._huts._dirtUpgradeCost + " dirt and "+ _gameManager._huts._woodUpgradeCost + " wood", Message.MessageType.info, "Info");
			_gameManager._isBuildingMenuUnlocked = true;
		}
		if (_gameManager._researchPoint._value >= 90 && _gameManager._isFirstHutBuilt &&!_gameManager._isFarmUnlocked)
		{
			_farmMenu.gameObject.SetActive(true);
			_gameManager._chatManager.SendMessageToChat("If I gather enough ressources to build a farm, I may be able to send the elves to work for me.", Message.MessageType.discovery, "Discovery");
			_gameManager._chatManager.SendMessageToChat("-Build the Farm", Message.MessageType.info, "Info");
			_gameManager._isFarmUnlocked = true;

		}
		if (_gameManager._researchPoint._value >= 120 && _gameManager._isFarmBuilt && !_gameManager._isHeadquarterUnlocked)
		{
			_headquarterMenu.gameObject.SetActive(true);
			_gameManager._chatManager.SendMessageToChat("I should build a Headquarter fast if I want to plan my future and manage my growing people", Message.MessageType.discovery, "Discovery");
			_gameManager._chatManager.SendMessageToChat("-Build the Headquarter", Message.MessageType.info, "Info");
			_gameManager._isHeadquarterUnlocked = true;
		}
		if (_gameManager._researchPoint._value >= 150 && _gameManager._isMayorElected && !_gameManager._isLumberCampUnlocked)
		{
			_lumberCampMenu.gameObject.SetActive(true);
			_gameManager._chatManager.SendMessageToChat("If I gather enough ressources to build a Lumber Camp, I may be able to send the elves to work for me.", Message.MessageType.discovery, "Discovery");
			_gameManager._chatManager.SendMessageToChat("-Build the Lumber Camp", Message.MessageType.info, "Info");
			_gameManager._isLumberCampUnlocked = true;

		}
	}
	public void OnClickGatherResearchPoint()
	{
		_gameManager._researchPoint._value += _gameManager._researchPoint._valuePerClick;
		CheckResearchUpgrades();
		_gameManager._buildMenuManager.CheckBuildingPossibilities();

	}
}
