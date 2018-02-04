using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 7;
    public float BoostMultiplier = 2;

    public Action OnGrowth;

    void FixedUpdate()
    {
        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        Vector2 velocity;

        if (IsBoostButtonPressed())
        {
            velocity = direction * (Speed * BoostMultiplier);
        }
        else
        {
            velocity = direction * Speed;
        }

        transform.Translate(velocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var playerScale = transform.localScale.x;
        var enemyScale = collider.gameObject.transform.localScale.x;

        if (playerScale > enemyScale)
        {
            Destroy(collider.gameObject);

            transform.localScale += CalculateGrowthVector(enemyScale);

            if (OnGrowth != null)
            {
                OnGrowth();
            }
        }
        else
        {
            Destroy(gameObject);
            collider.gameObject.transform.localScale += CalculateGrowthVector(playerScale);
        }
    }

    Vector3 CalculateGrowthVector(float scale)
    {
        var growthMultiplier = 0.25f;
        return new Vector3(scale * growthMultiplier, scale * growthMultiplier);
    }

    bool IsBoostButtonPressed()
    {
        return Input.GetButton("space");
    }
}
