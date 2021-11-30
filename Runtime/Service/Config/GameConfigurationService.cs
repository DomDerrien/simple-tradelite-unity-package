using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.ConfigScope
{
    public class GameConfigurationService: BaseService<GameConfiguration>
    {
        private static GameConfigurationService INSTANCE = null;

        public static GameConfigurationService GetInstance(GameIdentifier gameId)
        {
            if (INSTANCE == null)
            {
                INSTANCE = new GameConfigurationService(gameId.ToString());
            }
            return INSTANCE;
        }


        private GameConfiguration configuration;
        private string gameId;

        private GameConfigurationService(string gameId) : base("http://localhost:8181/api-mocks/v1/game-config") 
        {
            this.gameId = gameId;
        }

        public async Task<GameConfiguration> Get()
        {
            if (configuration == null)
            {
                configuration = await dao.Get(gameId);
            }
            return configuration;
        }

        public new Task<GameConfiguration[]> Select(Hashtable parameters = null) 
        {
            throw new InvalidOperationException("Not supported!");
        }

        public new Task<string> Create(GameConfiguration entity) 
        {
            throw new InvalidOperationException("Not supported!");
        }
    }
}