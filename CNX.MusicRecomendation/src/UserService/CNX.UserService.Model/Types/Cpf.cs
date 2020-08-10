using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace CNX.UserService.Model.Types
{
    public struct Cpf
    {
        private readonly string _value;
        public bool IsValid { get; internal set; }
        public int Length { get => _value.Length; }
        public string Value { get => _value; }
        
        private Cpf(string value)
        {
            _value = value;
            IsValid = false;
        }

		public override string ToString() => _value;
        public override bool Equals(object obj) => _value.Equals(obj);
        public override int GetHashCode() => _value.GetHashCode();
        
        public static bool operator ==(Cpf cpf, string value) => cpf._value == value;
        public static bool operator !=(Cpf cpf, string value) => !(cpf._value == value);

        public static bool operator ==(string value, Cpf cpf) => value == cpf._value;
        public static bool operator !=(string value, Cpf cpf) => !(value == cpf._value);

        public static bool operator ==(Cpf cpf, Cpf value) => cpf._value == value._value;
        public static bool operator !=(Cpf cpf, Cpf value) => !(cpf._value == value._value);
        
        public static implicit operator Cpf(string value) => Parse(value);
        public static Cpf Parse(string value) => TryParse(value, out var result) ? result : "";

        public static bool TryParse(string value, out Cpf result)
        {
			result = new Cpf(value);
			return isValid(value) ? result.IsValid = true : result.IsValid = false;
        }

        private static bool isValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;
            

            int position = 0,
                totalDigits1 = 0,
                totalDigits2 = 0,
                verifierDigit1 = 0,
                verifierDigit2 = 0;

            bool hasIdenticalDigits = true;
            var lastDigit = -1;
            const char zeroAsChar = '0';
            foreach (var character in cpf)
            {
                if (char.IsDigit(character))
                {
                    var digit = character - zeroAsChar;
                    if (position != 0 && lastDigit != digit)
                    {
                        hasIdenticalDigits = false;
                    }

                    lastDigit = digit;
                    if (position < 9)
                    {
                        totalDigits1 += digit * (10 - position);
                        totalDigits2 += digit * (11 - position);
                    }
                    else if (position == 9)
                    {
                        verifierDigit1 = digit;
                    }
                    else if (position == 10)
                    {
                        verifierDigit2 = digit;
                    }

                    position++;
                }
            }

            const int maxCpfLength = 11;
            if (position > maxCpfLength)
                return false;

            if (hasIdenticalDigits)
                return false;

            var digit1 = totalDigits1 % 11;
            digit1 = digit1 < 2 ? 0 : 11 - digit1;

            if (verifierDigit1 != digit1)
                return false;
            
            totalDigits2 += digit1 * 2;
            var digit2 = totalDigits2 % 11;
            digit2 = digit2 < 2 ? 0 : 11 - digit2;

            return verifierDigit2 == digit2;
        }
    }
}
   
