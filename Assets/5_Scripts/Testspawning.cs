using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class Testspawning : MonoBehaviour
{
    public int count = 0;
    [System.Serializable]
    public class enemy
    {
       // public float hp;
        //public float dmg;
        public GameObject prefab;
        //public float speed;
        public int id;
        public enemy(GameObject prefab, int id)
        {
            this.prefab = prefab;
           // this.dmg = dmg;
           // this.hp = hp;
           // this.speed = speed;
            this.id = id;
        }

        
        public void Die(int count)
        {
            count++;
        }

    }
    [System.Serializable]
    public class enemygroup
    {
        public enemy enemytype;
        public int amount;
        public int id;
        public int enemyid;
       // public List<enemy> ;
        
        public enemygroup( int id)
        {
            
            this.id = id;
        }
    }
    [System.Serializable]
    public class EnemyList
    {
        public List<enemy> enemies = new List<enemy>();
    }
    [System.Serializable]

    public class waves
    {
        public List<enemygroup> enemygroups;
        public int id;
        public waves(List<enemygroup> enemygroups, int id)
        {
            this.enemygroups = enemygroups;
            this.id = id;
        }
    }

    public List<EnemyList> allEnemies = new List<EnemyList>();
    public waves[] waverus;
    bool waveGoingOn = true;
    float x = 0;
    public float waittime;
    //List<List<enemy>> reeeeee[0] = enem;

    public void Spawnwave(waves wave)
    {
        foreach (enemygroup enemygroup in wave.enemygroups)
        {
            for (int i = 0; i <= enemygroup.amount ;i++)
            {
                enemygroup.enemytype = allEnemies[enemygroup.enemyid].enemies[0];
                enemy obj = enemygroup.enemytype;
                StartCoroutine(SpawnEnemie(i, allEnemies[enemygroup.enemytype.id].enemies.Count, obj, 0, allEnemies[enemygroup.enemyid]));
                
                //if (i >= allEnemies[enemygroup.enemytype.id].enemies.Count)
                //{
                //    enemy obj = enemygroup.enemytype;
                //    Debug.Log(obj);
                //    var r = Instantiate(obj.prefab);
                //    enemy ree = new enemy(r, obj.id);
                //    //enemygroup.enemies.Add()
                //}
                ////;

                //else
                //{
                //    Debug.Log("how the fuck did you get here?");
                //}

            }

        }
    }
    bool notinstance = true;
    IEnumerator SpawnEnemie(int i, int lisstleng, enemy obj,float waitTime,EnemyList list)
    {
        yield return new WaitForSeconds(waitTime);
        if (i > lisstleng)
                {
                    
            var r = Instantiate(obj.prefab);
            enemy ree = new enemy(r, obj.id);
            list.enemies.Add(ree);
            ree.prefab.SetActive(false);
            if (lisstleng == 1 && i == 1 && notinstance)
            {
                r = Instantiate(obj.prefab);
                ree = new enemy(r, obj.id);
                list.enemies[0] = ree;
                //r = Instantiate(obj.prefab);
                //ree = new enemy(r, obj.id);
                //list.enemies.Add(ree);
                ree.prefab.SetActive(false);
                //notinstance = false;
            }
                }
                //;

         
        StopCoroutine("SpawnEnemie");
    }

    IEnumerator Wait(float  waitTime)
    {
        yield return new WaitForSeconds (waitTime);
    }

    private void Start()
    {
        foreach (waves wave in waverus)
        {
            Spawnwave(wave);


      }
    }
}

    // Update is called once per frame
    



