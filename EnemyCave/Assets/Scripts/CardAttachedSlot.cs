using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAttachedSlot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hand")
            collision.gameObject.transform.SetParent(null);
    }
}
