using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;


public class EnemyX : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Rigidbody enemyRb;

    [SerializeField]
    private GameObject playerGoal;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindWithTag("PlayerGoal");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        float3 lookDirection = math.normalize(playerGoal.transform.position - transform.position);
        Vector3 force = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z);
        enemyRb.AddForce(force * speed * Time.deltaTime, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
