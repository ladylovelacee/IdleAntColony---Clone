using UnityEngine;
using DG.Tweening;

public class Ant : MonoBehaviour
{
    #region Private Fields
    Tween move;
    Piece targetPiece;
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(Initiliaze);
        AntManager.OnAntMove.AddListener(Initiliaze);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(Initiliaze);
        AntManager.OnAntMove.RemoveListener(Initiliaze);
    }

    void Initiliaze()
    {
        AntManager.Instance.AddAnt(this);
        transform.position = AntManager.Instance.holeTarget.position;
        MoveTarget();
    }

    void MoveTarget()
    {
        var path = AntManager.Instance.CreateTargetPath();
        targetPiece = AntManager.Instance.targetPiece; 
        move = transform.DOPath(path, targetPiece.distance / AntManager.Instance.AntSpeedLevel)
            .SetLookAt(0.01f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                targetPiece.Scale();
                EventManager.OnLevelContinue.AddListener(MoveNest);
            });
    }

    void MoveNest()
    {
        var path = AntManager.Instance.NestPath();
        move.Kill();
        targetPiece.SetParent(transform);
        
        move = transform.DOPath(path, AntManager.Instance.AntSpeedLevel)
            .SetLookAt(0.01f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Destroy(targetPiece.gameObject);
                AntManager.OnNestReach.Invoke();
                MoveTarget();
            });
    }
    #endregion
}
