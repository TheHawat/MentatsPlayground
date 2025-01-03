struct FencedField {
    public bool[] DirectedFence = new bool[4];
    public int FieldID = -1;
    public char FieldProduce;
    public bool Visited = false;
    public FencedField(char CurrentField) {
        FieldProduce = CurrentField;
        DirectedFence = new[] { false, false, false, false };
    }
}