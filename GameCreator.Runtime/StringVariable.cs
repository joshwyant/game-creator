namespace GameCreator.Runtime
{
    public class StringVariable : Variable
    {
        public string value;
        public StringVariable(string initial, bool readOnly)
        {
            value = initial;
            get = Get;
            set = Set;
        }
        public Value Get(int i1, int i2) { return value; }
        void Set(int i1, int i2, Value v) { this.value = v; }
    }
}
