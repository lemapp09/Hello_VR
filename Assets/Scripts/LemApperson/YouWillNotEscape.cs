using UnityEngine;

namespace LemApperson
{
    public class YouWillNotEscape : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AudioManager.Instance.PlayWontEscape();
            }
        }

    }
}