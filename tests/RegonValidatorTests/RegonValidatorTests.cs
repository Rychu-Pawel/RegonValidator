using Rychusoft.Validators;
using System;
using Xunit;

namespace RegonValidatorTests
{
    public class RegonValidatorTests
    {
        [Theory]
        [InlineData("280196813")]
        [InlineData("443138072")]
        [InlineData("371358961")]
        [InlineData("893677596")]
        [InlineData("550519667")]
        [InlineData("408888521")]
        [InlineData("575064641")]
        [InlineData("300175026")]
        [InlineData("118315956")]
        [InlineData("673459600")]
        [InlineData("54350420840255")]
        [InlineData("92630057385954")]
        [InlineData("10326901843754")]
        [InlineData("80620880514318")]
        [InlineData("58944905793760")]
        [InlineData("38882530059365")]
        [InlineData("81696011691646")]
        [InlineData("06009873665180")]
        [InlineData("14974233540206")]
        [InlineData("14215866256643")]
        public void IsValid_ValidRegonsTest(string regon)
        {
            Assert.True(RegonValidator.IsValid(regon));
        }

        [Theory]
        [InlineData("54351420840255")]
        [InlineData("92632057385954")]
        [InlineData("10323901843754")]
        [InlineData("80624880514318")]
        [InlineData("58945905793760")]
        [InlineData("38886530059365")]
        [InlineData("81697011691646")]
        [InlineData("06008873665180")]
        [InlineData("14979233540206")]
        [InlineData("14210866256643")]
        public void IsValid_InvalidLongRegonsTest(string regon)
        {
            Assert.False(RegonValidator.IsValid(regon));
        }

        [Theory]
        [InlineData("39437971")]
        [InlineData("8784066")]
        [InlineData("709471")]
        [InlineData("86740")]
        [InlineData("7140")]
        [InlineData("514")]
        [InlineData("84")]
        [InlineData("6")]
        public void IsValid_TooShortRegonsTest(string regon)
        {
            Assert.False(RegonValidator.IsValid(regon));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsValid_EmptyRegonsTest(string regon)
        {
            Assert.False(RegonValidator.IsValid(regon));
        }

        [Theory]
        [InlineData("6275273253")]
        [InlineData("62752732531")]
        [InlineData("394379712012")]
        [InlineData("8784066227133")]
        [InlineData("709471124714564")]
        [InlineData("7094711247145648")]
        [InlineData("70947112471456472")]
        [InlineData("709471124714564722")]
        public void IsValid_TooLongRegonsTest(string regon)
        {
            Assert.False(RegonValidator.IsValid(regon));
        }

        [Theory]
        [InlineData("         ")]
        [InlineData("        0")]
        [InlineData("0        ")]
        [InlineData("      0  ")]
        [InlineData(";ierhf;dr")]
        [InlineData("000000000")]
        [InlineData("111111111")]
        [InlineData("101010101")]
        [InlineData("010101010")]
        [InlineData("aaaaaaaaa")]
        [InlineData(";lizseduj")]
        [InlineData("999999999")]
        [InlineData("              ")]
        [InlineData("             0")]
        [InlineData("0             ")]
        [InlineData("      0       ")]
        [InlineData(";ierhf;drfgwdv")]
        [InlineData("00000000000000")]
        [InlineData("11111111111111")]
        [InlineData("10101010101010")]
        [InlineData("01010101010101")]
        [InlineData("aaaaaaaaaaaaaa")]
        [InlineData(";lizsedujfgevn")]
        [InlineData("99999999999999")]
        public void IsValid_MonkeyInvalidRegonsTest(string regon)
        {
            Assert.False(RegonValidator.IsValid(regon));
        }
    }
}
