using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class NetworkedLandmine : MonoBehaviourPun
{
    public string tag = "HandTag";
    public float explosionForce;
    public float rigidbodyDetectRadius;
    public float upwardsModifier = 0.5f;
    [Space(5f)]
    public float respawnTime;
    public bool respawn;

    [Space(15f)]
    public GameObject explodeVFX;
    public float vfxDieTime;

    [Header("Gizmo Stuff")]
    public bool gizmos;
    public Color radiusCol;

    private Renderer rend;
    private Collider col;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        rend = transform.GetComponent<Renderer>();
        col = transform.GetComponent<Collider>();
        active = true;
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if (active && other.CompareTag(tag))
        {
            photonView.RPC(nameof(startExplode), RpcTarget.All);
        }
    }

    [PunRPC]
    void startExplode()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        rend.enabled = false;
        col.enabled = false;

        if(explodeVFX)
        {
            GameObject o = Instantiate(explodeVFX, transform.position, transform.rotation);
            Destroy(o, vfxDieTime);
        }

        Collider[] c = Physics.OverlapSphere(transform.position, rigidbodyDetectRadius);
        foreach (Collider n in c)
        {
            Rigidbody rbb = n.attachedRigidbody;
            if (rbb)
            {
                rbb.AddExplosionForce(explosionForce, transform.position, rigidbodyDetectRadius, upwardsModifier, ForceMode.Impulse);
            }
        }

        if(respawn)
        {
            yield return new WaitForSeconds(respawnTime);
            rend.enabled = true;
            col.enabled = true;
            active = true;
        }

        yield return null;
    }

    void OnDrawGizmosSelected()
    {
        if (gizmos)
        {
            Gizmos.color = radiusCol;
            Gizmos.DrawWireSphere(transform.position, rigidbodyDetectRadius);
        }
    }
}
