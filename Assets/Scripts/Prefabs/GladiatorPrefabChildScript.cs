using UnityEngine;
using System.Collections;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Prefabs;
using Assets.Scripts.Logic.Enums;
using UnityEngine.UI;

public class GladiatorPrefabChildScript : MonoBehaviour
{
    public GladiatorPrefabChildType ElementType;

    private Gladiator gladiator;

    void Start()
    {
        GameObject currentContainer = gameObject;

        while (gladiator == null)
        {
            var gladiatorScript = currentContainer.GetComponent<GladiatorPrefabScript>();

            if (gladiatorScript != null)
            {
                if (gladiatorScript.Gladiator != null)
                {
                    gladiator = gladiatorScript.Gladiator;
                }
                else
                {
                    throw new UnassignedReferenceException();
                }
            }
            else
            {
                currentContainer = currentContainer.transform.parent.gameObject;
            }
        }

        switch (ElementType)
        {
            case GladiatorPrefabChildType.Name:
                gameObject.GetComponent<Text>().text = gladiator.Name;
                break;
            case GladiatorPrefabChildType.Level:
                break;
            case GladiatorPrefabChildType.Skill:
                break;
            case GladiatorPrefabChildType.Style:
                break;
            case GladiatorPrefabChildType.Xp:
                break;
            case GladiatorPrefabChildType.Perks:
            default:
                break;
        }
    }
}
