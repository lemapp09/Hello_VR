using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LemApperson
{
    public class Eat : MonoBehaviour
    {

        public void EatTheFood()
        {
            StartCoroutine(EatTheFoodDelay());
        }

        private IEnumerator EatTheFoodDelay()
        {
            yield return new WaitForSeconds(2.0f);
            Destroy(gameObject);
        }
    }
}