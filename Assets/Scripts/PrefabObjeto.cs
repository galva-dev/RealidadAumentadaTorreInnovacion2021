using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabObjeto : MonoBehaviour
{
    public GameObject[] ventanasEmerg;
    public GameObject[] cerrarVentanasEmerg;
    public GameObject[] objetos;
    public GameObject text;

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform!=null)
                {
                    Rigidbody rb;
                    if (rb = hit.transform.GetComponent<Rigidbody>())
                    {
                        //--------------------------------------------------------------------------------CUBE
                        if (hit.transform.gameObject.name == "Cube")
                        {
                            hit.transform.GetComponent<Animator>().Play("cube_animation");
                            ventanasEmerg[0].SetActive(true);
                        }
                        if (hit.transform.gameObject.name == "cerrarCube")
                        {
                            objetos[0].GetComponent<Animator>().Play("none");
                            ventanasEmerg[0].SetActive(false);
                        }
                        //--------------------------------------------------------------------------------CILINDRO
                        if (hit.transform.gameObject.name == "Cilindro")
                        {
                            hit.transform.GetComponent<Animator>().Play("cilindro_animation");
                            ventanasEmerg[1].SetActive(true);
                        }
                        if (hit.transform.gameObject.name == "cerrarCilindro")
                        {
                            objetos[1].GetComponent<Animator>().Play("none");
                            ventanasEmerg[1].SetActive(false);
                        }
                        text.GetComponent<TextMesh>().text = hit.transform.gameObject.name;
                    }
                }
            }
        }
    }

    public string GetName(GameObject obj)
    {
        return obj.name;
    }

    public void LaunchIntoAir(Rigidbody rig)
    {
        rig.AddForce(rig.transform.up * 10, ForceMode.Impulse);
    }
}
