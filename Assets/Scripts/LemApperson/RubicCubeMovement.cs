using System.Collections;
using UnityEngine;

namespace LemApperson {
    public class RubicCubeMovement : MonoBehaviour {
        
        private void OnEnable() {
            
            // physics.sphereCastAll locate game objects on layer 8
            Vector3 origin = transform.position;
            Vector3 direction = Vector3.forward;
            float distance = 5f;
            int layerMask = 1 << 8;
            RaycastHit[] hits = Physics.SphereCastAll(origin, 0.25f, direction, distance, layerMask);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.CompareTag("RocketLauncher"))
                {
                    transform.rotation = hits[i].transform.rotation;
                    break;
                }
            }
            transform.GetComponent<Rigidbody>().AddForce(this.transform.forward * 500f);
        }
        
        private void OnCollisionEnter(Collision other) {
            if (other.transform.CompareTag("Ground"))
                StartCoroutine(CountdownToDestroy());
        
        }

        private IEnumerator CountdownToDestroy()
        {
            yield return new WaitForSeconds(2f);
            Destroy(this.gameObject);
        }
    }
}