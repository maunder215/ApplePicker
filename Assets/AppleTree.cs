using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject branchPrefab;

    // speed at which the AppleTree moves
    public float speed = 30f; 

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 24f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.02f;

    // Seconds between Apples instantiations
    public static float appleDropDelay = 0.75f;
    public static float BranchDropDelay = appleDropDelay*8;


    // Start is called before the first frame update
    void Start()
    {
        // Star dropping apples         // b
        Invoke( "DropApple", 2f );
        Invoke( "DropBranch", 2f );
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke( "DropApple", appleDropDelay);
    }

    void DropBranch() {
        GameObject branch = Instantiate<GameObject>(branchPrefab);
        branch.transform.position = transform.position;
        Invoke( "DropBranch", BranchDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement               // b
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction           // b
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs( speed );
        } else if  (pos.x > leftAndRightEdge ) {
            speed = -Mathf.Abs( speed );
        } 
        
    }


    void FixedUpdate() {
        // Random direction changes are now time-based due to the FixedUpdate()
        if ( Random.value < changeDirChance ) {
            speed *= -1;
        }
    }
}

