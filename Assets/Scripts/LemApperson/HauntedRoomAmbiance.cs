using UnityEngine;

namespace LemApperson {
    public class HauntedRoomAmbiance : MonoBehaviour {
        private AudioSource _policeAmbiance;

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                AudioManager.Instance.PlayHauntedRoom();
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player"))
            {
                AudioManager.Instance.StopHauntedRoom();
            }
        }
    }
}
