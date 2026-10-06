using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Yeeeeet : MonoBehaviour
{
    [Header("Script Made By BumBum Do Not Claim As Yours!!")]
    public string YeetTag;
    public Rigidbody GorillaPlayer;
    public PhotonView MyView;
    public float YeetForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(YeetTag))
        {
            if (MyView.IsMine)
            {
                return;
            }
            else
            {
                Vector3 direction = other.transform.position - transform.position;

                direction.Normalize();

                GorillaPlayer.AddForce(direction * YeetForce, ForceMode.Impulse);
            }
        }
    }
}
