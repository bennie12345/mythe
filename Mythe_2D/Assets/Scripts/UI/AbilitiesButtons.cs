using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesButtons : MonoBehaviour {

    public delegate void UseSwordAction();
    public static event UseSwordAction OnUseSword;

    public delegate void UseLaserAction();
    public static event UseLaserAction OnUseLaser;

    public delegate void UseMedusaAction();
    public static event UseMedusaAction OnUseMedusa;

    public void UseSword()
    {
        if (OnUseSword != null)
        {
            OnUseSword();
        }
    }

    public void UseLaser()
    {
        if (OnUseLaser != null)
        {
            OnUseLaser();
        }  
    }

    public void UseMedusa()
    {
        if (OnUseMedusa != null)
        {
            OnUseMedusa();
        }
    }
}
