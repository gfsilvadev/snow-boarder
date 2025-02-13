using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float loadDelay = .3f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSfx;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ground")) return;
        crashEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSfx);
        Invoke(nameof(ReloadScene), loadDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}