namespace BLL.Models
{
    public class Autor : ValidationModelResult
    {
        public Autor(int autorId, 
                     string nome)
        {
            AutorId = autorId;
            Nome = nome;
        }

        public Autor(string nome)
        {
            Nome = nome;
        }

        public Autor(int autorId)
        {
            AutorId = autorId;
        }

        public int AutorId { get; private set; }
        public string Nome { get; private set; }

        

        public void SetarIdentificador(int autorId)
        {
            AutorId = autorId;
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
