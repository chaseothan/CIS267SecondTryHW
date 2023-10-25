using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPowerUp : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Clear"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
