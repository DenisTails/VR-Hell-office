using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] 
    public AudioSource collisionSound;

    [SerializeField] 
    public GameObject listController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hammer"))
        {
            collisionSound.Play();
            listController.GetComponent<ListController>().Revert();
        }
    }
}
