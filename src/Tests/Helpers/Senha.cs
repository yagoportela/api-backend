using System;
using System.Text;
using ApiBackend.Helpers.Senha;
using Xunit;

namespace Tests.Helpers.Senha
{
    public class Senha
    {
        
        [Fact]
        public void Cript()
        {
            var senha = "123";
            var chave = "HR$2pIjHR$2pIj12";

            var cripto = Hash.Encrypt(senha, chave);
            
            Assert.Equal("NrvfgLzoXxw=", cripto);
        }

        [Fact]
        public void Decrip()
        {
            var cripto = "NrvfgLzoXxw=";
            var chave = "HR$2pIjHR$2pIj12";

            var decBase64 = Hash.Decrypt(cripto, chave);
            
            Assert.Equal(decBase64, "123");
        }

        [Fact]
        public void ForcaSenha()
        {
            var senhaForte = "Nrvfg=";
            var senhaFraca = "12345678";

            int forcaSenhaForte = ChecarForcaSenha.GetForcaDaSenha(senhaForte);
            int forcaSenhaFraca = ChecarForcaSenha.GetForcaDaSenha(senhaFraca);
            
            Assert.True(forcaSenhaForte >= 50);
            Assert.True(forcaSenhaFraca < 50);
        }

    }
}
