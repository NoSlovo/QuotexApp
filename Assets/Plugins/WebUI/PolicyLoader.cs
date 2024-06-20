using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PolicyLoader : MonoBehaviour
{
  [SerializeField]
    private UniWebView webBrowser;
    [SerializeField]
    private string policyUrl;
    [SerializeField]
    private GameObject noConnectionUI;
    [SerializeField]
    private GameObject loadingIndicatorUI;
    [SerializeField]
    private GameObject policyBgUI, alternateBgUI;

    private bool isPolicyPageLoaded = false;

    private void Start()
    {
        ConfigureScreenOrientation();
        CheckInternetOnStart();
    }

    private void ConfigureScreenOrientation()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void CheckInternetOnStart()
    {
        if (IsInternetUnavailable())
        {
            DisplayNoInternetUI();
        }
        else
        {
            ProceedWithPolicyCheck();
        }
    }

    private bool IsInternetUnavailable()
    {
        return Application.internetReachability == NetworkReachability.NotReachable;
    }

    private void DisplayNoInternetUI()
    {
        loadingIndicatorUI.SetActive(false);
        noConnectionUI.SetActive(true);
    }

    private IEnumerator TryReconnectAndProceed()
    {
        while (IsInternetUnavailable())
        {
            DisplayNoInternetUI();
            yield return new WaitForSeconds(5f);
        }

        LoadPolicyPage();
    }

    private void LoadPolicyPage()
    {
        noConnectionUI.SetActive(false);
        loadingIndicatorUI.SetActive(true);
        StartPolicyPageLoading();
    }

    private void StartPolicyPageLoading()
    {
        webBrowser.OnPageFinished += OnPolicyPageLoadComplete;
        webBrowser.Load(policyUrl);
    }

    private void OnPolicyPageLoadComplete(UniWebView webBrowser, int statusCode, string currentUrl)
    {
        if (isPolicyPageLoaded) return;

        UpdateUIForPolicyPage(currentUrl);
        webBrowser.Show();

        if (policyUrl != currentUrl)
        {
            Destroy(this.gameObject);
        }

        isPolicyPageLoaded = true;
        loadingIndicatorUI.SetActive(false);  // Hide loading indicator when the page is loaded
    }

    private void UpdateUIForPolicyPage(string currentUrl)
    {
        bool isPolicyPage = currentUrl == policyUrl;
        policyBgUI.SetActive(isPolicyPage);
        alternateBgUI.SetActive(!isPolicyPage);
        Screen.orientation = isPolicyPage ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyConfirmation", isPolicyPage ? "Accepted" : currentUrl);
    }

    public void OnUserPolicyConfirmation()
    {
        ProceedWithPolicyCheck();
    }

    private void ProceedWithPolicyCheck()
    {
        string confirmationStatus = PlayerPrefs.GetString("PolicyConfirmation", "");
        if (string.IsNullOrEmpty(confirmationStatus))
        {
            StartCoroutine(TryReconnectAndProceed());
        }
        else if (confirmationStatus == "Accepted")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            ShowPreviouslyLoadedPolicyPage(confirmationStatus);
        }
    }

    private void ShowPreviouslyLoadedPolicyPage(string url)
    {
        webBrowser.Load(url);
        webBrowser.Show();
        alternateBgUI.SetActive(true);
    }

    // Additional method for manual retry if needed
    public void RetryLoadingPolicy()
    {
        CheckInternetOnStart();
    }
}
