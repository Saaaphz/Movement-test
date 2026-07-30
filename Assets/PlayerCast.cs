using UnityEngine;

public class PlayerCast : MonoBehaviour
{
    public float radius;
    public float maxDistance;
    public LayerMask layerMask;
    RaycastHit hit;

    

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            Cast();
        }
        
        
    }
   public void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawSphere(transform.position-transform.up*maxDistance,radius);
    }
    public void Cast()
    {
        if(Physics.SphereCast(transform.position,radius,-transform.up,out hit,maxDistance,~layerMask))
        {
            Debug.Log(hit.collider.gameObject);
        }
    }
}