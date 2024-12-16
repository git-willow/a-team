using Complete;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WormHole : MonoBehaviour
{
    private Dictionary<int, float> tanks = new Dictionary<int, float>();

    [SerializeField]
    private GameObject w_NextWarmHole;
    private float w_InvincibleTime = 10f;
    private float w_WarpTime = 3f;
    private float w_CoolTime = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            int tank_id = other.gameObject.GetInstanceID();
            if (tanks.ContainsKey(tank_id))
            {
                if (Time.time - tanks[tank_id] > w_CoolTime)
                {
                    StartCoroutine(WarpRoutine(other, tank_id));
                }
                else
                {
                    Debug.Log("Tanks can't warp!");
                }
            }
            else
            {
                StartCoroutine(WarpRoutine(other, tank_id));
            }
        }
        else
        {
            Debug.Log("This Object is not Tanks!");
        }
    }

    IEnumerator WarpRoutine(Collider coll, int id)
    {
        if (coll == null)
        {
            Debug.LogError("Collider is null.");
            yield break;
        }
        
        var tankHealth = coll.gameObject.GetComponent<Complete.TankHealth>();
        tankHealth.StartInvincible(w_InvincibleTime);
        yield return new WaitForSeconds(w_WarpTime);

        if (w_NextWarmHole != null)
        {
            coll.transform.position = w_NextWarmHole.transform.position;
            WormHole hole = w_NextWarmHole.GetComponent<WormHole>();
            if (tanks.ContainsKey(id))
            {
                tanks[id] = Time.time;
            }
            else
            {
                tanks.Add(id, Time.time);
            }
            if (hole.tanks.ContainsKey(id))
            {
                hole.tanks[id] = Time.time;
            }
            else
            {
                hole.tanks.Add(id, Time.time);
            }
        }
        else
        {
            Debug.LogError("w_NextWarmHole is not assigned.");
            yield break;
        }
    }
}
