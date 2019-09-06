using GetWITeste.Core.Entities;
using GetWITeste.Core.Interfaces;
using GetWITeste.Interfaces;
using Microsoft.Extensions.Options;
using System;

namespace GetWITeste.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly AppSettings _config;
        private readonly IGetWorkItems _appService;
        private readonly IDapperRepository _logAnaliseService;

        public ApplicationService(IOptions<AppSettings> config,
            IGetWorkItems appService,
            IDapperRepository logAnaliseService)
        {
            _config = config.Value;
            _appService = appService;
            _logAnaliseService = logAnaliseService;
        }

        public void Startup()
        {
            var dataHoraInicio = DateTime.Now;

            try
            {
                //GravarLog(1, _config.MensagemInicioProcesso);

                _appService.Processar();
            }
            catch (Exception ex)
            {
                //GravarLog(3, $"{_config.MensagemErro} {ex.Message}");
            }
            finally
            {
                var tempoExecucao = (DateTime.Now - dataHoraInicio);
                var horas = string.Format("{0}:{1}:{2}", tempoExecucao.TotalHours.ToString("00"), tempoExecucao.Minutes.ToString("00"), tempoExecucao.Seconds.ToString("00"));
                //GravarLog(1, string.Format(_config.MensagemFimProcesso, horas));
            }
        }

        private void GravarLog(int tipoLog, string mensagem)
        {
            _logAnaliseService.AddLogAnalise(new LogAnalise
            {
                TipoLog = tipoLog,
                Mensagem = mensagem,
                Data = DateTime.Now
            });
        }
    }
}
