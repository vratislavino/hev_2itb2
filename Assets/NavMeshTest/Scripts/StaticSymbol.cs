using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSymbol : MonoBehaviour
{
    protected SymbolEnum? symbol;

    [SerializeField]
    protected List<Material> materials;

    [SerializeField]
    protected MeshRenderer quadRenderer;

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
