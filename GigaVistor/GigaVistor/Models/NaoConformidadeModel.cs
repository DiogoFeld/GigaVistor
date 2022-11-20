namespace GigaVistor.Models
{
    public class NaoConformidadeModel
    {
        public long Id { get; set; }
        public DateTime DateCriacao { get; set; }
        public long IdCriador { get; set; }

        public string Descricao { get; set; } //A parte original da tarefa
        public string Explicação { get; set; }//o pq que esta em nao conformidade
        public int Classificao { get; set; } //serio, medio, leve
        public int PrazoResolucao { get; set; }//tempo necessario para resolver
        public int Aderente { get; set; }//
        public int Status { get; set; }
        public int StatusPosEscalonamento { get; set; }//ver se foi concluido
                
        public DateTime DatePrazo { get; set; }
        public bool PrazoCumprido { get; set; }//default 0

        public DateTime DatePrazoEscalonado { get; set; }//checar quando que o prazo foi cumprido ou não
        public bool PrazoEscalonadoCumprido { get; set; }//checar quando que o prazo foi cumprido ou não


        public int IdEscalonamentoResponsavel{ get; set; }//quem será o prox responsavel
        public int StatusPosEscalonado { get; set; }
        public int NivelEscalonamento { get; set; }

        public long IdEscalonamento { get; set; }
        public long IdResponsavel { get; set; }
        public long IdCheckList { get; set; }
        public long IdTarefa{ get; set; }
    }
}
