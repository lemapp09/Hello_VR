using UnityEngine;

namespace LemApperson {

    [RequireComponent(typeof(Animator))]
    public class ToggleCabinet : MonoBehaviour 
    {
        private Animator _anim;
        void Start() {
            if (GetComponent<Animator>()) {
                _anim = GetComponent<Animator>();
            }
        }

        public void Toggle() {
            if (_anim) {
                _anim.SetBool("CabinetOpen", !_anim.GetBool("CabinetOpen"));
            }
        }
    }
}