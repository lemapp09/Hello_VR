using UnityEngine;

public class Health : MonoBehaviour
{
    // private int Health_Points = 1;
    private Skeleton_AI _skeletonAI;
    private BoxCollider _thisCollider;


    void Start()
    {
        _skeletonAI = gameObject.GetComponentInParent<Skeleton_AI>();
        _thisCollider = GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap") )
        {
            Debug.Log("I got killed");
            _thisCollider.enabled = false;
            _skeletonAI.YouDied = true;
        }
    }

}

