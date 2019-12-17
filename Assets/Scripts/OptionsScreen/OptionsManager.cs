using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
	public AudioSource _musicAudioSource, _soundFXAudioSource;
	public Image _startBackground, _gameBackground, _optionsBackground;
	public GameObject _startCanvas, _gameCanvas,_optionsCanvas;
	GameObject _previousCanvas;
	Image _previousBackground;
	public bool _isMusicActive = true, _isFXActive = true, _isStoryActive = true, _isHelpActive = true;

	public void StartCallsOptions()
	{
		_previousCanvas = _startCanvas;
		_previousBackground = _startBackground;

		DefineBackgroundImage();
		ActivateOptionsMenu();
	}
	public void GameCallsOptions()
	{
		_previousCanvas = _gameCanvas;
		_previousBackground = _gameBackground;

		DefineBackgroundImage();
		ActivateOptionsMenu();
	}
	private void DefineBackgroundImage()
	{
		_optionsBackground.GetComponent<Image>().sprite = _previousBackground.GetComponent<Image>().sprite;
	}
	private void ActivateOptionsMenu()
	{
		_previousCanvas.SetActive(false);
		_optionsCanvas.SetActive(true);
	}

	public void FXToggle()
	{
		_isFXActive = !_isFXActive;
		if (_isFXActive)
		{
			_soundFXAudioSource.volume = 1;
		}
		if (!_isFXActive)
		{
			_soundFXAudioSource.volume = 0;
		}
	}
	public void MusicToggle()
	{
		_isMusicActive = !_isMusicActive;
		if(_isMusicActive)
		{
			_musicAudioSource.volume = 1;
		}
		if (!_isMusicActive)
		{
			_musicAudioSource.volume = 0;
		}
	}
	public void StoryToggle()
	{
		_isStoryActive = !_isStoryActive;
	}
	public void HelpToggle()
	{
		_isHelpActive = !_isHelpActive;

	}
	public void ResumeGame()
	{
		_optionsCanvas.SetActive(false);
		_previousCanvas.SetActive(true);
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
