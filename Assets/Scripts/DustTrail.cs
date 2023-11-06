using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem slideEffect;
    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground") {
            slideEffect.Play();
            audioSource.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground") {
            slideEffect.Stop();
            audioSource.Stop();
        }
    }
}
