using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleLift : MonoBehaviour
{   
    [SerializeField] private float liftForce = 1f;
    private Transform ballTransform;
    private bool isTriggered = false;

    private void Update() {
        if(isTriggered)
        {
            transform.Translate(liftForce * Time.deltaTime * Vector2.up);
            if (ballTransform != null)
            {
                ballTransform.position = transform.position;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ball"))
        {
            ballTransform = other.transform;
            isTriggered = true;
        }

        if (other.CompareTag("frog")){
            SceneManager.LoadScene("Level1");
        }
        
    }



    
}
