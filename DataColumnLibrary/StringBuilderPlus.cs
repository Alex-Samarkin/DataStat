using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataColumnLibrary
{
    public class StringBuilderPlus
    {
        public StringBuilder SB { get; set; } = new StringBuilder();

        public override string ToString()
        {
            return SB.ToString();
        }

        public void AppendLine(string s) => SB.AppendLine(s);
        public void Clear() => SB.Clear();

        public List<string> PatternList { get; set; } = new List<string>()
            { "[=]", "[-]", "[_]", "[.]", "[:]", "[*]" };

        public void AddPattern(char c0 = '<', char c1 = '-', char c2 = '>') =>
            PatternList.Add($"{c0}{c1}{c2}");

        public int Width { get; set; } = 80;
        public int DoubleW { get; set; } = 12;
        public int DoubleDec { get; set; } = 4;

        public string Hr(int patternIndex = 0)
        {
            var res = PatternList[patternIndex][0] +
                      new string(PatternList[patternIndex][1], Width - 2) +
                      PatternList[patternIndex][2];
            return res;
        }

        public string ResStr(string s, int l1, int l2, int patternIndex = 0)
        {
            return PatternList[patternIndex][0] +
                   new string(PatternList[patternIndex][1], l1) +
                   s +
                   new string(PatternList[patternIndex][1], l2) +
                   PatternList[patternIndex][2];
        }

        public string PrintAtPos(int pos, string s, int patternIndex = 0)
        {
            var l1 = pos;
            var l2 = Width - 2 - pos - s.Length;
            return ResStr(s, l1, l2, patternIndex);
        }

        public string PrintAtPos(int pos, double d, int patternIndex = 0)
        {
            var s = $"{d,10:G3}";
            var l1 = pos;
            var l2 = Width - 2 - pos - s.Length;
            return ResStr(s, l1, l2, patternIndex);
        }

        public string PrintAtPos(int pos, string comment, double d, int patternIndex = 0)
        {
            var s = $"{comment} {d,10:G3}";
            var l1 = pos;
            var l2 = Width - 2 - pos - s.Length;
            return ResStr(s, l1, l2, patternIndex);
        }

        public string LJust(string s, int patternIndex = 0)
        {
            var l1 = 0;
            var l2 = Width - 2 - s.Length;
            return ResStr(s, l1, l2, patternIndex);
        }

        public string LJust(double d, string comment = "", int patternIndex = 0)
        {
            var s = $"{comment}{d,10:G3}";
            return LJust(s, patternIndex);
        }

        public string RJust(string s, int patternIndex = 0)
        {
            var l1 = 0;
            var l2 = Width - 2 - s.Length;
            return ResStr(s, l2, l1, patternIndex);
        }

        public string RJust(double d, string comment = "", int patternIndex = 0)
        {
            var s = $"{comment}{d,10:G3}";
            return RJust(s, patternIndex);
        }

        public string CenterJust(string s, int patternIndex = 0)
        {
            var l1 = (int)(Width - 2 - s.Length) / 2;
            var l2 = Width - 2 - l1 - s.Length;
            return ResStr(s, l1, l2, patternIndex);
        }

        public string CenterJust(double d, string comment = "", int patternIndex = 0)
        {
            var s = $"{comment}{d,10:G3}";
            return CenterJust(s, patternIndex);
        }

        public string Tab(List<double> dd, int patternIndex = 0)
        {
            char c0 = PatternList[patternIndex][0];
            char c1 = PatternList[patternIndex][1];
            char c2 = PatternList[patternIndex][2];
            var l = (int)(Width - 2) / dd.Count;

            if (l < 10) return Hr();
            string res = "";
            int i = 0;
            foreach (double d in dd)
            {
                i++;
                var s = $"{d,10:G3}";
                if (i == dd.Count) l = (int)(Width - 2) - res.Length;
                var l1 = (l - s.Length) / 2;
                var l2 = l - s.Length - l1;
                res += new string(c1, l1) + s + new string(c1, l1);
            } 
            return $"{c0}{res}{c2}";
        }

        public string BarString(int l1, int l2, int l3, int patternIndex = 0, char empty = ' ')
        {
            return new string(empty, l1) + 
                   new string(PatternList[patternIndex][1], l2)+
                   new string(empty, l3);
        }
        public string Positive(double d, 
            double maxD = 100, 
            int patternIndex = 0, char empty = ' ')
        {
            var s = $"{d,10:G3} | ";
            var l1 = (int)(d / maxD * (Width - 2 - s.Length));
            var l2 = (Width - 2 - s.Length)-l1;
            var c0 = PatternList[patternIndex][0];
            var c1 = PatternList[patternIndex][1];
            var c2 = PatternList[patternIndex][2];
            //return $"{c0}{s}{new string(c1, l1)}{new string(' ', l2)}{c2}";
            return $"{c0}{s}{BarString(0,l1,l2, patternIndex,empty)}{c2}";
        }

        public string FromTo(double d,
            double minD = -100,
            double maxD = 100,
            double baseD = 0,
            int patternIndex = 0, char empty = ' ')
        {
            double h = (maxD - minD);
            double h1 = (maxD - baseD);
            double h2 = (baseD-minD);
            double d1 = d - baseD;

            var s = $"{d,10:G3} | ";
            var l = Width - 2 - s.Length;

            var scale = l / h;
            var basePos = (int)(h2 * scale);

            var l1 = 0;
            var l2 = 0;
            var l3 = 0;


            if (d1 >= 0)
            {
                l1 = basePos;
                l2 = (int)(d1*scale);
                l3 = l - l1 - l2;
            }
            if (d1 < 0)
            {
                l2 = (int)(-d1 * scale);
                l1 = basePos-l2;
                l3 = l - l1 - l2;
            }
            var c0 = PatternList[patternIndex][0];
            var c1 = PatternList[patternIndex][1];
            var c2 = PatternList[patternIndex][2];

            return $"{c0}{s}{BarString(l1, l2, l3, patternIndex, empty)}{c2}";
        }
    }
}