using UnityEngine;
using System.Collections;

public class ChangeGoose : MonoBehaviour
{
    public AnimatorOverrideController goose_1;
    public AnimatorOverrideController goose_2;
    public AnimatorOverrideController goose_3;
    public AnimatorOverrideController goose_4;

    private AnimatorOverrideController currentGoose;

    void Start()
    {
        int gooseIndex = PlayerPrefs.GetInt("gooseIndex", 4);
        switch(gooseIndex)
        {
            case 1:
                currentGoose = goose_1;
                break;
            case 2:
                currentGoose = goose_2;
                break;
            case 3:
                currentGoose = goose_3;
                break;

            case 4:
                currentGoose = goose_4;
                break;

            default:
                currentGoose = goose_4;
                break;
        }
        GetComponent<Animator>().runtimeAnimatorController = currentGoose;
    }

    public void Goose_1()
    {
        if (PlayerPrefs.GetInt("shopItem_1") == 1 || PlayerPrefs.GetInt("coins") >= 20) {
            currentGoose = goose_1;
            GetComponent<Animator>().runtimeAnimatorController = currentGoose;
            PlayerPrefs.SetInt("gooseIndex", 1);
        }
    }

    public void Goose_2()
    {
        if (PlayerPrefs.GetInt("shopItem_2") == 1 || PlayerPrefs.GetInt("coins") >= 50)
        {
            currentGoose = goose_2;
            GetComponent<Animator>().runtimeAnimatorController = currentGoose;
            PlayerPrefs.SetInt("gooseIndex", 2);

        }
    }
    public void Goose_3()
    {
        if (PlayerPrefs.GetInt("shopItem_3") == 1 || PlayerPrefs.GetInt("coins") >= 100)
        {
            currentGoose = goose_3;
            GetComponent<Animator>().runtimeAnimatorController = currentGoose;
            PlayerPrefs.SetInt("gooseIndex", 3);
        }
    }

    public void Goose_4()
    {
        if (PlayerPrefs.GetInt("shopItem_4") == 1 || PlayerPrefs.GetInt("coins") >= 0)
        {
            currentGoose = goose_4;
            GetComponent<Animator>().runtimeAnimatorController = currentGoose;
            PlayerPrefs.SetInt("gooseIndex", 4);
        }
    }

}
