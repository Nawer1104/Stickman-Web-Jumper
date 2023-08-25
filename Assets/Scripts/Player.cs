using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject vfxOnKill;
    public GameObject vfxOnDead;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            GameObject vfx = Instantiate(vfxOnKill, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(vfx, 1f);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].enemies.Remove(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "wall")
        {
            ReSetPos();
        }
    }


    public void ReSetPos()
    {
        transform.position = startPos;
        GameObject vfx = Instantiate(vfxOnDead, transform.position, Quaternion.identity);
        Destroy(vfx, 1f);

    }
}
