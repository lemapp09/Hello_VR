using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OpenDoor : MonoBehaviour
{
    
    private  Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenExitDoors()
    {
            _animator.SetTrigger("OpenDoor");
    }
}
