using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour {

    public GameObject UILogin;
    public GameObject UILoading;
    public GameObject UITips;
    public Slider Slider;
    public Text progressNumber;

    IEnumerator Start () {
        log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log4net.xml"));
        UnityLogger.Init();
        Common.Log.Init("Unity");
        Common.Log.Info("LoadingManager start");
        UITips.SetActive(true);
        UILoading.SetActive(false);
        UILogin.SetActive(false);

        yield return new WaitForSeconds(2f);
        UILoading.SetActive(true);
        yield return new WaitForSeconds(1f);
        UITips.SetActive(false);

        for (float i = 0; i < 1;)
        {
            i += Random.Range(0.05f, 0.08f);
            Slider.value = i;
            progressNumber.text = Mathf.Ceil(i*100) + "%";
            yield return new WaitForEndOfFrame();
        }

        UILoading.SetActive(false);
        UILogin.SetActive(true);
        yield return null;
    }
	
	void Update () {
		
	}
    
}
