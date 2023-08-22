using LemApperson;
using TMPro;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _checkListItemText;
    [SerializeField] private GameObject _chains;
    private AudioSource _audioSource;
    private bool[] _itemsFound;
    private bool[] _switches = new bool[2];
    private bool[] _levers = new bool [2];

    // 0 - Item 1 - key under folded clothes 
    // 1 - Item 2 - Unlock lower door lock
    // 2 - Item 3 - arrange photo frames on desk
    // 3 - Item 4 - Door Switches
    // 4 - Item 5 - Levers
    // 5 - Item 6 - Second Key in tool chest
    // 6 - Item 7 - Unlock upper door lock
    // 7 - Item 8 - Grab Wrench
    // 8 - Item 9 - Undo chains

    private void Start() {
        _itemsFound = new bool[_checkListItemText.Length];
        _audioSource = GetComponent<AudioSource>();
    }

    public void ItemFound(int ItemNumber) {
        if (ItemNumber > -1 && ItemNumber < _checkListItemText.Length)
        {
            _itemsFound[ItemNumber] = true;
            if (_checkListItemText[ItemNumber]) {
                _checkListItemText[ItemNumber].color = Color.black;
            }
        }
        UndoBlockOnChains();
    }

    public void SetSwitch(int SwitchId)
    {
        _switches[SwitchId] = !_switches[SwitchId];
        AudioManager.Instance.PlayArcade1();
        CheckSwitches();
    }

    public void SetLever(int LeverId)
    {
        _levers[LeverId] = !_levers[LeverId];
        AudioManager.Instance.PlayArcade2();
        CheckLevers();
    }

    private void CheckSwitches()
    {
        if (_switches[0] && _switches[1]) {
                _itemsFound[3] = true;
                _checkListItemText[3].color = Color.black;
                _audioSource.Play();
                UndoBlockOnChains();
        }
        else
        {
            _itemsFound[3] = false;
            _checkListItemText[3].color = Color.grey;
            
        }
    }
    
    private void CheckLevers()
    {
        if (_levers[0] && _levers[1]) {
            _itemsFound[4] = true;
            _checkListItemText[4].color = Color.black;
            _audioSource.Play();
            UndoBlockOnChains();
        }
        else
        {
            _itemsFound[4] = false;
            _checkListItemText[4].color = Color.grey;
            
        }
    }

    private void UndoBlockOnChains()
    {
        int count = 0;
        for (int i = 0; i < _checkListItemText.Length; i++) {
            if (_itemsFound[i]) {
                count++;
            }
        }

        if (count > 6) {
            _chains.SetActive(true);
        }  else {
            _chains.SetActive(false);
        }
    }
}
