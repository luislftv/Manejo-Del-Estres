using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialView : MonoBehaviour
{
    [SerializeField] private CreditView _creditView;
    [SerializeField] private InteractiveBtn _continue;
    public GameObject fp;
    public GameObject sp;
    

    private void Start()
    {
        _continue.ConfigureOnClickXR(ContinueButton);
    }

    private void ContinueButton()
    {
        gameObject.SetActive(false);
        _creditView.gameObject.SetActive(false);

        
       
    }
    void Update()
    {
        Debug.Log(Camera.main.transform.rotation.y);
         if (Camera.main.transform.rotation.y>0.45f&&Camera.main.transform.rotation.y<0.99f)
        {
            sp.SetActive(true);
            fp.SetActive(false);
        }
        else{ 
            fp.SetActive(true);
            sp.SetActive(false);}
    }

}
