using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace CNX.UserService.Model.Types
{
    public struct Email
    {
        private readonly string _value;
        public string Value { get => _value; }
        public bool IsValid { get; internal set; }

        private Email(string value)
        {
            _value = value;
            IsValid = false;
        }

		public string ToUpper() => _value.ToUpper();
        public string ToLower() => _value.ToLower();

		public override string ToString() => _value;
        public override bool Equals(object obj) => _value.Equals(obj);
        public override int GetHashCode() => _value.GetHashCode();

        public static bool operator ==(Email email, string value) => email._value == value;
        public static bool operator !=(Email email, string value) => !(email._value == value);

        public static bool operator ==(string value, Email email) => value == email._value;
        public static bool operator !=(string value, Email email) => !(value == email._value);

        public static bool operator ==(Email email, Email value) => email._value == value._value;
        public static bool operator !=(Email email, Email value) => !(email._value == value._value);
        
        public static implicit operator Email(string value) => Parse(value);
        public static Email Parse(string value) => TryParse(value, out var result) ? result : "";

        public static bool TryParse(string value, out Email result)
        {
			result = new Email(value);
			return isValid(value) ? result.IsValid = true : result.IsValid = false;
        }

        private static Regex _regex = 
            new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                RegexOptions.CultureInvariant | RegexOptions.Compiled);
        private static bool isValid(string email) => _regex.IsMatch(email);
    }
}
   
