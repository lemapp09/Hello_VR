using UnityEngine;

namespace LemApperson {
    public class PoliceAmbiance : MonoBehaviour {
        private AudioSource _policeAmbiance;

        private void OnTriggerEnter(Collider other) {
            AudioManager.Instance.PlayPolice();
            if(this.GetComponent<AudioSource>())
                this.GetComponent<AudioSource>().Play();
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player"))
            {
                AudioManager.Instance.StopPoliceSound();
            }
        }
    }
}
