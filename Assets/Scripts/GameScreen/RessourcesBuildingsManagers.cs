using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourcesBuildingsManagers : Managers
{
	public Text _ressourceText, _assignElfToBuildingText;

	protected void UpdateText(Text ressourceText, string ressourceName,double ressourceValue)
	{
		ressourceText.text = ressourceName + " : " + ressourceValue.ToString("f0");
	}
	protected void OnClickGatherRessource(ref double ressourceValue,double ressourceValuePerClick,GameManager gameManager)
	{
		ressourceValue += ressourceValuePerClick;
		gameManager._buildMenuManager.CheckBuildingPossibilities();
	}
	protected void OnClickAddElfToBuilding(GameManager gameManager, ref double typeOfElfWantedValue)
	{
		if (gameManager._unassignedElf._value > 0)
		{
			gameManager._unassignedElf._value -= 1;
			typeOfElfWantedValue += 1;
			gameManager.UpdateNumberOfElf();
		}
		else if (gameManager._unassignedElf._value==0)
		{
			_gameManager._chatManager.SendMessageToChat("You need an Unassigned Elf to elect a Mayor. You need at least one Living Space to welcome an Elf to your Comunity. Build more houses to increase your chance of finding one Elf!", Message.MessageType.info, "info");
		}
	}
	protected void BuildRessourceBuilding(GameManager gameManager, int dirtCost, int woodCost,Text buttonText,string buttonTextToDisplay,ref bool isBuilt,string BuildingMessage,string infoMessage,IEnumerator automaticGatherCoroutine)
	{
		if (_gameManager._wood._value >= woodCost && _gameManager._dirt._value >= dirtCost)
		{
			gameManager._wood._value -= woodCost;
			gameManager._dirt._value -= dirtCost;
			buttonText.text = buttonTextToDisplay;
			isBuilt = true;
			_gameManager._chatManager.SendMessageToChat(BuildingMessage, Message.MessageType.building, "Building");
			_gameManager._chatManager.SendMessageToChat(infoMessage, Message.MessageType.info, "info");
			StartCoroutine(automaticGatherCoroutine);
		}
		else
		{
			_gameManager._chatManager.SendMessageToChat("You need "+ dirtCost + " dirt and "+ woodCost + " wood to build the "+ buttonTextToDisplay, Message.MessageType.building, "Building");
		}
	}
}
