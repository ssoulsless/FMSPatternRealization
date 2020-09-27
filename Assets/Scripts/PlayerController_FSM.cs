using UnityEngine;

public class PlayerController_FSM : MonoBehaviour
{
    #region Player Variables

    public float jumpForce;
    public Transform head;
    public Transform weapon01;
    public Transform weapon02;

    public Sprite idleSprite;
    public Sprite duckingSprite;
    public Sprite jumpingSprite;
    public Sprite spinningSprite;

    private SpriteRenderer face;
    private Rigidbody rbody;

    private PlayerBaseState currentState;
    public readonly PlayerIdleState playerIdleState = new PlayerIdleState();
    public readonly PlayerJumpingState playerJumpingState = new PlayerJumpingState();
    public readonly PlayerDuckingState playerDuckingState = new PlayerDuckingState();

    public PlayerBaseState CurrentState
    {
        get
        {
            return currentState;
        }
    }
    public Rigidbody Rbody
    {
        get
        {
            return rbody;
        }
    }

    #endregion


    private void Awake()
    {
        face = GetComponentInChildren<SpriteRenderer>();
        rbody = GetComponent<Rigidbody>();
        SetExpression(idleSprite);
    }

    private void Start()
    {
        TransitionToState(playerIdleState);
    }
    void Update()
    {
        currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this);
    }

    public void SetExpression(Sprite newExpression)
    {
        face.sprite = newExpression;
    }
    public void TransitionToState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
