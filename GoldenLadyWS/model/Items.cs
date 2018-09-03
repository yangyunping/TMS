using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenLadyWS.Model
{
    public class Items
    {
        private string _text = null;
        private object _value = null;
        private string _type = null;

        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
            }
        }
        public object Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        public override string ToString()
        {
            return this._text;
        }
    }
}
