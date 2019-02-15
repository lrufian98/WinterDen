using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorIterfaz : MonoBehaviour
{

    public Animator animMenuMenus;
    public Animator animMenuAjustes;

    bool activaMenuAjustes = false;
    bool activaMenuMenus = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ApareceMenuMenus()
    {
        activaMenuMenus = !activaMenuMenus;
        animMenuMenus.SetBool("MenuActivo", activaMenuMenus);
    }

    public void ApareceMenuAjustes()
    {
        activaMenuAjustes = !activaMenuAjustes;
        animMenuAjustes.SetBool("MenuActivo", activaMenuAjustes);
    }

}
