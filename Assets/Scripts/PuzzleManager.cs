using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D collider;
    private float deltaX;
    private float deltaY;
    private FixedJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        joint = GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePostion.x - deltaX, mousePostion.y - deltaY);
        var curPostion = transform.position;
        transform.position = new Vector2(Mathf.RoundToInt(curPostion.x), Mathf.RoundToInt(curPostion.y));
    }



}
