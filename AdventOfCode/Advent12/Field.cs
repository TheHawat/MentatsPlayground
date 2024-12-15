public class Field{
    public int TotalPrice = 0;
    private FencedField[][] Fences = [];
    private int NextFieldID = 0;

    public Field(string[] input){
        Fences  = new FencedField[input.Length][];
        for (int i = 0; i < input.Length; i++){
            Fences[i] = new FencedField[input[i].Length];
            for (int j = 0; j < input.Length; j++){
                Fences[i][j] = new(input[i][j]);
                //Fences[i][j].FieldProduce = input[i][j];
                //Console.WriteLine($"X:{i}    Y:{j}   ^:{Fences[i][j].DirectedFence[0]}   >:{Fences[i][j].DirectedFence[1]}   v:{Fences[i][j].DirectedFence[2]}   <:{Fences[i][j].DirectedFence[3]}");
            }
        }
    } 

    public void SetTotalPrice(){
        for (int i = 0; i < Fences.Length; i++){
            for (int j = 0; j < Fences[i].Length; j++){
                if(!Fences[i][j].Visited) TraverseWholeField(i, j);
            }
        }
        for (int i = 0; i < Fences.Length; i++){
            for (int j = 0; j < Fences[i].Length; j++){
                Console.WriteLine($"X:{i} Y:{j}    Prod:{Fences[i][j].FieldID} ^:{Fences[i][j].DirectedFence[0]}   >:{Fences[i][j].DirectedFence[1]}   v:{Fences[i][j].DirectedFence[2]}   <:{Fences[i][j].DirectedFence[3]}");
            }
        }
        int[] Sizes = GetFenceSizes();
        TotalPrice = GetTotalPrice(Sizes);
    }

    private int GetTotalPrice(int[] sizes){
        int sum = 0;
        for (int i = 1; i < sizes.Length; i++){
            int count = Fences
                .SelectMany(row => row)
                .Count(field => field.FieldID == i);
                //Console.WriteLine(count);
                sum += sizes[i] * count;
        }
        return sum;
    }

    private int[] GetFenceSizes(){
        int[] FenceAmountById = new int[NextFieldID+1];
        Array.Fill(FenceAmountById, 0);
        bool FoundUp    = Fences[0][0].DirectedFence[0];
        bool FoundRight = Fences[0][0].DirectedFence[1];
        bool FoundDown  = Fences[0][0].DirectedFence[2];
        bool FoundLeft  = Fences[0][0].DirectedFence[3];
        int  CurrentID  = Fences[0][0].FieldID;
        for (int i = 0; i < Fences.Length; i++){
            for (int j = 0; j < Fences[i].Length; j++){
                if (Fences[i][j].FieldID != CurrentID ){
                    Console.WriteLine($"{CurrentID}    {FenceAmountById.Length}");
                    if (FoundUp) FenceAmountById[CurrentID]++;
                    if (FoundDown) FenceAmountById[CurrentID]++;
                    CurrentID = Fences[i][j].FieldID;
                } else{
                    if (FoundUp == true && !Fences[i][j].DirectedFence[0]) FenceAmountById[CurrentID]++;
                    if (FoundDown == true && !Fences[i][j].DirectedFence[2]) FenceAmountById[CurrentID]++;
                }
                FoundUp = Fences[i][j].DirectedFence[0];
                FoundDown  = Fences[i][j].DirectedFence[2];
            }
        }
        if (FoundUp) FenceAmountById[CurrentID]++;
        if (FoundDown) FenceAmountById[CurrentID]++;
        for (int j = 0; j < Fences[0].Length; j++){
            for (int i = 0; i < Fences.Length; i++){
                if (Fences[i][j].FieldID != CurrentID ){
                    Console.WriteLine($"{CurrentID}    {FenceAmountById.Length}");
                    if (FoundRight) FenceAmountById[CurrentID]++;
                    if (FoundLeft) FenceAmountById[CurrentID]++;
                    CurrentID = Fences[i][j].FieldID;
                } else{
                    if (FoundRight == true && !Fences[i][j].DirectedFence[1]) FenceAmountById[CurrentID]++;
                    if (FoundLeft == true && !Fences[i][j].DirectedFence[3]) FenceAmountById[CurrentID]++;
                }
                FoundRight = Fences[i][j].DirectedFence[1];
                FoundLeft  = Fences[i][j].DirectedFence[3];
            }
        }

        //foreach (var num in FenceAmountById) Console.WriteLine(num);
        return FenceAmountById;
    }

    private void TraverseWholeField(int x, int y){
        char CurrentProduce = Fences[x][y].FieldProduce;
        int CountOfThisField = 0;
        NextFieldID++;
        //Console.WriteLine($"CurrentProduce: {Wheats[x][y]}    Count:{CountOfThisField}");
        MoveAroundTheField(x, y, CurrentProduce, ref CountOfThisField, NextFieldID);
    }

    private void MoveAroundTheField(int x, int y, char CurrentProduce, ref int Counter, int ID){
        Fences[x][y].Visited = true;
        Fences[x][y].FieldID = ID;
        Counter++;
        for(int i = 0; i < Sapho.FourWay.Length; i++){
            int CheckinX = x + Sapho.FourWay[i].X;
            int CheckinY = y + Sapho.FourWay[i].Y;
            if (Sapho.InArrayRange(CheckinX, CheckinY, Fences)){
                if (Fences[CheckinX][CheckinY].Visited) {
                    if (Fences[CheckinX][CheckinY].FieldProduce != CurrentProduce){
                        Fences[x][y].DirectedFence[i] = true;
                        int OtherDir = i + 2;
                        if (OtherDir > 3) OtherDir -= 4;
                        Fences[CheckinX][CheckinY].DirectedFence[OtherDir] = true;
                    }
                    continue;
                }
                if(Fences[CheckinX][CheckinY].FieldProduce == CurrentProduce) MoveAroundTheField(CheckinX, CheckinY, CurrentProduce, ref Counter, ID);
            } else Fences[x][y].DirectedFence[i] = true;
        }
    }
}