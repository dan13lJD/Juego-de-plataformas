using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjetosVerticalmente : MonoBehaviour
{
    //este script movera los objetos verticales
    public float speed = 1f;
    public float minY;
    public float maxY;

    private GameObject _targetV;
    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("moverVerticalmente");
    }

    //esta funcion le va a dar direccion al objeto
    //mas no lo va a mover
    private void UpdateTarget(){
        //si es la primera vez que se mete creamos el objeto
        if (_targetV == null)
        {
            _targetV = new GameObject("TargetV");
            _targetV.transform.position = new Vector2(transform.position.x, minY);
            transform.localScale = new Vector3(1, -1, 1);
            return;
        }
        //si ya estamos arriba, cambiamos hacia abajo
        if (_targetV.transform.position.y == minY)
        {
            _targetV.transform.position = new Vector2(transform.position.x, maxY);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_targetV.transform.position.y == maxY)
        {
            _targetV.transform.position = new Vector2(transform.position.x, minY);
            transform.localScale = new Vector3(1, -1, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator moverVerticalmente()
    {
        while (Vector2.Distance(transform.position, _targetV.transform.position) > 0.05f)
        {
            // let's move to the target
            Vector2 direction = _targetV.transform.position - transform.position;
            float ydirection = direction.y;

            transform.Translate(direction.normalized * speed * Time.deltaTime);

            // important
            yield return null;
        }

        // at this point, i've reached the target, let's set our position to the target's one
        Debug.Log("target reached Y");        
        transform.position = new Vector2(transform.position.x, _targetV.transform.position.y);

        UpdateTarget();
        StartCoroutine("moverVerticalmente");
    }
}
