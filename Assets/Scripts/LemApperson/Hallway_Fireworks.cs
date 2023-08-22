using System.Collections;
using UnityEngine;

public class Hallway_Fireworks : MonoBehaviour
{
    [SerializeField] private  GameObject[] _fireworks;
    [SerializeField] private GameObject _gameWonDisplay;
    [SerializeField] private GameManager _gameManager;

    private void Start() {
        for (int i = 0; i < _fireworks.Length; i++) {
            _fireworks[i].SetActive(false);
        }
    }

    public void ActivateFireworks() {
        if (_gameWonDisplay) {
            _gameWonDisplay.SetActive(true);
        }
        StartCoroutine(ActivateFireworksCoroutine());
    }

    private IEnumerator ActivateFireworksCoroutine() {
        yield return  new WaitForSeconds(7f);
        int i = 0;
        while (i < _fireworks.Length) {
            if (_fireworks[i]) {
                _fireworks[i].SetActive(true);
            }
            yield return  new WaitForSeconds(1f);
            if (_fireworks[i]) {
                _fireworks[i].SetActive(false);
            }
            i++;
        }
        _gameManager.EndGame();
    }
}
