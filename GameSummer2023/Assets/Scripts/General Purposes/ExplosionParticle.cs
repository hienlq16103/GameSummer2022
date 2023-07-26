using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour {

    [SerializeField] float existTime = 1.5f;

    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip explosionAudio;

    private void OnEnable() {
        explosionParticle.Play();
        audioSource.PlayOneShot(explosionAudio);
        StartCoroutine(DestroyParticleObject());
    }
    private IEnumerator DestroyParticleObject() {
        yield return new WaitForSeconds(existTime);
        Destroy(gameObject);
    }
}
