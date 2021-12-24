using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tradelite.SDK.Model;
using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Model.MatchingScope;
using Tradelite.SDK.Service;
using UnityEngine;

namespace Tradelite.SDK.Service.MatchingScope {
    public class AnswerService : BaseService<Answer> {
        private static AnswerService INSTANCE = null;

        public static AnswerService GetInstance(GameConfiguration gameConfig, string token, bool forceReload = false) {
            if (INSTANCE == null || forceReload) {
                INSTANCE = new AnswerService(gameConfig, token);
            }
            return INSTANCE;
        }

        private AnswerService(GameConfiguration gameConfig, string token) : base(gameConfig.GetEndpoint("answer"), gameConfig, token) { }
    }
}