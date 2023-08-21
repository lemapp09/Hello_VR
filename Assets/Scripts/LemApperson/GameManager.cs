using LemApperson;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _checkListItemText;
    private bool[] _itemsFound;
    private bool[] _switches = new bool[2];
    private bool[] _levers = new bool [2];

    // 0 - Item 1 - key under folded clothes 
    // 1 - Item 2 - Unlock lower door lock
    // 2 - Item 3 - arrange photo frames on desk
    // 3 - Item 4 - Door Switches
    // 4 - Item 5 - Levers

    private void Start() {
        _itemsFound = new bool[_checkListItemText.Length];
    }

    public void ItemFound(int ItemNumber) {
        if (ItemNumber > -1 && ItemNumber < _checkListItemText.Length)
        {
            _itemsFound[ItemNumber] = true;
            if (_checkListItemText[ItemNumber])
            {
                _checkListItemText[ItemNumber].color = Color.black;
            }
        }
    }

    public void SetSwitch(int SwitchId)
    {
        _switches[SwitchId] = !_switches[SwitchId];
        AudioManager.Instance.PlayArcade1();
        CheckSwitches();
    }

    public void SetLever(int LeverId)
    {
        _switches[LeverId] = !_switches[LeverId];
        AudioManager.Instance.PlayArcade2();
        CheckLevers();
    }

    private void CheckSwitches()
    {
        if (_switches[0] && _switches[1]) {
                _itemsFound[3] = true;
                _checkListItemText[3].color = Color.black;
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
        }
        else
        {
            _itemsFound[4] = false;
            _checkListItemText[4].color = Color.grey;
            
        }
    }
}
