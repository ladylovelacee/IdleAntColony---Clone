using UnityEngine;
using DG.Tweening;

public class Piece : MonoBehaviour, Scaleable
{
    #region Public Field
    public float distance;
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        distance = Vector3.Distance(transform.position, Vector3.zero);
        PieceManager.Instance.AddPiece(this);
    }

    public void SetParent(Transform parent)
    {
        transform.position = parent.position + Vector3.up * 0.01f;
        transform.localScale = new Vector3(1, 1, 1);
        transform.parent = parent;
    }
    #endregion

    #region Methods From Interface
    public void Scale()
    {
        transform.DOScale(0, DataManager.Instance.pieceScaleDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                PieceManager.Instance.CheckNubbin();
            });
    }
    #endregion
}
