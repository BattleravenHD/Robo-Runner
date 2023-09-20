using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Gen : MonoBehaviour {

    public List<GameObject> Shapes = new List<GameObject>();
    public GameObject Player;
    public bool Is_up;
    public bool Is_Main;
    public List<Vector2> points = new List<Vector2>();

    private Vector2 pos;
    private GameObject Main;
    private bool spawned = true;

    private void Start()
    {
        pos = GetComponentInParent<Transform>().position;
        Main = GameObject.FindGameObjectWithTag("Main");
        Generatenew();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(update());
    }

    IEnumerator update()
    {
        yield return new WaitForSeconds(1.5f);

        if (Is_Main == true)
        {
            while (points.Count > 15)
            {
                points.RemoveAt(0);
                Destroy(transform.GetChild(0).gameObject);
            }
        }
        if (Is_Main == false)
        {
            points.Clear();
            points.AddRange(Main.GetComponent<Level_Gen>().points);
        }
        StartCoroutine(update());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var rando = Random.Range(0, Shapes.Count);
            if (Is_up == true)
            {
                if (spawned == true)
                    spawned = false;
                Instantiate(Shapes[rando], new Vector2(Mathf.RoundToInt(pos.x - 10), Mathf.RoundToInt(pos.y + 25)), Quaternion.identity, Main.transform).name = GetInstanceID().ToString(); 
                points.Add(new Vector2(Mathf.RoundToInt(pos.x - 14), Mathf.RoundToInt(pos.y + 25)));
                Main.GetComponent<Level_Gen>().points.Add(new Vector2(Mathf.RoundToInt(pos.x - 14), Mathf.RoundToInt(pos.y + 25)));
                foreach (Vector2 point in points)
                {
                    if (point.x == Mathf.RoundToInt(pos.x - 10) && point.y == Mathf.RoundToInt(pos.y + 5))
                    {
                        return;
                    }  
                }
                rando = Random.Range(0, Shapes.Count);
                Instantiate(Shapes[rando], new Vector2(Mathf.RoundToInt(pos.x - 10), Mathf.RoundToInt(pos.y + 5)), Quaternion.identity, Main.transform).name = GetInstanceID().ToString();
                points.Add(new Vector2(Mathf.RoundToInt(pos.x - 10), Mathf.RoundToInt(pos.y + 5)));
                Main.GetComponent<Level_Gen>().points.Add(new Vector2(Mathf.RoundToInt(pos.x - 10), Mathf.RoundToInt(pos.y + 5)));
            }
            else
            {
                if (spawned == true)
                    spawned = false;
                Instantiate(Shapes[rando], new Vector2(Mathf.RoundToInt(pos.x + 25), Mathf.RoundToInt(pos.y - 10)), Quaternion.identity, Main.transform).name = GetInstanceID().ToString(); 
                points.Add(new Vector2(Mathf.RoundToInt(pos.x + 25), Mathf.RoundToInt(pos.y - 10)));
                Main.GetComponent<Level_Gen>().points.Add(new Vector2(Mathf.RoundToInt(pos.x + 25), Mathf.RoundToInt(pos.y - 10)));
                foreach (Vector2 point in points)
                {
                    if (point.x == Mathf.RoundToInt(pos.x + 5) && point.y == Mathf.RoundToInt(pos.y - 10))
                    {
                        return;
                    }
                }
                rando = Random.Range(0, Shapes.Count);
                Instantiate(Shapes[rando], new Vector2(Mathf.RoundToInt(pos.x + 5), Mathf.RoundToInt(pos.y - 10)), Quaternion.identity, Main.transform).name = GetInstanceID().ToString(); 
                points.Add(new Vector2(Mathf.RoundToInt(pos.x + 5), Mathf.RoundToInt(pos.y - 10)));
                Main.GetComponent<Level_Gen>().points.Add(new Vector2(Mathf.RoundToInt(pos.x + 5), Mathf.RoundToInt(pos.y - 10)));
            }
        }
    }
    public void Generatenew()
    {
        if (Is_Main == true)
        {
            for(int i = 0; i < transform.childCount; ++i)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            points.Clear();
            var rando = Random.Range(0, Shapes.Count);
            Instantiate(Shapes[rando], transform.position, Quaternion.identity , Main.transform).name = GetInstanceID().ToString();
            points.Add(new Vector2(0,0));
            rando = Random.Range(0, Shapes.Count);
            Instantiate(Shapes[rando], new Vector2(transform.position.x + 20, transform.position.y), Quaternion.identity, Main.transform).name = GetInstanceID().ToString();
            points.Add(new Vector2(20, 0));
            rando = Random.Range(0, Shapes.Count);
            Instantiate(Shapes[rando], new Vector2(transform.position.x, transform.position.y + 20), Quaternion.identity, Main.transform).name = GetInstanceID().ToString();
            points.Add(new Vector2(0, 20));
            rando = Random.Range(0, Shapes.Count);
            Instantiate(Shapes[rando], new Vector2(transform.position.x + 20, transform.position.y + 20), Quaternion.identity, Main.transform).name = GetInstanceID().ToString();
            points.Add(new Vector2(20, 20));
            
        }
        if (Is_Main == false)
        {
            points.Clear();
            points.AddRange( Main.GetComponent<Level_Gen>().points);
        }
    }
}
