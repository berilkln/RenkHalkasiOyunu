using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{

    public Transform topunT;

    private void LateUpdate() // ekranın yarısı geçince takip edilsin
    {
        if(topunT.position.y > transform.position.y) //top kameranın y'sini geçerse
        {
            transform.position = new Vector3(transform.position.x, topunT.position.y, transform.position.z); //kameranın pozisyonunu yeniden ayarla.
        }
        
    }







}//class
