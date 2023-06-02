namespace ChessApp.final.MiniChess.Abstractions
{
    public class CoorExtensions
    {
        private static readonly Dictionary<char, int> dictionary =
       new Dictionary<char, int>
       {
            {'a',1 }, {'b',2}, {'c',3},{'d',4}, {'e',5},{'f',6 } , {'g',7},{'h',8}
       };

        public static int get(char f)
        {
            return dictionary.FirstOrDefault(x => x.Key == f).Value;
        }
        public static char get(int num)
        {
            return dictionary.FirstOrDefault(x => x.Value == num).Key;
        }

        public static string get(int x, int y)
        {
            char f = get(x);
            return f.ToString() + y.ToString();
        }
        public static int[] get(string f3)
        {
            char f = f3[0];
            int n = 0;
            int.TryParse(f3[1].ToString(), out n);
            return new int[] { get(f), n };

        }
    }
}
