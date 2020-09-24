using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaver : MonoBehaviour
{
    public TestSave save;
    public long temptime = 0;
    string saveJS;
    public int heroID=1;
    public Hero heroTest;
    void Start()
    {
        temptime = GameManager._GLOBAL_TIME_;
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            HeroDataManager.Instance.addNewHeroToData(heroTest);
        }

    }


    public void changes()
    {
        if (GameManager._GLOBAL_TIME_ > temptime)
        {
            save.attack += 1;
            save.desc += "...HI";
            var TestItem = ScriptableObject.CreateInstance<TestItem>();
            TestItem.name = Random.Range(0, 10000).ToString();
            save.items.Add(TestItem);
            temptime++;
        }

        
    }

}
