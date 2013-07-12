namespace GameCreator.Runtime
{
    public class RealVariable : Variable
    {
        public double value;
        public RealVariable(double initial, bool readOnly)
        {
            value = initial;
            IsReadOnly = readOnly;
            get = Get;
            set = Set;
        }
        public Value Get(int i1, int i2) { return value; }
        void Set(int i1, int i2, Value v) { this.value = v; }
    }
}
