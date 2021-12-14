using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Tradelite.SDK.Model;
using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.ConfigScope
{
    public class GameConfigurationService: BaseService<GameConfiguration>
    {
        private static GameConfigurationService INSTANCE = null;

        public static GameConfigurationService GetInstance(string gameId, bool forceReload = false, string source = "http://localhost:8181/api-mocks/v1/game-config")
        {
            if (INSTANCE == null || forceReload)
            {
                INSTANCE = new GameConfigurationService(gameId, source);
            }
            return INSTANCE;
        }

        private string gameId;

        private GameConfigurationService(string gameId, string source) : base(source) 
        {
            this.gameId = gameId;
        }

        public async Task<GameConfiguration> Get()
        {
            if (gameConfig == null)
            {
                // Delayed retrieval
                gameConfig = await dao.Get(gameId);
                dao.SetBasicAuthCredentials(
                    gameConfig.GetCredential("clientId"),
                    gameConfig.GetCredential("clientSecret")
                );
            }
            return gameConfig;
        }

        public async void Get(Action<GameConfiguration> success, Action<BaseError> failure)
        {
            try
            {
                success?.Invoke(await Get());
            }
            catch (Exception ex)
            {
                failure?.Invoke(new BaseError($"Cannot get game configuration for id: {gameId}", ex));
            }
        }

        public override Task<GameConfiguration[]> Select(Hashtable parameters = null) 
        {
            throw new InvalidOperationException("Not supported!");
        }

        public override      Task<string> Create(GameConfiguration entity) 
        {
            throw new InvalidOperationException("Not supported!");
        }
    }
}