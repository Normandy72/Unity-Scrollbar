using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollbar;
    private float scrollPosition = 0;
    private float[] positions;

    private void Update()
    {
        // array size = number of content's children
        positions = new float[transform.childCount];

        // swipe distance
        float distance = 1f / (positions.Length - 1f);

        for(int i = 0; i < positions.Length; i++)
        {
            positions[i] = distance * i;
        }

        // if left mouse button was pressed
        if(Input.GetMouseButton(0))
        {
            scrollPosition = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int i = 0; i < positions.Length; i++)
            {
                if(scrollPosition < positions[i] + (distance / 2) && scrollPosition > positions[i] - (distance / 2))
                {
                    // Mathf.Lerp - Linearly interpolates between a and b by t.
                    // The parameter t is clamped to the range [0, 1].
                    // When t = 0 returns a. When t = 1 return b. When t = 0.5 returns the midpoint of a and b.
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, positions[i], 0.1f);
                }
            }
        }

        for(int i = 0; i < positions.Length; i++)
            {
                if(scrollPosition < positions[i] + (distance / 2) && scrollPosition > positions[i] - (distance / 2))
                {
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                    
                    // change buttons size
                    for(int a = 0; a < positions.Length; a++)
                    {
                        if(a != i)
                        {
                            transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        }
                    }
                }
            }
    }
}


