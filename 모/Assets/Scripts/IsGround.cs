using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    Move m;

    // Start is called before the first frame update
    void Start()
    {
        m = transform.parent.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        m.isJump += Time.deltaTime * 8;
        m.isJump = Mathf.Clamp(m.isJump, 0, 1);

        transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
