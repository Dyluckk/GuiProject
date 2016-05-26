using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pistol : MonoBehaviour
{
    public int pistolAmmo;
    public int pistolClip;
    public GameObject gameStats;
    public bool clipEmpty;
    public Text AmmoText;


    void Start()
    {
        gameStats = GameObject.Find("currentGameStats");
        pistolAmmo = gameStats.GetComponent<GameStats>().pistolAmmo;
        //load gun on start of scene
        reload();
        clipEmpty = false;
    }

    void Update()
    {
        //check if the clip is empty
        AmmoText.text = "Pistol: " + pistolClip + " Ammo Supply: " + pistolAmmo;
        clipEmpty = checkAmmo();
        gameStats.GetComponent<GameStats>().pistolAmmo = pistolAmmo;
    }

    public bool reload()
    {
        bool reloaded = false;

        int ammoToAdd = 15 - pistolClip;

        //check if there is enough ammo to fill the clip
        if (pistolAmmo > ammoToAdd)
        {
            //fill clip
            pistolClip = 15;
            pistolAmmo -= ammoToAdd;
            reloaded = true;
            clipEmpty = false;
        }
        else if (pistolAmmo == 0)
        {
            //don't reload if no ammo
            reloaded = false;
            clipEmpty = true;
        }
        else if (pistolClip == 15)
        {
            //the can reload but it won't effect
            reloaded = true;
            clipEmpty = false;
        }
        else
        {
            //puts remaining ammo in clip
            pistolClip += pistolAmmo;
            pistolAmmo = 0;
            reloaded = true;
            clipEmpty = false;
        }

        return reloaded;
    }

    bool checkAmmo()
    {
        if (pistolClip == 0)
        {
            //out of ammo prompt a reload (click sound instead of bullet firing sound)
            return true;
        }
        else
        {
            return false;
        }
    }

}