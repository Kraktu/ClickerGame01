using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour

{
	public ChatManager _chatManager;
	public FarmManager _farmManager;
	public BuildMenuManager _buildMenuManager;
	public LumberManager _lumberManager;
	public ReasearchManager _reasearchManager;
	public HeadquarterManager _headquarterManager;
	public Ressource _researchPoint, _dirt, _wood, _livingSpace, _unassignedElf, _workingElf,_farmerElf,_lumberElf,_mayorElf;
	public Building _huts;
	public int _minWaitTimeToRecruit=40, _maxWaitTimeToRecruit=60;
	

	[HideInInspector]
	public double _everyElf=0;
	[HideInInspector]
	public bool _isWoodUnlocked = false, _isDirtUnlocked = false, _isHutBuildingUnlocked = false, _isBuildingMenuUnlocked = false, _isFirstHutBuilt = false, _isLumberCampBuilt = false, _isFarmBuilt = false, _isFarmUnlocked = false, _isLumberCampUnlocked = false, _isHeadquarterBuilt = false, _isMayorElected = false, _isHeadquarterUnlocked=false;
	public bool _isTutorialEnded=false;
	private void Awake()
	{

		_researchPoint = new Ressource { _name = "RP" };
		_dirt = new Ressource { _name = "Dirt" };
		_wood = new Ressource { _name = "Wood" };
		_livingSpace = new Ressource { _name = "Living Space" };
		_unassignedElf = new Ressource { _name = "Elves", _valuePerTime = 1 };
		_workingElf = new Ressource { _name = "Working Elves" };
		_farmerElf = new Ressource { _name = "Farmer Elves" };
		_lumberElf = new Ressource { _name = "Lumber Elves" };
		_mayorElf = new Ressource { _name = "Mayor" };
		_huts = new Building { _woodUpgradeCost = 50, _dirtUpgradeCost = 25, _name = "Huts", _livingSpaceBonus = 1 };
	}

	public IEnumerator GatheringResearchPoint()
	{
		while (true)
		{
			_researchPoint._value += _researchPoint._valuePerTime * Time.deltaTime;
			yield return null;
		}

	}
	public IEnumerator GatheringDirt()
	{
		while (true)
		{
			_dirt._value += _dirt._valuePerTime *_farmerElf._value* Time.deltaTime;
			yield return null;
		}

	} 
	public IEnumerator GatheringWood()
	{
		while (true)
		{
			_wood._value += _wood._valuePerTime *_lumberElf._value* Time.deltaTime;
			yield return null;
		}
	}
	public IEnumerator GatheringPeople()
	{
		while (true)
		{
			if (_livingSpace._value>0)
			{
				if (_livingSpace._value > _unassignedElf._valuePerTime)
				{
					_unassignedElf._value += _unassignedElf._valuePerTime;
					_livingSpace._value -= _unassignedElf._valuePerTime;
				}
				else
				{
					_unassignedElf._value += _livingSpace._value;
					_livingSpace._value -= _livingSpace._value;
				}
				UpdateNumberOfElf();
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(_minWaitTimeToRecruit, _maxWaitTimeToRecruit));
		}
	}
	public void UpdateNumberOfElf()
	{
		_workingElf._value = _farmerElf._value + _lumberElf._value+_mayorElf._value;
		_everyElf = _unassignedElf._value + _workingElf._value;
		_farmManager._assignElfToBuildingText.text = "Farmer : " + _farmerElf._value;
		_lumberManager._assignElfToBuildingText.text = "Lumber : " + _lumberElf._value;
		_headquarterManager._assignElfToHeadquarterText.text = "Mayor : " + _mayorElf._value;
	}

}
public class Ressource
{
	public string _name;
	public double _value=0, _valuePerClick=1, _valuePerTime=0.3;
}
public class Building
{
	public string _name;
	public double _value = 0, _woodUpgradeCost, _dirtUpgradeCost,_livingSpaceBonus;
}
