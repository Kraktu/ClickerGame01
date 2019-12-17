using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
	public Button _chatSizeButton;

	public int _maxMessages = 25;
	public GameObject _chatPanel, _emptyTextPrefab, _chatUI;
	public InputField _chatBox;
	public Color _playerMessageColor, _infoMessageColor, _discoveryMessageColor, _buildingMessageColor, _advencementMessageColor;
	public StartScreenManager _startScreenManager;
	public OptionsManager _optionsManager;

	[SerializeField]
	List<Message> _messageList = new List<Message>();

	string _username;
	bool _isChatExpanded = true;
	private void Update()
	{
		if (_chatBox.text !="")
		{
			if(Input.GetKeyDown(KeyCode.Return))
			{
				SendMessageToChat(_chatBox.text+"\n*Nobody seems to listen what I say...*",Message.MessageType.playerMessage,_username);
				_chatBox.text = "";
			}
		}
		else
		{
			if (!_chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
			{
				_chatBox.ActivateInputField();
			}
		}

		if(!_chatBox.isFocused)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				SendMessageToChat("I should think more and act less.",Message.MessageType.info,"Info");
			}
		}
	}
	public void SendMessageToChat(string text, Message.MessageType messageType,string username)
	{
		if(_optionsManager._isHelpActive==false && messageType == Message.MessageType.info)
		{
			return;
		}
		if( _optionsManager._isStoryActive == false&& (messageType == Message.MessageType.discovery||messageType==Message.MessageType.building||messageType==Message.MessageType.advencement) )
		{ 
			return;
		}
		Message newMessage = new Message();
		GameObject newText = Instantiate(_emptyTextPrefab, _chatPanel.transform);

		if(_messageList.Count>= _maxMessages)
		{
			Destroy(_messageList[0]._textObject.gameObject);
			_messageList.Remove(_messageList[0]);
		}

		newMessage._text = username +":  "  + text;
		newMessage._textObject = newText.GetComponent<Text>();
		newMessage._textObject.text = newMessage._text;
		newMessage._textObject.color = MessageTypeColor(messageType);


		_messageList.Add(newMessage);
	}

	Color MessageTypeColor(Message.MessageType messageType)
	{
		Color color = _infoMessageColor;
		
		switch(messageType)
		{
			case Message.MessageType.playerMessage:
				color = _playerMessageColor;
				break;
			case Message.MessageType.info:
				color = _infoMessageColor;
				break;
			case Message.MessageType.discovery:
				color = _discoveryMessageColor;
				break;
			case Message.MessageType.building:
				color = _buildingMessageColor;
				break;
			case Message.MessageType.advencement:
				color = _advencementMessageColor;
				break;
		}

		return color;
	}
	public void ChatSizeButtonClick()
	{
		if (_isChatExpanded)
		{

			RetractChat();
		}
		if (!_isChatExpanded)
		{
			ExpandChat();
		}
		_isChatExpanded = !_isChatExpanded;
	}
	void RetractChat()
	{
		_chatUI.transform.localScale = Vector3.zero;
		_chatSizeButton.transform.localPosition = new Vector3(-900, -517, 0);
		_chatSizeButton.GetComponentInChildren<Text>().text = "Expand";
	}
	void ExpandChat()
	{
		_chatUI.transform.localScale = Vector3.one;
		_chatSizeButton.transform.localPosition = new Vector3(-360, -240, 0);
		_chatSizeButton.GetComponentInChildren<Text>().text = "Retract";
	}
	public void SetUserNameInChat()
	{
		if (_startScreenManager._usernameField.text.Length > 4)
		{
			_username = _startScreenManager._usernameField.text;
		}
	}
}

[System.Serializable]
public class Message
{
	public string _text;
	public Text _textObject;
	public MessageType _messageType;
	public enum MessageType
	{
		playerMessage,
		info,
		discovery,
		building,
		advencement
	}
}
