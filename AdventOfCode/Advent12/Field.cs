public class Field {
    public int TotalPrice = 0;
    private FencedField[][] _fences = [];
    private int _nextFieldID = 0;

    public Field(string[] input) {
        _fences = new FencedField[input.Length][];
        for (int i = 0; i < input.Length; i++) {
            _fences[i] = new FencedField[input[i].Length];
            for (int j = 0; j < input.Length; j++) {
                _fences[i][j] = new(input[i][j]);
                //Fences[i][j].FieldProduce = input[i][j];
                //Console.WriteLine($"X:{i}    Y:{j}   ^:{Fences[i][j].DirectedFence[0]}   >:{Fences[i][j].DirectedFence[1]}   v:{Fences[i][j].DirectedFence[2]}   <:{Fences[i][j].DirectedFence[3]}");
            }
        }
    }

    public void SetTotalPrice() {
        for (int i = 0; i < _fences.Length; i++) {
            for (int j = 0; j < _fences[i].Length; j++) {
                if (!_fences[i][j].Visited) TraverseWholeField(i, j);
            }
        }
        for (int i = 0; i < _fences.Length; i++) {
            for (int j = 0; j < _fences[i].Length; j++) {
                Console.WriteLine($"X:{i} Y:{j}    Prod:{_fences[i][j].FieldID} ^:{_fences[i][j].DirectedFence[0]}   >:{_fences[i][j].DirectedFence[1]}   v:{_fences[i][j].DirectedFence[2]}   <:{_fences[i][j].DirectedFence[3]}");
            }
        }
        int[] Sizes = GetFenceSizes();
        TotalPrice = GetTotalPrice(Sizes);
    }

    private int GetTotalPrice(int[] sizes) {
        int sum = 0;
        for (int i = 1; i < sizes.Length; i++) {
            int count = _fences
                .SelectMany(row => row)
                .Count(field => field.FieldID == i);
            //Console.WriteLine(count);
            sum += sizes[i] * count;
        }
        return sum;
    }

    private int[] GetFenceSizes() {
        int[] FenceAmountById = new int[_nextFieldID + 1];
        Array.Fill(FenceAmountById, 0);
        bool FoundUp = _fences[0][0].DirectedFence[0];
        bool FoundRight = _fences[0][0].DirectedFence[1];
        bool FoundDown = _fences[0][0].DirectedFence[2];
        bool FoundLeft = _fences[0][0].DirectedFence[3];
        int CurrentID = _fences[0][0].FieldID;
        for (int i = 0; i < _fences.Length; i++) {
            for (int j = 0; j < _fences[i].Length; j++) {
                if (_fences[i][j].FieldID != CurrentID) {
                    Console.WriteLine($"{CurrentID}    {FenceAmountById.Length}");
                    if (FoundUp) FenceAmountById[CurrentID]++;
                    if (FoundDown) FenceAmountById[CurrentID]++;
                    CurrentID = _fences[i][j].FieldID;
                }
                else {
                    if (FoundUp == true && !_fences[i][j].DirectedFence[0]) FenceAmountById[CurrentID]++;
                    if (FoundDown == true && !_fences[i][j].DirectedFence[2]) FenceAmountById[CurrentID]++;
                }
                FoundUp = _fences[i][j].DirectedFence[0];
                FoundDown = _fences[i][j].DirectedFence[2];
            }
        }
        if (FoundUp) FenceAmountById[CurrentID]++;
        if (FoundDown) FenceAmountById[CurrentID]++;
        for (int j = 0; j < _fences[0].Length; j++) {
            for (int i = 0; i < _fences.Length; i++) {
                if (_fences[i][j].FieldID != CurrentID) {
                    Console.WriteLine($"{CurrentID}    {FenceAmountById.Length}");
                    if (FoundRight) FenceAmountById[CurrentID]++;
                    if (FoundLeft) FenceAmountById[CurrentID]++;
                    CurrentID = _fences[i][j].FieldID;
                }
                else {
                    if (FoundRight == true && !_fences[i][j].DirectedFence[1]) FenceAmountById[CurrentID]++;
                    if (FoundLeft == true && !_fences[i][j].DirectedFence[3]) FenceAmountById[CurrentID]++;
                }
                FoundRight = _fences[i][j].DirectedFence[1];
                FoundLeft = _fences[i][j].DirectedFence[3];
            }
        }
        return FenceAmountById;
    }

    private void TraverseWholeField(int x, int y) {
        char CurrentProduce = _fences[x][y].FieldProduce;
        int CountOfThisField = 0;
        _nextFieldID++;
        //Console.WriteLine($"CurrentProduce: {Wheats[x][y]}    Count:{CountOfThisField}");
        MoveAroundTheField(x, y, CurrentProduce, ref CountOfThisField, _nextFieldID);
    }

    private void MoveAroundTheField(int x, int y, char CurrentProduce, ref int Counter, int ID) {
        _fences[x][y].Visited = true;
        _fences[x][y].FieldID = ID;
        Counter++;
        for (int i = 0; i < Sapho.FourWay.Length; i++) {
            int CheckinX = x + Sapho.FourWay[i].X;
            int CheckinY = y + Sapho.FourWay[i].Y;
            if (Sapho.InArrayRange(CheckinX, CheckinY, _fences)) {
                if (_fences[CheckinX][CheckinY].Visited) {
                    if (_fences[CheckinX][CheckinY].FieldProduce != CurrentProduce) {
                        _fences[x][y].DirectedFence[i] = true;
                        int OtherDir = i + 2;
                        if (OtherDir > 3) OtherDir -= 4;
                        _fences[CheckinX][CheckinY].DirectedFence[OtherDir] = true;
                    }
                    continue;
                }
                if (_fences[CheckinX][CheckinY].FieldProduce == CurrentProduce) MoveAroundTheField(CheckinX, CheckinY, CurrentProduce, ref Counter, ID);
            }
            else _fences[x][y].DirectedFence[i] = true;
        }
    }
}