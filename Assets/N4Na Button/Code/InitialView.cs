using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialView : MonoBehaviour
{
    [SerializeField] private CreditView _creditView;
    [SerializeField] private InteractiveBtn _continue;

    private void Start()
    {
        _continue.ConfigureOnClickXR(ContinueButton);
    }

    private void ContinueButton()
    {
        gameObject.SetActive(false);
        _creditView.gameObject.SetActive(false);
    }

}
