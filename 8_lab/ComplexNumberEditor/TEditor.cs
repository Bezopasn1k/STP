using MyComplexNumber;
using System;

namespace ComplexNumberEditor
{
    public class TEditor
    {
        public TEditor(ComplexNumber number)
        {
            m_StrNumber = number.ToString();
            m_StrNumberRl = number.GetReStr();
            m_StrNumberIm = number.GetImStr();
        }
        private string m_StrNumber = "0";
        private string m_StrNumberRl = "0";
        private string m_StrNumberIm = "0";
        private bool editingRealPart = true;
        private bool imSign = true;
        public bool IsZero()
        {
            return (m_StrNumberRl == "0" && m_StrNumberIm == "0") ? true : false;
        }

        public void AddSign()
        {
            if (editingRealPart)
            {
                if (m_StrNumberRl[0] != '-')
                {
                    m_StrNumberRl = "-" + m_StrNumberRl;
                }
                else
                {
                    m_StrNumberRl = m_StrNumberRl.Remove(0, 1);
                }
            }
            else
            {
                imSign = !imSign;
            }
            m_StrNumber = m_StrNumberRl + m_StrNumberIm;
        }

        public void AddDigit(int digit)
        {
            if (editingRealPart)
            {
                if (digit >= 0)
                {
                    m_StrNumberRl += Convert.ToString(digit);
                }
            }
            else
            {
                if (digit >= 0)
                {
                    m_StrNumberIm += Convert.ToString(digit);
                }
            }
            m_StrNumber = m_StrNumberRl + m_StrNumberIm;
        }

        public void AddZero()
        {
            if (editingRealPart)
            {
                m_StrNumberRl += "0";
            }
            else
            {
                m_StrNumberIm += "0";
            }
            m_StrNumber = m_StrNumberRl + m_StrNumberIm;
        }

        public void Pop()
        {
            if (editingRealPart)
            {
                int num = 0;
                if (m_StrNumberRl[0] == '-')
                {
                    num++;
                }
                if (m_StrNumberRl.Length - 1 > 0 + num)
                {
                    m_StrNumberRl = m_StrNumberRl.Remove(m_StrNumberRl.Length - 1);
                    m_StrNumber = m_StrNumberRl + m_StrNumberIm;
                }
            }
            else
            {
                if (m_StrNumberIm.Length - 1 > 0)
                {
                    m_StrNumberIm = m_StrNumberIm.Remove(m_StrNumberIm.Length - 1);
                    m_StrNumber = m_StrNumberRl + m_StrNumberIm;
                }
            }
        }

        public void Clear()
        {
            m_StrNumberRl = "0";
            m_StrNumberIm = "0";
            m_StrNumber = "0+0";
        }

        private string EditAddSeparator(string input, string separator)
        {
            if (!input.Contains(separator))
            {
                input += separator;
            }
            return input;
        }


        public void ChangeEditingZone()
        {
            editingRealPart = !editingRealPart;
        }


        public void AddSeparator()
        {
            if (editingRealPart)
            {
                m_StrNumberRl = EditAddSeparator(m_StrNumberRl, ".");
            }
            else
            {
                m_StrNumberIm = EditAddSeparator(m_StrNumberIm, ".");
            }
        }

        public string GetFullString()
        {
            if (imSign == false)
            {
                return $"{m_StrNumberRl} - i*{m_StrNumberIm}";
            }
            else
            {
                return $"{m_StrNumberRl} + i*{m_StrNumberIm}";
            }
        }

        public bool IsEditingRealPart()
        {
            return editingRealPart;
        }

        public string GetRl()
        {
            return m_StrNumberRl;
        }

        public string GetIm()
        {
            return m_StrNumberIm;
        }
    }
}
