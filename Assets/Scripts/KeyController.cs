using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            animator.SetTrigger("keyPicked");
            SoundManager.Instance.Play(Sounds.KeyPickUp);
            Destroy(gameObject, 0.5f);
        }
    }
}
