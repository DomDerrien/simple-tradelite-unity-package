using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Tradelite.SDK.Model;
using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Model.MatchingScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.MatchingScope
{
    public class MatchingRunService: BaseService<MatchingRun>
    {
        private static MatchingRunService INSTANCE = null;

        public static MatchingRunService GetInstance(GameConfiguration gameConfig, string token, bool forceReload = false)
        {
            if (INSTANCE == null || forceReload)
            {
                INSTANCE = new MatchingRunService(gameConfig, token);
            }
            return INSTANCE;
        }

        private MatchingRunService(GameConfiguration gameConfig, string token): base(gameConfig.GetEndpoint("matchingrun"), gameConfig, token) {}
    }
}