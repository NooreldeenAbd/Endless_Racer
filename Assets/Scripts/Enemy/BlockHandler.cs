using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    private float gravityScaleFactor = 50f;

    // Will increase fall down speed the longer you play
    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / gravityScaleFactor;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -13)
            Destroy(gameObject);
    }
}
