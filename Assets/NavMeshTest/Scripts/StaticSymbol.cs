using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSymbol : MonoBehaviour
{
    protected SymbolEnum? symbol;
    public SymbolEnum Symbol => symbol.Value;

    [SerializeField]
    protected List<Material> materials;

    [SerializeField]
    protected MeshRenderer quadRenderer;

    protected virtual void Awake() {
        DataHolder.Instance.AddEnemy(this);
    }

    protected virtual void OnDestroy() {
        DataHolder.Instance.RemoveEnemy(this);
    }

    // Start is called before the first frame update
    protected virtual void Start() {
        // ještì nemáme pøiøazené materiály v inspectoru :)
        ChangeSymbol(GenerateSymbol());
    }

    protected void ChangeSymbol(SymbolEnum newSymbol) {
        symbol = newSymbol;
        quadRenderer.material = materials[(int) symbol];
    }

    protected SymbolEnum GenerateSymbol() {
        SymbolEnum newSymbol;
        do {
            newSymbol = (SymbolEnum) Random.Range(0, System.Enum.GetValues(typeof(SymbolEnum)).Length);
        } while (newSymbol == symbol);

        return newSymbol;
    }
}
