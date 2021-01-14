using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AntManager : Singleton<AntManager>
{
    #region Private Field
    List<Ant> ants = new List<Ant>();
    #endregion

    #region Public Field
    [Header("Ant Targets")]
    public Transform holeTarget;
    public Transform nestTarget;

    [HideInInspector] public Piece targetPiece;
    #endregion

    #region Local Events
    public static UnityEvent OnAntSpawn = new UnityEvent();
    public static UnityEvent OnAntMove = new UnityEvent();
    public static UnityEvent OnNestReach = new UnityEvent();
    #endregion

    #region Properties
    public int AntCountLevel
    {
        get
        {
            return PlayerPrefs.GetInt("AntCountLevel", 1);
        }
        set
        {
            PlayerPrefs.SetInt("AntCountLevel", value);
        }
    }

    public int AntSpeedLevel
    {
        get
        {
            return PlayerPrefs.GetInt("AntSpeedLevel", 1);
        }
        set
        {
            PlayerPrefs.SetInt("AntSpeedLevel", value);
        }
    }

    public int AntStrengthLevel
    {
        get
        {
            return PlayerPrefs.GetInt("AntStrengthLevel", 6);
        }
        set
        {
            PlayerPrefs.SetFloat("AntStrength", value);
        }
    }
    #endregion

    #region List Methods
    public void AddAnt(Ant ant)
    {
        if (!ants.Contains(ant))
            ants.Add(ant);
    }
    #endregion

    #region Public Get Paths Methods
    public Vector3 [] CreateTargetPath()
    {
        targetPiece = PieceManager.Instance.nearestPoint();
        return new Vector3[] { holeTarget.position, nestTarget.position, targetPiece.transform.position };
    }

    public Vector3 [] NestPath()
    {
        return new Vector3[] { nestTarget.position, holeTarget.position };
    }
    #endregion
}
