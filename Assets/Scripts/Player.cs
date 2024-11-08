using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;
    public float gravity = 9.8f + 2f;
    public float jumpForce = 8f;
    //Awake la ham tu dong duoc goi khi initial script nay trong unity
    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        direction = Vector3.zero;
    }
    private void Update()
    {
        direction = direction + Vector3.down * gravity * Time.deltaTime;
        if (character.isGrounded == true)
        {
            direction = Vector3.down;
            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
            }
        }
        character.Move(direction * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider character)
    {
        if (character.CompareTag("Obstacle"))
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision(6, 8, false);

    }

}