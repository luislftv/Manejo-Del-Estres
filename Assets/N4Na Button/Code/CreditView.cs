using UnityEngine;

public class CreditView : MonoBehaviour
{
    private const string NANADIGITAL = "https://app.n4nadigital.com/";

    [SerializeField] private InteractiveBtn _nanaBtn;
    [SerializeField] private InteractiveBtn _creditsBtn;
    [SerializeField] private InteractiveBtn _backBtn;
    [SerializeField] private InteractiveBtn _exitButton;

    [SerializeField] private GameObject _credits;


    private void Start()
    {
        _credits.SetActive(false);

        _nanaBtn.ConfigureOnClickXR(OpenURL);
        _creditsBtn.ConfigureOnClickXR(ShowCredits);
        _backBtn.ConfigureOnClickXR(HideCredits);

        if(_exitButton != null)
        _exitButton.ConfigureOnClickXR(ExitApp);
    }

    public void OpenURL()
    {
        Application.OpenURL(NANADIGITAL);
    }
    public void ExitApp()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        _credits.SetActive(true);

        _nanaBtn.gameObject.SetActive(false);
        _creditsBtn.gameObject.SetActive(false);
    }

    public void HideCredits()
    {
        _credits.SetActive(false);

        _nanaBtn.gameObject.SetActive(true);
        _creditsBtn.gameObject.SetActive(true);
    }
}
