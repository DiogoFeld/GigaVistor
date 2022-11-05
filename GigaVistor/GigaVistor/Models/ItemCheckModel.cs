namespace GigaVistor.Models
{
    public class ItemCheckModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }        
        public int Aderente { get; set; }
        public int Status { get; set; }

        public bool Escalonado{ get; set; }//default 0, só pra checar se nao esta em conformidade.
        public string ExplicacaoNaoConformidade { get; set; }//qual é o da nao conformidade
        public bool NaoConformidade { get; set; } //esta ou nao conforme
        public int NivelNaoConformidade { get; set; }//media,leve,grae


        public DateTime DateCriacao { get; set; }
        public DateTime DatePrazo { get; set; }
        public DateTime DatePrazoEscalonado { get; set; }
        public int StatusPosEscalonado{ get; set; }

        public long IdCriador { get; set; }
        public long IdResponsavel{ get; set; }
        public long IdCheckList{ get; set; }
        public long IdNaoConformidade{ get; set; }
    }
}
