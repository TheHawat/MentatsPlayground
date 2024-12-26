public static class Sapho{
    public static readonly (int X, int Y)[] FourWay = {(-1, 0), (0, 1), (1, 0), (0, -1)};
    public static readonly (int X, int Y)[] FourWayRight = {(0, 1), (1, 0), (0, -1),(-1, 0)};
    public static readonly (int X, int Y, char Dir)[] DirectedFourWay = {(-1, 0, '^'), (0, 1, '>'), (1, 0, 'v'), (0, -1, '<')};
    public static readonly (int X, int Y)[] EightWay = {(1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (-1, -1), (-1, 1), (1, -1) };
    public static readonly char[] Directions = {'^', '>', 'v', '<'};
    public static void IterateTwoD(string[] array, Action<char> ZugZug){
        foreach (var row in array){
            foreach (var TheThing in row){
                ZugZug(TheThing);
            }
        }
    }

    public static void IterateTwoD(string[] array, Action<char> GruntZugZug, Action<string> Ogre){
        foreach (var TheRow in array){
            foreach (var TheThing in TheRow){
                GruntZugZug(TheThing);
            }
            Ogre(TheRow);
        }
    }

    public static void IterateTwoD(ref string[] array, Action<char> GruntZugZug, Action<string> OgreZugZug){
        foreach (var TheRow in array){
            foreach (var TheThing in TheRow){
                if (GruntZugZug!=null) GruntZugZug(TheThing);
            }
            if (OgreZugZug!=null) OgreZugZug(TheRow);
        }
    }

    public static void IterateTwoD<T>(T[][] array, Action<T> action){
        foreach (var row in array){
            foreach (var element in row){
                action(element);
            }
        }
    }

    internal static bool InArrayRange(int checkinX, int checkinY, string[] input)
    {
        if (checkinX < 0) return false;
        if (checkinY < 0) return false;
        if (checkinX >= input.Length) return false;
        if (checkinY >= input[checkinX].Length) return false;
        return true;
    }
    internal static bool InArrayRange<T>(int checkinX, int checkinY, T[][] input)
    {
        if (checkinX < 0) return false;
        if (checkinY < 0) return false;
        if (checkinX >= input.Length) return false;
        if (checkinY >= input[checkinX].Length) return false;
        return true;
    }
}