using UnityEngine;

namespace Assets
{
    class FadeOutText : MonoBehaviour
    {
        public float fadeOutTimeInSecs = 1.0f;

        void Update()
        {
            if (Time.time > fadeOutTimeInSecs)
            {
                Destroy(gameObject);
                fadeOutTimeInSecs += Time.time;
            }
        }
    }
}
