using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiCardapio.Querys
{
    public class ResultadoExecucaoQuery
    {
        private int _resultadoExecucaoEnum;

        public ResultadoExecucaoQuery() : this(null, null, null, null)
        {
        }

        public ResultadoExecucaoQuery(int? resultadoExecucaoEnum = null, Exception ex = null, string mensagem = null, int? httpStatusCode = null)
        {
            this.ResultadoExecucaoEnum = resultadoExecucaoEnum == null ? (int)Enumerators.ResultadoExecucaoEnum.NaoEspecificado : resultadoExecucaoEnum.Value;

            if (!String.IsNullOrEmpty(mensagem))
                this.Mensagem = mensagem;
            else if (ex != null)
                this.Excecao = ex;

            this.SetHttpStatusCode(httpStatusCode);
        }

        public int ResultadoExecucaoEnum
        {
            get
            {
                return _resultadoExecucaoEnum;
            }
            set
            {
                _resultadoExecucaoEnum = value;

                if (value == (int)Enumerators.ResultadoExecucaoEnum.Sucesso)
                    ResultadoExecucaoDescricao = "Sucesso";
                else if (value == (int)Enumerators.ResultadoExecucaoEnum.Erro)
                    ResultadoExecucaoDescricao = "Erro";
                else if (value == (int)Enumerators.ResultadoExecucaoEnum.NaoAutorizado)
                    ResultadoExecucaoDescricao = "Não Autorizado";
                else if (value == (int)Enumerators.ResultadoExecucaoEnum.NaoEspecificado)
                    ResultadoExecucaoDescricao = "Não Especificado";
                else if (value == (int)Enumerators.ResultadoExecucaoEnum.SessaoInvalida)
                    ResultadoExecucaoDescricao = "Sessão Inválida";
            }
        }

        public string ResultadoExecucaoDescricao { get; set; }

        public string Mensagem { get; set; }

        public string RastroPilha { get; set; }

        [JsonIgnore]
        public Exception Excecao
        {
            set
            {
                this.Mensagem = value.Message;
                this.RastroPilha = value.StackTrace;
            }
        }

        private int? _httpStatusCode;

        public void SetHttpStatusCode(int? valor)
        {
            _httpStatusCode = valor;
        }

        public int? GetHttpStatusCode()
        {
            return _httpStatusCode;
        }
    }

    public class ResultadoExecucaoQuery<T> : ResultadoExecucaoQuery
    {
        public ResultadoExecucaoQuery() : base()
        {
        }

        public ResultadoExecucaoQuery(int? resultadoExecucaoEnum = null, Exception ex = null, string mensagem = null, int? httpStatusCode = null) : base(resultadoExecucaoEnum, ex, mensagem, httpStatusCode)
        {
        }

        public ResultadoExecucaoQuery(T data, int? resultadoExecucaoEnum = null, Exception ex = null, string mensagem = null, int? httpStatusCode = null) : base(resultadoExecucaoEnum, ex, mensagem, httpStatusCode)
        {
            this.Data = data;
            this.ResultadoExecucaoEnum = resultadoExecucaoEnum == null ? (int)Enumerators.ResultadoExecucaoEnum.Sucesso : resultadoExecucaoEnum.Value;
        }

        public T Data { get; set; }
    }

    public class ResultadoExecucaoListaQuery<T> : ResultadoExecucaoQuery
    {
        public ResultadoExecucaoListaQuery() : base()
        {
            this.Data = new List<T>();
        }

        public ResultadoExecucaoListaQuery(int? resultadoExecucaoEnum = null, Exception ex = null, string mensagem = null, int? httpStatusCode = null) : base(resultadoExecucaoEnum, ex, mensagem, httpStatusCode)
        {
            this.Data = new List<T>();
        }

        public ResultadoExecucaoListaQuery(List<T> itens, int? total = null, int? resultadoExecucaoEnum = null, Exception ex = null, string mensagem = null, int? httpStatusCode = null) : base(resultadoExecucaoEnum, ex, mensagem, httpStatusCode)
        {
            this.Data = itens;

            if (total.HasValue)
                this.Total = total.Value;
            else
                this.Total = this.Data.Count;

            this.ResultadoExecucaoEnum = resultadoExecucaoEnum == null ? (int)Enumerators.ResultadoExecucaoEnum.Sucesso : resultadoExecucaoEnum.Value;
        }

        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}
