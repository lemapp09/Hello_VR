using LemApperson;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class FrameLock : MonoBehaviour
{
    [SerializeField] int[] _lockCode = new int[3] {  2, 3, 1 };
    [SerializeField] int[] _enteredCode = { 0, 0, 0 };
    AudioManager _audioManager => AudioManager.Instance;

    private XRSocketInteractor[] _interactors;
    [SerializeField] UnityEvent _onCheck;

    private void Start()
    {
        _interactors = GetComponentsInChildren<XRSocketInteractor>();
    }

    public void EnterSocket0()
    {
        _audioManager.PlayClick();
        var interactables = _interactors[0].interactablesSelected;
        
        FrameID id = interactables[0]?.transform.GetComponent<FrameID>();
        if (id != null)
        {
            _enteredCode[0] = id.GetID();
            if (CheckCode())
            {
                _onCheck.Invoke();
                _audioManager.PlayBells();
            }
        }
    }

    public void EnterSocket1()
    {
        _audioManager.PlayClick();
        _audioManager.PlayBicycleHorn();
        var interactables = _interactors[1].interactablesSelected;

        FrameID id = interactables[0]?.transform.GetComponent<FrameID>();
        if (id != null)
        {
            _enteredCode[1] = id.GetID();
            if (CheckCode())
            {
                _onCheck.Invoke();
                _audioManager.PlayBells();
            }
        }
    }

    public void EnterSocket2()
    {
        _audioManager.PlayClick();
        var interactables = _interactors[2].interactablesSelected;

        FrameID id = interactables[0]?.transform.GetComponent<FrameID>();
        if (id != null)
        {
            _enteredCode[2] = id.GetID();
            if (CheckCode())
            {
                _onCheck.Invoke();
                _audioManager.PlayBells();
            }
        }
    }


    private bool CheckCode()
    {
        if (_enteredCode.Length == _lockCode.Length)
        {
            for(int i = 0;  i < _enteredCode.Length; i++)
            {
                if (_enteredCode[i] != _lockCode[i])
                    return false;
            }
            return true;
        }
        else return false;
    }
}
