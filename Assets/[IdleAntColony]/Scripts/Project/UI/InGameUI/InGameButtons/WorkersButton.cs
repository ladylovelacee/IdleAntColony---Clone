using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorkersButton : Button, Increase
{
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(IncreaseLevel);
    }

    protected override void OnDisable()
    {
        base.OnEnable();
        onClick.RemoveListener(IncreaseLevel);
    }

    public void IncreaseCost()
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseLevel()
    {
        AntManager.OnAntSpawn.Invoke();
    }

    public void SetText()
    {
        throw new System.NotImplementedException();
    }
}
