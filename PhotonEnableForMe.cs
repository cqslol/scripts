using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonEnableForMe : MonoBehaviour
{ 

    public PhotonView PhotonView;
    public GameObject Cosmetic;
    public bool setActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonView.IsMine)
        { 
            Cosmetic.SetActive(setActive);
        }
        else
        {
            Cosmetic.SetActive(!setActive);
        }
    }
}
