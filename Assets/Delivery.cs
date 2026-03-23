using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour {
    
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float DestroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;
    bool hasPackage = false;
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("웁스!");
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");  
            hasPackage = true; 
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, DestroyDelay);
            
        }
        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("고객 물건 픽업 완료!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
         
    }
}
    
