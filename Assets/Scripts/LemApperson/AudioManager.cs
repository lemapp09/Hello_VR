using UnityEngine;

namespace LemApperson
{
    public class AudioManager : MonoBehaviour
    {
        // Make an Instance
        public static AudioManager Instance;
        
        [SerializeField] private AudioSource _appluase;
        [SerializeField] private AudioSource _arcade1;
        [SerializeField] private AudioSource _arcade2;
        [SerializeField] private AudioSource _bells;
        [SerializeField] private AudioSource _bicycleHorn;
        [SerializeField] private AudioSource _click;
        [SerializeField] private AudioSource _doorOpen;
        [SerializeField] private AudioSource _hauntedRoom;
        [SerializeField] private AudioSource _police;
        [SerializeField] private AudioSource _squeakyToy;
        [SerializeField] private AudioSource _wontEscape;
        private bool _isInPoliceBarricade;
        private bool _enteringAsylum;
        private bool _isInAsylum;

        private void Awake() {
                Instance = this;
        }

        public void PlayAppluase() {
                _appluase.Play();
        }
        
        public void PlayArcade1() {
            _arcade1.Play();
        }
        
        public void PlayArcade2() {
            _arcade2.Play();
        }
        
        public void PlayBells() {
            _bells.Play();
        }
        
        public void PlayBicycleHorn() {
            _bicycleHorn.Play();
        }
        
        public void PlayClick (){
            _click.Play();
        }

        public void PlayDoorOpen()
        {
            _doorOpen.Play();
        }
        
        public void PlayHauntedRoom() {
            _hauntedRoom.Play();
        }

        public void StopHauntedRoom() {
            _hauntedRoom.Stop();
        }
        
        public void PlayPolice() {
            _police.Play();
        }

        public void StopPoliceSound() {
            _police.Stop();
        }
        
        public void PlaySqueakyToy() {
            _squeakyToy.Play();
        }


        public void PlayWontEscape()
        {
            _wontEscape.Play();
        }
    }
}
