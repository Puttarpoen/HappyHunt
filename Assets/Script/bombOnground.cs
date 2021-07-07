using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombOnground : MonoBehaviour
{
    Cannonss cannon = new Cannonss();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="ground")
        {
            BombOnGround();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void BombOnGround()
    {
        GameObject newG = Instantiate(cannon.boomb, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(newG, 2);
        GameObject newBombR = Instantiate(cannon.bombR, new Vector2(newG.transform.position.x, newG.transform.position.y), Quaternion.identity);
        Destroy(newBombR, 1);
    }
}
