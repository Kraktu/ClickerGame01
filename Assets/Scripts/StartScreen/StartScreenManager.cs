using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
	public InputField _usernameField;
	public Button _startButton;
	public GameObject _startingScreenCanvas,_gameCanvas;
	public AudioSource _musicAudioSource,_soundFXAudioSource;
	public AudioClip _buzzerSound,_blessingSound,_ambiantNatureMusic;

	[HideInInspector]
	public string _username;
	
	ColorBlock _startButtonColors, _usernameFieldColors;


	private void Awake()
	{
		_startButtonColors = _startButton.colors;
		_usernameFieldColors = _usernameField.colors;
		_musicAudioSource.clip = _ambiantNatureMusic;
		_musicAudioSource.Play();
	}
	private void Update()
	{
		if (_usernameField.text.Length > 4)
		{
			//Set Start Button to Green
			_startButtonColors.normalColor = Color.green;
			_startButtonColors.highlightedColor = new Color(0.6639982f, 1, 0.6352941f, 1);
			_startButtonColors.pressedColor = Color.green;
			_startButtonColors.selectedColor = Color.green;
			_startButton.colors = _startButtonColors;

			//Set Username Field to Green
			_usernameFieldColors.selectedColor = new Color(0.6639982f, 1, 0.6352941f, 1);
			_usernameFieldColors.normalColor = new Color(0.6639982f, 1, 0.6352941f, 1);
			_usernameField.colors = _usernameFieldColors;

		}
		if(_usernameField.text.Length < 5)
		{
			//Set Start Button to Red
			_startButtonColors.normalColor = Color.red;
			_startButtonColors.highlightedColor = new Color(1, 0.6639982f, 0.6352941f, 1);
			_startButtonColors.pressedColor = Color.red;
			_startButtonColors.selectedColor = Color.red;
			_startButton.colors = _startButtonColors;

			//Set Username Field to Red
			_usernameFieldColors.selectedColor = new Color(1,0.6639982f, 0.6352941f, 1);
			_usernameFieldColors.normalColor = new Color(1, 0.6639982f, 0.6352941f, 1);
			_usernameField.colors = _usernameFieldColors;
		}
	}
	public void StartTheGame()
	{
		if (_usernameField.text.Length>4)
		{
			_username = _usernameField.text;
			_startingScreenCanvas.SetActive(false);
			_gameCanvas.SetActive(true);
			_soundFXAudioSource.clip = _blessingSound;
			_soundFXAudioSource.Play();

		}
		else
		{
			_soundFXAudioSource.clip = _buzzerSound;
			_soundFXAudioSource.Play();
		}
	}
}
