using System;
using System.Linq;
using System.Text;

namespace AlayGUI
{
    class Alay
    {
        private Random random;
        private char[] letters;
        private StringBuilder sb;
        private char [] wordsNum={'a','b','e','g','i','o','s','t','z'};
        private char[] number = { '4', '6', '3', '9', '1', '0','5', '7','2' };
        private char[]wordsSym={'a','c','i','s','v'};
        private char[] symbol = { '@', '<','!', '$', '^' };

        public Alay()
        {
            random = new Random();
            sb = new StringBuilder();
        }

        //
        //Methods convert normal texts to 4L4Y
        public string numberOnly(string initialText)
        {
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsLetter(letters[i]))
                {
                    for (int j = 0; j < wordsNum.Length; j++)
                    {
                        if (char.ToLower(letters[i]) == wordsNum[j])
                        {
                            letters[i] = number[j];
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string symbolOnly(string initialText)
        {
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsLetter(letters[i]))
                {
                    for (int j = 0; j < wordsSym.Length; j++)
                    {
                        if (char.ToLower(letters[i]) == wordsSym[j])
                        {
                            letters[i] = symbol[j];
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string lowUpCase(string initialText)
        {            
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {   
                if (Char.IsLetter(letters[i]))
                {                    
                    if (random.Next(0, 2) == 0)
                    {   
                        letters[i] = char.ToLower(letters[i]);
                    }
                    else
                    {   
                        letters[i] = char.ToUpper(letters[i]);
                    }
                }
            }
            return convertToString(letters);            
        }
        public string lowNumber(string initialText)
        {
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsLetter(letters[i]))
                {
                    if (random.Next(0, 2) == 0)
                    {
                        letters[i] = char.ToLower(letters[i]);
                    }
                    else
                    {
                        for (int j = 0; j < wordsNum.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsNum[j])
                            {
                                letters[i] = number[j];
                            }
                            else
                            {
                                letters[i] = char.ToLower(letters[i]);
                            }
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string lowSymbol(string initialText)
        {
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsLetter(letters[i]))
                {
                    if (random.Next(0, 2) == 0)
                    {
                        letters[i] = char.ToLower(letters[i]);
                    }
                    else
                    {
                        for (int j = 0; j < wordsSym.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsSym[j])
                            {
                                letters[i] = symbol[j];
                            }
                            else
                            {
                                letters[i] = char.ToLower(letters[i]);
                            }
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string upNumber(string initialText)
        {
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsLetter(letters[i]))
                {
                    if (random.Next(0, 2) == 0)
                    {
                        letters[i] = char.ToUpper(letters[i]);
                    }
                    else
                    {
                        for (int j = 0; j < wordsNum.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsNum[j])
                            {
                                letters[i] = number[j];
                            }
                            else
                            {
                                letters[i] = char.ToUpper(letters[i]);
                            }
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string upSymbol(string initialText)
        {
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsLetter(letters[i]))
                {
                    if (random.Next(0, 2) == 0)
                    {
                        letters[i] = char.ToUpper(letters[i]);
                    }
                    else
                    {
                        for (int j = 0; j < wordsSym.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsSym[j])
                            {
                                letters[i] = symbol[j];
                            }
                            else
                            {
                                letters[i] = char.ToUpper(letters[i]);
                            }
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string numberSymbol(string initialText)
        {
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsLetter(letters[i]))
                {
                    if (random.Next(0, 2) == 0)
                    {
                        for (int j = 0; j < wordsNum.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsNum[j])
                            {
                                letters[i] = number[j];
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < wordsSym.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsSym[j])
                            {
                                letters[i] = symbol[j];
                            }                            
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string lowUpNumber(string initialText)
        {
            int rnd = 0;
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsLetter(letters[i]))
                {
                    rnd = random.Next(0, 3);
                    //To Lower
                    if (rnd == 0)
                    {
                        letters[i] = char.ToLower(letters[i]);
                    }
                    //To Upper
                    else if (rnd == 1)
                    {
                        letters[i] = char.ToUpper(letters[i]);
                    }
                    //To Number
                    else if (rnd == 2)
                    {
                        for (int j = 0; j < wordsNum.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsNum[j])
                            {
                                letters[i] = number[j];
                            }
                        }
                    }                    
                }
            }
            return convertToString(letters);
        }
        public string lowUpSymbol(string initialText)
        {
            int rnd = 0;
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsLetter(letters[i]))
                {
                    rnd = random.Next(0,3);
                    //To Lower
                    if (rnd == 0)
                    {
                        letters[i] = char.ToLower(letters[i]);
                    }
                    //To Upper
                    else if (rnd == 1)
                    {
                        letters[i] = char.ToUpper(letters[i]);
                    }                    
                    //To Symbol
                    else
                    {
                        for (int j = 0; j < wordsSym.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsSym[j])
                            {
                                letters[i] = symbol[j];
                            }
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string lowNumberSymbol(string initialText)
        {
            int rnd = 0;
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsLetter(letters[i]))
                {
                    rnd = random.Next(0, 3);
                    //To Lower
                    if (rnd == 0)
                    {
                        letters[i] = char.ToLower(letters[i]);
                    }                    
                    //To Number
                    else if (rnd == 1)
                    {
                        for (int j = 0; j < wordsNum.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsNum[j])
                            {
                                letters[i] = number[j];
                            }
                        }
                    }
                    //To Symbol
                    else
                    {
                        for (int j = 0; j < wordsSym.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsSym[j])
                            {
                                letters[i] = symbol[j];
                            }
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string upNumberSymbol(string initialText)
        {
            int rnd = 0;
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsLetter(letters[i]))
                {
                    rnd = random.Next(0, 3);                    
                    //To Upper
                    if (rnd == 0)
                    {
                        letters[i] = char.ToUpper(letters[i]);
                    }
                    //To Number
                    else if (rnd == 1)
                    {
                        for (int j = 0; j < wordsNum.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsNum[j])
                            {
                                letters[i] = number[j];
                            }
                        }
                    }
                    //To Symbol
                    else
                    {
                        for (int j = 0; j < wordsSym.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsSym[j])
                            {
                                letters[i] = symbol[j];
                            }
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        public string lowUpNumberSymbol(string initialText)
        {
            int rnd = 0;
            letters = initialText.ToArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsLetter(letters[i]))
                {
                    rnd = random.Next(0, 4);
                    //To Lower
                    if (rnd == 0)
                    {
                        letters[i] = char.ToLower(letters[i]);
                    }
                    //To Upper
                    else if(rnd==1)
                    {
                        letters[i] = char.ToUpper(letters[i]);
                    }
                    //To Number
                    else if (rnd == 2)
                    {
                        for (int j = 0; j < wordsNum.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsNum[j])
                            {
                                letters[i] = number[j];
                            }
                        }
                    }
                    //To Symbol
                    else
                    {
                        for (int j = 0; j < wordsSym.Length; j++)
                        {
                            if (char.ToLower(letters[i]) == wordsSym[j])
                            {
                                letters[i] = symbol[j];
                            }
                        }
                    }
                }
            }
            return convertToString(letters);
        }
        
        //
        //Convert char to String
        public string convertToString(char[] letters)
        {
            sb.Clear();
            sb.Append(letters);
            return sb.ToString();
        }
    }
}
/*Aku seorang kapiten
Mempunyai pedang besar
Kalau berjalan...
Prop... prop... prop...
Aku seorang kapiten...*/