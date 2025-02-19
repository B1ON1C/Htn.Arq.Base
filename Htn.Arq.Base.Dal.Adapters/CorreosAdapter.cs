﻿using Htn.Arq.Base.Dal.Adapters.Interfaces;
using Htn.Arq.Base.Bll.Entities;

namespace Htn.Arq.Base.Dal.Adapters
{
    public class CorreosAdapter : ICorreosAdapter
    {
        public async Task<Result<bool>> InsAsync()
        {
            // Simulamos una operación asíncrona de creación, como una inserción en la base de datos
            await Task.Delay(100);

            // Llamada al envío de correos

            //Simulamos que ha ido correctamente
            var envioRealizado = true;
            var result = new Result<bool>(envioRealizado);

            return result;
        }
    }
}