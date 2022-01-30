using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BoostManager : MonoBehaviour {

    Rigidbody m_body;
    HoverCarControl hcc;
    public float m_boostGauge = 0;
    float timer = 5f;
    bool m_usingBoost;
    bool m_hasBoost;

    public TextMeshProUGUI m_boostGaugeText;


	// Use this for initialization
	void Start () {
        m_body = GetComponent<Rigidbody>();
        hcc = GetComponent<HoverCarControl>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            AddBoost();
            StartCoroutine(ReactivateBoost(other));

        }
    }

    IEnumerator ReactivateBoost(Collider other)
    {
        yield return new WaitForSeconds(timer);
        other.gameObject.SetActive(true);
    }
    
    public void UseBoost(bool toggle)
    {
        m_usingBoost = toggle;
    }

    void DecreaseBoost()
    {

        if (m_usingBoost)
        {
            m_boostGauge -= 1;
        }

        if (m_boostGauge < 0)
        {
            m_boostGauge = 0;
            m_hasBoost = false;
        }
    }

    void AddBoost()
    {
        m_boostGauge += 100;
        m_hasBoost = true;

        if (m_boostGauge >= 100)
        {
            m_boostGauge = 100;
        }
    }

    // Update is called once per frame
    void Update ()
    {
         //Debug.Log(timer);
         timer = Time.time;
         

        hcc.m_boost = m_usingBoost && m_hasBoost ? 5 : 1;
        DecreaseBoost();

        m_boostGaugeText.text = m_boostGauge.ToString();

    }
}
