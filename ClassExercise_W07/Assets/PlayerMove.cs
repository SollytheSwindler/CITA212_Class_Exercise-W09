using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector2 PosPlayer;
    Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ExampleMove();
    }

    public void OnMove(InputValue value)
    {
        PosPlayer = value.Get<Vector2>();
        //PosPlayer.x = value.gameobject.position.x;
        //PosPlayer.y = value.gameobject.position.y;
        Debug.Log(PosPlayer);
    }
    void ExampleMove()
    {
        Vector2 PlayerSpeed = new Vector2(PosPlayer.x*10f, rigidbody.linearVelocity.y);
        rigidbody.linearVelocity = PlayerSpeed;
    }
}
