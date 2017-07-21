using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningManager : MonoBehaviour {

    public delegate void delegateFunction();
    public delegateFunction PostiveCall;
    public delegateFunction NegativeCall;

    public Text warningText;
    public Text postiveText;
    public Text negativeText;

     

    public void InitWarningMsg(string postiveButtonText, string negativeButtonText, string warningMsg) {
        if (warningMsg != null)
            warningText.text = warningMsg;
        if (postiveButtonText != null)
            postiveText.text = postiveButtonText;
        if (negativeButtonText != null)
            negativeText.text = negativeButtonText;
    }

    public void Postive() {
        if (PostiveCall != null) {
            PostiveCall();
        }
        CloseWarning();
    }

    public void Negative() {
        if (NegativeCall != null) {
            NegativeCall();
        }
        CloseWarning();
    }

    private void CloseWarning() {
        gameObject.SetActive(false);
    }
}
