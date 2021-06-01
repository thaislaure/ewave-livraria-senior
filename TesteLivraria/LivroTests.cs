using BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteLivraria
{
    [TestClass]
    public class LivroTests
    {
        [TestMethod]
        public void CriarLivroValido()
        {
            var livro = new Livro("Eles",
               1,
               1,
               "O que deveria ser um dia festivo, durante a promo��o de anivers�rio de uma loja de doces, se transforma em caos quando criaturas atra�das pela reflex�o da luz invadem a pequena e interiorana cidade de Santa Clara da Paci�ncia, durante o ver�o de 1994.",
                "https://veja.abril.com.br/wp-content/uploads/2016/11/receita-federal-logomarca1.jpg?quality=70&strip=info&resize=680,453"
               );

            livro.Validar();

            var esperado = true;
            var atual = livro.IsValid;

            var result = livro.Notifications;

            Assert.AreEqual(esperado, atual, "Livro � v�lido, mas foi criado como inv�lido");
        }

        [TestMethod]
        public void CriarLivroInvalidoAutorInexistente()
        {
            var livro = new Livro("Eles",
                 1,
                 0,
                 "O que deveria ser um dia festivo, durante a promo��o de anivers�rio de uma loja de doces, se transforma em caos quando criaturas atra�das pela reflex�o da luz invadem a pequena e interiorana cidade de Santa Clara da Paci�ncia, durante o ver�o de 1994.",
                 "https://veja.abril.com.br/wp-content/uploads/2016/11/receita-federal-logomarca1.jpg?quality=70&strip=info&resize=680,453"
                 );

            livro.Validar();

            var esperado = true;
            var atual = livro.IsValid;

            Assert.AreEqual(esperado, atual, "Livro inv�lido, Autor n�o cadastrado");
        }

    

        [TestMethod]
        public void CriarLivroInvalidoGeneroInexistente()
        {
            var livro = new Livro("Eles",
                 0,
                 1,
                 "O que deveria ser um dia festivo, durante a promo��o de anivers�rio de uma loja de doces, se transforma em caos quando criaturas atra�das pela reflex�o da luz invadem a pequena e interiorana cidade de Santa Clara da Paci�ncia, durante o ver�o de 1994.",
                  "https://veja.abril.com.br/wp-content/uploads/2016/11/receita-federal-logomarca1.jpg?quality=70&strip=info&resize=680,453"
                 );

            livro.Validar();

            var esperado = true;
            var atual = livro.IsValid;

            Assert.AreEqual(esperado, atual, "Livro inv�lido, Genero n�o cadastrado");
        }

    }
}
