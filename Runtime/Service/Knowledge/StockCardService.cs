using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Tradelite.SDK.Model;
using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Model.KnowledgeScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.KnowledgeScope
{
    public class StockCardService: BaseService<StockCard>
    {
        private static StockCardService INSTANCE = null;

        public static StockCardService GetInstance(GameConfiguration gameConfig, string token, bool forceReload = false)
        {
            if (INSTANCE == null || forceReload)
            {
                INSTANCE = new StockCardService(gameConfig, token);
            }
            return INSTANCE;
        }

        private StockCardService(GameConfiguration gameConfig, string token): base(gameConfig.GetEndpoint("stockCard"), gameConfig, token) {}
    }
}