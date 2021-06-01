namespace BLL.Models
{
    public class Genero : ValidationModelResult
    {
        public Genero(int generoId, 
                     string nome)
        {
            GeneroId = generoId;
            Nome = nome;
        }

        public Genero(string nome)
        {
            Nome = nome;
        }

        public Genero(int generoId)
        {
            GeneroId = generoId;
        }

        public int GeneroId { get; private set; }
        public string Nome { get; private set; }

        

        public void SetarIdentificador(int generoId)
        {
            GeneroId = generoId;
        }

        public bool IsValid { get; private set; } = false;

        private void ValidarNome()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                this.Notifications.Add(nameof(Nome), "Informe o campo Nome.");
        }

        public override void Validar()
        {
            ValidarNome();

            IsValid = this.Notifications.Count == 0;
        }
    }
}
