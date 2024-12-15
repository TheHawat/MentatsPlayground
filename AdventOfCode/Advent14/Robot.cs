public class Robot{
    public int PosX;
    public int PosY;
    public int MoveRuleX;
    public int MoveRuleY;

    public Robot(int posX, int posY, int moveX, int moveY){
        PosX = posX;
        PosY = posY;
        MoveRuleX = moveX;
        MoveRuleY = moveY;
    }
    public void Move(int steps){
        PosX += steps * MoveRuleX;
        PosY += steps * MoveRuleY;
    }
    public void Adjust(int boardSizeX, int boardSizeY){
        PosX = PosX % boardSizeX;
        PosY = PosY % boardSizeY;
        if (PosX < 0) PosX = boardSizeX + PosX;
        if (PosY < 0) PosY = boardSizeY + PosY;
    }
}