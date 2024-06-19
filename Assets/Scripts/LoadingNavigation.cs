using UnityEngine;

public class LoadingNavigation : MonoBehaviour
{
    public UniWebView uni;

    public void Back()
    {
        if(uni.CanGoBack)
        {
            uni.GoBack();
        }    
    }

    public void GoForward()
    {
        if(uni.CanGoForward)
        {
            uni.GoForward();
        }
    }
}
