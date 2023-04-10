using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.UI;

public class CharacterController2D : MonoBehaviour
{
    public int apples = 0;
    public Slider appleSlider;
    public Slider bookSlider;
    public int books = 0;

    public float speed = 5f;
    private float horizontal;
    private float vertical;
    private bool isFacingUp;
    public Animator animator;
    public GameObject fener;
    private bool disabled;



    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        appleSlider.minValue = 0;
        appleSlider.maxValue = 10;
        bookSlider.minValue = 0;
        bookSlider.maxValue = 10;
        rb = GetComponent<Rigidbody2D>();
        EnemyVision.OnGuardHasSpottedPlayer += Disabled;
    }

    void Update()
    {
        appleSlider.value = apples;
        bookSlider.value = books;
        if (disabled)
        {
            transform.position = new Vector3(0, -2, 0);

        }

        Vector3 inputDirection = Vector3.zero;
        if (!disabled)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }


        Flip();
        animator.SetFloat("horizontal speed", Mathf.Abs(horizontal));
        animator.SetFloat("vertical speed", Mathf.Abs(vertical));

        // Calculate the character's new position based on the input and speed
        Vector3 newPosition = transform.position +
                              new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);

        // Move the character to the new position
        transform.Translate(newPosition - transform.position);

    }



    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        if (vertical > 0 && !isFacingUp || vertical < 0 && isFacingUp)

        {
            isFacingUp = !isFacingUp;

            Vector3 fenerLocalScale = fener.transform.localScale;
            fenerLocalScale.y = Mathf.Abs(fenerLocalScale.y) * (isFacingUp ? -1 : 1);
            fener.transform.localScale = fenerLocalScale;
        }

    }

    void Disabled()
    {
        disabled = true;
    }

    void OnDestroy()
    {
        EnemyVision.OnGuardHasSpottedPlayer -= Disabled;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the character collided with an apple
        if (other.gameObject.CompareTag("Apple"))
        {
            // Destroy the apple game object
            Destroy(other.gameObject);

            // Increase the number of apples
            apples++;

            // Update the Slider value
            appleSlider.value = apples;
        }

        if (other.gameObject.CompareTag("book"))
        {
            Destroy(other.gameObject);
            books++;
            bookSlider.value = books;
        }
    }
}