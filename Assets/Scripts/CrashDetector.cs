using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float loadDelay = .3f;
    [SerializeField] private ParticleSystem crashEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ground")) return;
        crashEffect.Play();
        Invoke(nameof(ReloadScene), loadDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}