using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float loadDelay = .5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSfx;
    private CircleCollider2D _playerHead;
    private bool _isCrashed;
    

     private void Start()
     {
         _playerHead = GetComponent<CircleCollider2D>();
     }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && 
            _playerHead.IsTouching(other.gameObject.GetComponent<Collider2D>()) &&
            !_isCrashed)
        {
            _isCrashed = true;
            FindFirstObjectByType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSfx);
            Invoke(nameof(ReloadScene), loadDelay);
        }
        
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}