using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjetoHorizontalmente : MonoBehaviour
{
    //este script mueve los objetos horizontales por el escenario
    public float speed = 1f;
    public float minX;
    public float maxX;

    private GameObject _target;
    //Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("moverHorizontalmente");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //esta funcion solo va a direccionar al enemigo, no lo va a mover
    private void UpdateTarget()
    {
        //si es la primera vez que se enta creamos el objetivo en el valor de X minimo
        if (_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            //Debug.Log("Entra");
            return;
        }

        //si ya estamos en la izquierda, cambiamos hacia la derecha
        if (_target.transform.position.x == minX)
        {
            _target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
            //Debug.Log("Entra2");
        }
        else if(_target.transform.position.x == maxX)
        {
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            //Debug.Log("Entra3");
        }

    }

    //corutina para mover el objeto
    private IEnumerator moverHorizontalmente()
    {        
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
            // let's move to the target
            Vector2 direction = _target.transform.position - transform.position;
            //float xDirection = direction.x;

            transform.Translate(direction.normalized * speed *Time.deltaTime);

            // IMPORTANT
            yield return null;
        }

        // At this point, i've reached the target, let's set our position to the target's one
        //Debug.Log("Target reached");
        //Debug.Log(_target.transform.position.x);
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        
        // And let's wait for a moment
        //Debug.Log("Waiting for " + waitingTime + " seconds");
        //yield return new WaitForSeconds(waitingTime); // IMPORTANT

        // once waited, let's restore the patrol behaviour
        //Debug.Log("Waited enough, let's update the target and move again");
        UpdateTarget();
        StartCoroutine("moverHorizontalmente");
    }
}