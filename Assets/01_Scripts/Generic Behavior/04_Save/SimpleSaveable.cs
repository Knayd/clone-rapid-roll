using System;
using UnityEngine;

public class SimpleSaveable : BaseSaveable
{
    [SerializeField] private string id = string.Empty;

    [ContextMenu("Generate Id")]
    private void GenerateId() => id = Guid.NewGuid().ToString();

    public override string Id => id;
}
