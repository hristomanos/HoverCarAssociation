using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public GameObject m_countDown;
    public AudioClip m_getReadyClip,m_GoClip;
    public AudioSource m_audioSource;
    public GameObject m_carControl;


    private void Start()
    {
        m_countDown.SetActive(false);
        StartCoroutine(CountStart());
    }


    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);

        CountdownCounter("3", m_getReadyClip);

        yield return new WaitForSeconds(1);

        CountdownCounter("2", m_getReadyClip);

        yield return new WaitForSeconds(1);

        CountdownCounter("1", m_getReadyClip);

        yield return new WaitForSeconds(1);

        CountdownCounter("Go!", m_GoClip);

        yield return new WaitForSeconds(0.5f);
        m_countDown.SetActive(false);
        m_carControl.SetActive(true);
    }

    void CountdownCounter(string val, AudioClip clip)
    {
        
        m_countDown.SetActive(true);
        m_countDown.GetComponent<Text>().text = val;
        m_audioSource.PlayOneShot(clip);
        StartCoroutine(CounterRotation());
    }

  
    IEnumerator CounterRotation()
    {
        float timer = 0;
        float axisRotation = 0;
        m_countDown.transform.localEulerAngles = Vector3.zero;
        while (timer < 1)
        {
            timer += Time.deltaTime;
            axisRotation = Mathf.Lerp(0, 90, timer);
            m_countDown.transform.localEulerAngles = new Vector3(axisRotation,0,0);
            yield return null;
        }
    }
}
