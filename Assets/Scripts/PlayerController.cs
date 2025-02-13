using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 10f;
    [SerializeField] private float boostSpeed = 40f;
    [SerializeField] private float baseSpeed = 25f;
    public bool allowMovement = true;
    private Rigidbody2D _rb2d;
    private SurfaceEffector2D _surfaceEffector;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _surfaceEffector = FindFirstObjectByType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (!allowMovement) return;
        RotatePlayer();
        RespondToBoost();
    }

    public void DisableControls()
    {
        allowMovement = false;
    }

    private void RespondToBoost()
    {
        _surfaceEffector.speed = Input.GetKey(KeyCode.UpArrow) ? boostSpeed : baseSpeed;
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            _rb2d.AddTorque(torqueAmount);
        else if (Input.GetKey(KeyCode.RightArrow))
            _rb2d.AddTorque(-torqueAmount);
    }
}