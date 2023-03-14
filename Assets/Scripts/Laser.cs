using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject Smoke;
    public Animator anim;
    public bool IsLaserActive = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        
        // Smoke.gameObject.transform.position = new Vector3(0, 0, 0);
        // Debug.Log(gameObject.name);
        Smoke.SetActive(false);
        Invoke("ActivePreviewlaser", 5);
    }

    public void DeactiveSmoke() {
        Smoke.SetActive(false);
    }

    public void ActivePreviewlaser() {
        Debug.Log("preview the laser");
        anim.SetInteger("int", 1);
        Invoke("DeActivePreviewlaser", 5);
    }

    public void DeActivePreviewlaser() {
        Debug.Log("de active the preview laser");
        anim.SetInteger("int", 2);
        ActiveLaser();
    }

    public void ActiveLaser() {
        Debug.Log("active the laser");
        IsLaserActive = true;
        anim.SetInteger("int", 5);
        Invoke("DeActiveLaser", 3);
    }

    public void DeActiveLaser()
    {
        anim.SetInteger("int", 4);
        IsLaserActive = false;
        Invoke("ActivePreviewlaser", 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsLaserActive)
        {
            Smoke.SetActive(true);
            Destroy(other.gameObject);
            Invoke("DeactiveSmoke", 1);
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
