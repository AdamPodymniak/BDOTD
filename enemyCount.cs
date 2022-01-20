using UnityEngine;
using UnityEngine.SceneManagement;
public class enemyCount : MonoBehaviour
{
    public int enemiesCount = 0;
    
    public static enemyCount instance;
    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        if (enemiesCount <= 0)
        {
            
            



        }




    }
}
