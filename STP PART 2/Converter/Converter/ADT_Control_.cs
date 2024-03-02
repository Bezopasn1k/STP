using System;


namespace Converter
{
    class ADT_Control_
    {
        int pin = 10;
        int pout = 16;
        const int accuracy = 10;
        public History history = new History();
        public enum State { Edit, Converted }
        private State state;
        internal State St { get => state; set => state = value; }
        public int Pin { get => pin; set => pin = value; }
        public int Pout { get => pout; set => pout = value; }
        public ADT_Control_()
        {
            St = State.Edit;
            Pin = pin;
            Pout = pout;
        }
        public Editor editor = new Editor();
        public string doCmnd(int j)
        {
            if (j == 19)
            {
                double r = ADT_Convert_p_10.Dval(editor.getNumber(), (Int16)Pin);
                string res = ADT_Convert_10_p.Do(r, (Int32)Pout, Acc());
                St = State.Converted;
                history.addRecord(Pin, Pout, editor.getNumber(), res);
                return res;
            }
            else
            {
                St = State.Edit;
                return editor.doEdit(j);
            }
        }

        private int Acc()
        {
            return (int)Math.Round(editor.acc() * Math.Log(Pin) / Math.Log(Pout) + 0.5);
        }
    }
}
