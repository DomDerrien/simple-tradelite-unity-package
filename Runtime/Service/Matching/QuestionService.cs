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
    public class QuestionService: BaseService<Question>
    {
        private static QuestionService INSTANCE = null;

        public static QuestionService GetInstance(GameConfiguration gameConfig, string token, bool forceReload = false)
        {
            if (INSTANCE == null || forceReload)
            {
                INSTANCE = new QuestionService(gameConfig, token);
            }
            return INSTANCE;
        }

        private QuestionService(GameConfiguration gameConfig, string token): base(gameConfig.GetEndpoint("question"), gameConfig, token) {}
    }
}