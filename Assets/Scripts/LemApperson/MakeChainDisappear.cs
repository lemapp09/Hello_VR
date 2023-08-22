using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MakeChainDisappear : MonoBehaviour
{

    [SerializeField] private GameObject _exitDoors;
    private Vector3 _scale;

    public void ShrinkChain()
    {
        StartCoroutine(ChainShrink());
    }

    private IEnumerator ChainShrink()
    {
        _scale = transform.localScale;
        while (_scale.x > 0.05f )
        {
            _scale = 0.99f * _scale ;
            transform.localScale = _scale;
            yield return new WaitForSeconds(0.01f);
        }

        if (_exitDoors.GetComponent<OpenDoor>())
        {
            _exitDoors.GetComponent<OpenDoor>().OpenExitDoors();
        }

        this.GameObject().SetActive(false);
    }
}
