using UnityEngine;

namespace LemApperson {

    [RequireComponent(typeof(Animator))]
    public class ToggleSwitch : MonoBehaviour 
    {
        private Animator _anim;
        void Start() {
            if (GetComponent<Animator>()) {
                _anim = GetComponent<Animator>();
            }
        }

        public void Toggle() {
            if (_anim) {
                _anim.SetBool("SwitchOn", !_anim.GetBool("SwitchOn"));
            }
        }
    }
}