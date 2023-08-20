using UnityEngine;

public class SetChainsFree : MonoBehaviour
{
    [SerializeField] private GameObject _chains;
    private int count = 0;

    public void LockOpened()
    {
        count++;
        if (count == 2)
        {
            _chains.SetActive(true);
        }
    }

}
