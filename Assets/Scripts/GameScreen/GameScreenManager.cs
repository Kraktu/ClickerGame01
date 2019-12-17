using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenManager : MonoBehaviour
{
	public AudioSource _musicAudioSource, _soundFXAudioSource;
	public AudioClip _StrangeMusic;
	bool _isIntro = true;
	public StartScreenManager _startScreenManager;

	public void StartGameMusic()
	{
		if (_startScreenManager._usernameField.text.Length > 4 && _isIntro)
		{
			_musicAudioSource.clip = _StrangeMusic;
			_musicAudioSource.Play();
		}
	}
}
