using UnityEngine;

public class Boxed : MonoBehaviour
{
    private float _halfScreenSizeInX;
    private float _halfScreenSizeInY;

    private float _halfPlayerWidthInX;
    private float _halfPlayerWidthInY;

    void Start()
    {
        CalculateBoxingLimits();
        SubscribeToPlayerEvents();
    }

    void FixedUpdate()
    {
        if (transform.position.x < -_halfScreenSizeInX)
        {
            transform.position = new Vector2(-_halfScreenSizeInX, transform.position.y);
        }

        if (transform.position.x > _halfScreenSizeInX)
        {
            transform.position = new Vector2(_halfScreenSizeInX, transform.position.y);
        }

        if (transform.position.y < -_halfScreenSizeInY)
        {
            transform.position = new Vector2(transform.position.x, -_halfScreenSizeInY);
        }

        if (transform.position.y > _halfScreenSizeInY)
        {
            transform.position = new Vector2(transform.position.x, _halfScreenSizeInY);
        }
    }

    void OnDestroy()
    {
        UnsubscribeToPlayerEvents();
    }

    public void CalculateBoxingLimits()
    {
        _halfPlayerWidthInX = transform.localScale.x / 2f;
        _halfPlayerWidthInY = transform.localScale.y / 2f;

        _halfScreenSizeInX = CalculateHalfScreen(_halfPlayerWidthInX, Axis.X);
        _halfScreenSizeInY = CalculateHalfScreen(_halfPlayerWidthInY, Axis.Y);
    }

    private float CalculateHalfScreen(float halfPlayerSize, Axis axis)
    {
        if (axis == Axis.X)
        {
            return Camera.main.aspect * Camera.main.orthographicSize - halfPlayerSize;
        }

        return Camera.main.orthographicSize - halfPlayerSize;
    }

    private void SubscribeToPlayerEvents()
    {
        var playerObject = FindObjectOfType<Player>();

        if (playerObject != null)
        {
            playerObject.OnGrowth += CalculateBoxingLimits;
        }
    }

    private void UnsubscribeToPlayerEvents()
    {
        var playerObject = FindObjectOfType<Player>();

        if (playerObject != null)
        {
            playerObject.OnGrowth -= CalculateBoxingLimits;
        }
    }

    private enum Axis
    {
        X,
        Y
    }
}
