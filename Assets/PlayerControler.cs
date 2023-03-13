using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public GameObject BulletPrefab;
    private Transform gunLeft;
    public float acceleration = 10;
    private Rigidbody rb;
    private Vector2 controls;
    private bool firebuttondown = false;
    private Wyjazd cs;

    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        gunLeft = transform.Find("gunLeft");
        cs = Camera.main.GetComponent<Wyjazd>();
    }

    // Update is called once per frame
    void Update()
    {
        float v, h;
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        controls = new Vector2(h, v);
        
        float maxHorizontal = cs.worldWidth / 2;
        float maxVertical = cs.worldHeight / 2;
        
         
        

        if (Mathf.Abs(transform.position.x) > maxHorizontal) 
        {
            Vector3 newPosition = new Vector3(transform.position.x * -0.95f,
                                               0,
                                               transform.position.z);
            transform.position = newPosition;
        }
        if (Mathf.Abs(transform.position.z) > maxVertical)
        {
            Vector3 newPosition = new Vector3(transform.position.x,
                                              0,
                                              transform.position.z * -0.95f);
            transform.position = newPosition;
        }
            if (Input.GetKeyDown(KeyCode.Space)) { 
        firebuttondown= true;
            
        }
    }
    private void FixedUpdate()
    {

        rb.AddForce(transform.forward * controls.y * acceleration, ForceMode.Acceleration);
        rb.AddTorque(transform.up * controls.x * acceleration, ForceMode.Acceleration);


        if (firebuttondown) {
            GameObject Bullet = Instantiate(BulletPrefab, gunLeft.position, Quaternion.identity);
            Bullet.transform.parent = null;
            Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10,
                                                        ForceMode.VelocityChange);
            firebuttondown = false;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
            GameObject other = collision.gameObject;
            if (other.CompareTag("Enemy")) 
            {
            SceneManager.LoadScene("MainMenu");
            }
}
}
