﻿using Htn.Arq.Base.Bll.Services.Interfaces;
using Htn.Infrastructure.Core.WorkerService;
using Microsoft.Extensions.Options;

namespace Htn.Arq.Base.WorkerService.Workers
{
    public class TimeFileWorker : WorkerBase
    {
        private readonly TimeFileWorkerOptions _workerOptions;
        private readonly ILogger<TimeFileWorker> _logger;
        private readonly ITimeService _timeService;
        private readonly ICategoriaProductoService _categoriaProductoService;

        public TimeFileWorker(
            IOptions<TimeFileWorkerOptions> workerOptions
            , ILogger<TimeFileWorker> logger
            , ITimeService timeService
            , ICategoriaProductoService categoriaProductoService)
            : base(workerOptions.Value)
        {
            _workerOptions = workerOptions.Value;
            _timeService = timeService;
            _logger = logger;
            _categoriaProductoService = categoriaProductoService;
        }

        public override async Task DoWorkAsync()
        {
            await InsFile();
            await InsCategorias();
        }

        private async Task InsFile()
        {
            Directory.CreateDirectory(_workerOptions.OutputDirectory);
            var time = _timeService.GetDateTime();
            var outFile = Path.Combine(
                _workerOptions.OutputDirectory,
                $"{time:yyyy-MM-dd--HHmmss}.txt");
            await File.WriteAllTextAsync(outFile, WorkerName);
            _logger.LogInformation("outFile: {outFile}", outFile);
        }

        private async Task InsCategorias()
        {
            var categorias = await _categoriaProductoService.GetCategoriasProductoAsync();
            foreach (var categoria in categorias)
            {
                _logger.LogInformation(categoria.Descripcion);
            }
        }
    }
}