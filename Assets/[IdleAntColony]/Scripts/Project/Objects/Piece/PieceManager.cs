using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PieceManager : Singleton<PieceManager>
{
    #region Private Field
    public List<Piece> pieces = new List<Piece>();
    public List<Piece> temp;
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.AddListener(SortList);
    }
    #endregion

    #region Public Methods
    public void AddPiece(Piece piece)
    {
        if (!pieces.Contains(piece))
            pieces.Add(piece);
    }

    public void CheckNubbin()
    {
        if (pieces.Count <= 1) 
            EventManager.OnLevelFinish.Invoke();

        else
            EventManager.OnLevelContinue.Invoke();
    }

    public void SortList()
    {
        var temp2 = from s in pieces orderby s.distance descending select s;
        temp = temp2.ToList();
    }

    public Piece nearestPoint()
    {
        Piece point = temp[temp.Count - 1];
        temp.RemoveAt(temp.Count - 1);
        return point;
    }
    #endregion
}
