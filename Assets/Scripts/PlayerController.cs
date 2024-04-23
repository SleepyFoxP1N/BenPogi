using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector2 MovementSpeed = new Vector2(100.0f, 100.0f);


    // ===== ===== ===== ===== ===== COMPONENTS
    private new Rigidbody2D rigidbody2D;


    public PlayerInputAction playerControls;
    private InputAction movement;
    private InputAction shoot;


    // ===== ===== ===== ===== ===== VARIABLES DECLARATION
    private Vector2 moveDirection = new Vector2(0.0f, 0.0f);


    // 覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧 //
    //                            UNITY METHODS                             //
    // 覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧 //

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputAction();
        PlayerStateHandler.Instance.CurrentState = PlayerStateHandler.PlayerStateEnum.Idle;
    }

    private void OnEnable()
    {
        setUpPlayerControls();
        enablePlayerControls();
        shoot.performed += onShoot;
    }
    private void OnDisable()
    {
        disablePlayerControls();
    }

    void Update()
    {
        moveDirection = movement.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + (moveDirection * MovementSpeed * Time.fixedDeltaTime));
    }

    // 覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧 //
    //                          PERSONAL METHODS                            //
    // 覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧 //

    private void setUpPlayerControls()
    {
        movement = playerControls.Player.Move;
        shoot = playerControls.Player.Fire;
    }
    private void enablePlayerControls()
    {
        movement.Enable();
        shoot.Enable();
    }
    private void disablePlayerControls()
    {
        movement.Disable();
        shoot.Disable();
    }

    private void onShoot(InputAction.CallbackContext context)
    {
        Debug.Log(moveDirection);
    }
}