using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_EnnemyTemplate;
    private float m_Timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;
        if(m_Timer > 2f){
            m_Timer -= 2f;
            SpawnEnnemy();
        }
    }
   public Vector3 RandomTransformPosition(){
       Vector3[] ennemyPosition = {
           new Vector3(-50,1,50), new Vector3(0,1,50),new Vector3(50,1,50),
           new Vector3(-50,1,0), new Vector3(50,1,0),
           new Vector3(-50,1,-50),new Vector3(0,1,-50),new Vector3(50,1,-50)
       };
       return ennemyPosition[Random.Range(0,ennemyPosition.Length)];
    }
    private void SpawnEnnemy(){
        Instantiate(m_EnnemyTemplate, RandomTransformPosition(),m_EnnemyTemplate.transform.rotation);
    }
}
