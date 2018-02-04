using UnityEngine;

namespace Assets
{
    public class RandomSize : MonoBehaviour
    {
        public Vector2 RandomSizeMinMax = new Vector2(-0.5f, 0.5f);

        void Start()
        {
            var scale = Random.Range(RandomSizeMinMax.x, RandomSizeMinMax.y);

            transform.localScale = new Vector3(
                transform.localScale.x + scale, 
                transform.localScale.y + scale);
        }
    }
}
