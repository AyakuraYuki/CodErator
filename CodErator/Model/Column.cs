namespace CodErator.Model
{
    public class Column
    {
        public string ColumnName { get; set; }

        private bool isNullable;
        public bool IsNullable
        {
            get => isNullable;
        }
        public void SetNullable(string isNullable)
        {
            if ("YES".Equals(isNullable.ToUpper()))
                this.isNullable = true;
            else
                this.isNullable = false;
        }

        public string DataType { get; set; }
        public string CharacterMaximumLength { get; set; }
        public string CharacterSetName { get; set; }
        public string ColumnType { get; set; }
        public string ColumnComment { get; set; }
    }
}
