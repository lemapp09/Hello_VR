//This script uses the system time to position the hands of a clock. You may assign as many or few hands as you wish, but I recommend you use all 3!
//And of course you can use your own watch model, should work with any as long as the hands are
//all at 12:00 when their rotation is zeroed and their local Z axis is perpendicular to the clock face

using System;
using UnityEngine;

public class CountDown : MonoBehaviour
{
	[SerializeField] private GameObject _5MinutesLeft;
	[SerializeField] private GameObject _1MinuteLeft;
	[SerializeField] private GameObject _GameOver;
	[SerializeField] private GameManager _gameManager;
	private bool _1MinuteOn;
	private bool _5MinutesOn;
	private bool _GameOverOn;
	
	public Transform Minutes;
	public Transform Seconds;
	   // time in seconds
	public float _timeRemaining = 300f;
	[SerializeField] private GameObject _LocksAndChains;
	[SerializeField] private OpenDoor _exitDoor;

	private void Start()
	{
		if(_5MinutesLeft) { _5MinutesLeft.SetActive(false);}
		if(_1MinuteLeft) {_1MinuteLeft.SetActive(false);}

		if (_GameOver) { _GameOver.SetActive(false); }
	}

	void Update () {
		_timeRemaining -= Time.deltaTime; // deltaTime is in seconds
		if (_timeRemaining > 0) {
			float minute = Mathf.Round(_timeRemaining / 60f);
			float second = _timeRemaining - (minute * 60);
			if (Minutes) Minutes.localRotation = Quaternion.Euler(0, 0, minute / 60 * 360);
			if (Seconds) Seconds.localRotation = Quaternion.Euler(0, 0, second / 60 * 360);

			if (_timeRemaining < 300 && !_5MinutesOn && _timeRemaining >= 60) {
				if(_5MinutesLeft) _5MinutesLeft.SetActive(true);
				_5MinutesOn = true;
			} else if (_timeRemaining < 60 && !_1MinuteOn) {
				if (_1MinuteLeft) _1MinuteLeft.SetActive(true);
				_1MinuteOn = true;
				if (_5MinutesLeft) _5MinutesLeft.SetActive(false);
				_5MinutesOn = false;
			}
		}  else {
			if (!_GameOverOn) {
				if (_GameOver) _GameOver.SetActive(true);
				_GameOverOn = true;
				if (_1MinuteLeft) _1MinuteLeft.SetActive(false);
				_1MinuteOn = false;
				if(_LocksAndChains) _LocksAndChains.SetActive(false);
				if(_exitDoor) _exitDoor.OpenExitDoors();
				_gameManager.EndGame();
			}
		}
	}
}
