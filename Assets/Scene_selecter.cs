using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Scene_selecter : MonoBehaviour
{
    public Button ThreePoint;
    public Button Park;
    public Button Lane;
    // Start is called before the first frame update
    void lane()
    {
        SceneManager.LoadScene("Lane_change");
    }
    void turn()
    {
        SceneManager.LoadScene("three_point_turn");
    }
    void park()
    {
        SceneManager.LoadScene("Parrallel_parking");
    }
    void Start()
    {
        
        ThreePoint.onClick.AddListener(turn);
        Park.onClick.AddListener(park);
        Lane.onClick.AddListener(lane);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
