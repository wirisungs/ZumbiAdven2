
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private PlayerLife playerLife;
    private UI2Manager uI2Manager;

    private void Awake()
    {
        playerLife = GetComponent<PlayerLife>();
        uI2Manager = FindObjectOfType<UI2Manager>();
    }

    public void CheckRespawn()
    {
        if(currentCheckpoint == null)
        {
            //Show game over screen
            uI2Manager.GameOver();
            return;
        }


        transform.position = currentCheckpoint.position;
        playerLife.Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SFXManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
