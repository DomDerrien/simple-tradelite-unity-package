using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

using Tradelite.SDK.DAO;
using Tradelite.SDK.DAO.UserScope;
using Tradelite.SDK.Model;
using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Model.UserScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.UserScope {
    public class GuestService : BaseService<Guest> {
        private static GuestService INSTANCE = null;

        public static GuestService GetInstance(GameConfiguration gameConfig, string token, bool forceReload = false) {
            if (INSTANCE == null || forceReload) {
                INSTANCE = new GuestService(gameConfig, token);
            }
            return INSTANCE;
        }

        protected HttpDao<Guest> onlineDao;
        protected LocalStorageDao<Guest> offlineDao;

        private GuestService(GameConfiguration gameConfig, string token) : base(null, gameConfig, token) {
            offlineDao = new LocalStorageDao<Guest>(gameConfig.id, true);
            onlineDao = new HttpDao<Guest>(gameConfig.GetEndpoint("guest"), token);
        }

        public override async Task<Guest> Get(string id = null, Hashtable parameters = null) {
            Guest guest = await offlineDao.Get("activeGuest");
            if (guest == null || id != null && guest.id != id) {
                throw new ObjectDisposedException(entityName);
            }
            return guest;
        }

        public override async Task<string> Create(Guest entity = null) {
            Guest existingGuest = await offlineDao.Get("activeGuest");
            if (existingGuest != null) {
                UnityEngine.Debug.Log("Retrieving guest account from local storage!");
                return existingGuest.id;
            }

            string guestId = await onlineDao.Create(new Guest());
            Guest guest = await onlineDao.Get(guestId);

            await offlineDao.Create(guest, "activeGuest");

            return guestId;
        }
        public override Task Delete(string id) {
            offlineDao.Delete("activeGuest");
            return Task.CompletedTask;
        }
    }
}