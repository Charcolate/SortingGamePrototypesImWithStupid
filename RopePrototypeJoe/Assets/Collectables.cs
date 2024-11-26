using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public List<Sprite> colors;
    public SpriteRenderer spriteRenderer;

    private float moveSpeed; // Speed at which the collectable moves

    public int type;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetImages();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the collectable to the right
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    public void Initialize(float speed)
    {
        moveSpeed = speed;
    }


    void SetImages()
    {
        //def need a bag randomizer
        int index = Random.Range(0, colors.Count);
        spriteRenderer.sprite = colors[index];
        type = index;
    }
}
