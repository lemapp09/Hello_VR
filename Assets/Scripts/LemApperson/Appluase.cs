using System;
using UnityEngine;

namespace LemApperson
{
    public class Appluase : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // AudioManager.Instance.PlayAppluase();
                if(this.GetComponent<AudioSource>())
                    this.GetComponent<AudioSource>().Play();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                // AudioManager.Instance.PlayAppluase();
                if(this.GetComponent<AudioSource>())
                    this.GetComponent<AudioSource>().Play();
            }
        }
    }
}