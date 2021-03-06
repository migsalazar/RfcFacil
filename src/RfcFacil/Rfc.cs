﻿
namespace RfcFacil
{
    public class Rfc
    {
        public string TenDigitsCode { get; private set; }
        public string Homoclave { get; private set; }
        public string VerificationDigit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenDigitsCode"></param>
        /// <param name="homoclave"></param>
        /// <param name="verificationDigit"></param>
        private Rfc(string tenDigitsCode, string homoclave, string verificationDigit)
        {
            this.TenDigitsCode = tenDigitsCode;
            this.Homoclave = homoclave;
            this.VerificationDigit = verificationDigit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenDigitsCode"></param>
        /// <param name="homoclave"></param>
        /// <param name="verificationDigit"></param>
        /// <returns></returns>
        public static Rfc Build(string tenDigitsCode, string homoclave, string verificationDigit)
        {
            return new Rfc(tenDigitsCode, homoclave, verificationDigit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.TenDigitsCode + this.Homoclave + this.VerificationDigit;
        }
    }
}
