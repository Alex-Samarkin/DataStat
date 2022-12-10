using System;

namespace DataColumnLibrary
{
    public class Head
    {
        public string Name { get; set; } = "Col1";
        public string Description { get; set; } = String.Empty;
        public string Formula { get; set; } = String.Empty;
        public string Unit { get; set; } = String.Empty;
        public Head() { }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, Formula: {Formula}, Unit: {Unit}";
        }

        public string ToFormatString(int width = 100)
        {
            StringBuilderPlus sb = new StringBuilderPlus(){Width = width};
            sb.AppendLine(sb.Hr());
            sb.AppendLine(sb.CenterJust($"Name: {Name}"));
            sb.AppendLine(sb.LJust($"Descr: {Description}",1));
            sb.AppendLine(sb.LJust($"Formula: {Formula}",1));
            sb.AppendLine(sb.LJust($"Unit: {Unit}", 1));
            sb.AppendLine(sb.Hr());
            return sb.ToString();
        }

    }
}