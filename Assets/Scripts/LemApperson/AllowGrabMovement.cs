using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowGrabMovement : MonoBehaviour
{

    public void BlockCollisions()
    {
        var characterController = FindObjectOfType<CharacterController>();
        if (characterController != null)
        {
            var colliders = GetComponentsInChildren<Collider>();
            foreach (var collider in colliders)
            {
                Physics.IgnoreCollision(collider, characterController, true);
            }
        }
    }
}
