using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem blessureEffect;
    [SerializeField] AudioClip crashSFX;
    bool crashed = false;

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Ground" && !crashed) {
            Debug.Log("You crashed!");
            crashed = true;

            blessureEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);            

            FindObjectOfType<Boarder>().DisableControls();

            Invoke("ReloadScene", delay);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
