using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour
{
    public GameObject AICamera;
    public GameObject kursuCamera;
    public GameObject MyCamera;
    public GameObject zarf;
    public GameObject Atom;
    public GameObject zarfobje;

    public bool OyCalındı = false;

    public int mySkor;
    public int EnemySkor;
    

    public Text myText;
    public Text EnemyText;


    public AudioSource ses;


    void Update()
    {

        if (Input.GetKey(KeyCode.Space)) {
			AICamera.SetActive(true);
            MyCamera.SetActive(false);
		}
        else
        {
            AICamera.SetActive(false);
            MyCamera.SetActive(true);
        }
    }

    private void Start()
    {
     //   ses = GetComponent<AudioSource>();
        EnemyText.text ="Rakibin oyu = " + EnemySkor.ToString();
        myText.text ="Oyunuz = "+ mySkor.ToString();
        
    }


   

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag=="rakipoy")
        {
            
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                if (OyCalındı==false)
                {
                    Debug.Log("rakipten 1 oy eksildi.");
                    EnemySkor--;
                    EnemyText.text ="Rakibin oyu = " + EnemySkor.ToString();
                    OyCalındı=true;
                    zarf.SetActive(true);
                }
                else
                {
                    Debug.Log("lütfen elinizdeki zarfı kutunuza atınız.");
                }
                
		    }
        }
        if (col.gameObject.tag=="myoy")
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (OyCalındı==true)
                {
                    Debug.Log("Oyumuz 1 arttı.");
                    mySkor++;
                    myText.text ="Oyunuz = "+ mySkor.ToString();
                    OyCalındı=false;
                    zarf.SetActive(false);
                }
                else
                {
                    Debug.Log("lütfen Rakibinizden oy çalın.");
                }
                
		    }
        }

        
        if (col.gameObject.tag=="Atom")
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                mySkor += 3;
                myText.text ="Oyunuz = "+ mySkor.ToString();
                Atom.SetActive(true);
                StartCoroutine(atomText());
                zarfobje.SetActive(false);
            }
        }



        if (col.gameObject.tag=="kursu")
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                kursuCamera.SetActive(true);
                MyCamera.SetActive(false);
                ses.Play ();
                mySkor += 2;
                myText.text ="Oyunuz = "+ mySkor.ToString();
                StartCoroutine(kursufunction());

            }
            
                
                
            
        }
    }

    public IEnumerator atomText()
    {
        yield return new WaitForSeconds(2);
        Atom.SetActive(false);
        
    }

    public IEnumerator kursufunction()
    {
        yield return new WaitForSeconds(5);
        kursuCamera.SetActive(false);
        MyCamera.SetActive(true);
        ses.Stop ();
        
    }

}
