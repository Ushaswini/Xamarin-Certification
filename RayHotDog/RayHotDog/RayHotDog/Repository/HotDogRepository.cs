using Newtonsoft.Json;
using RayHotDog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RayHotDog.Repository
{

    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>();

        string url = "http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";

        public HotDogRepository()
        {
            Task.Run(() => { this.LoadDataAsync(url).Wait(); });
        }

        private async Task LoadDataAsync(string url)
        {
            if(hotDogGroups != null)
            {
                string responseJSONString = null;
                using(var httpClient=new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(url);

                        HttpResponseMessage response = await getResponse;

                        responseJSONString = await response.Content.ReadAsStringAsync();

                        hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>>(responseJSONString);
                 
                    }
                    catch(Exception ex)
                    {
                        throw;
                    }
                }
            }
        }
        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          select hotDog;

            return hotDogs.ToList<HotDog>();
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.HotDogId == hotDogId
                                          select hotDog;

            return hotDogs.FirstOrDefault();
        }


        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.Where(h => h.HotDogGroupId == hotDogGroupId).FirstOrDefault();

            if (group != null)
            {
                return group.HotDogs;
            }
            return null;
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.IsFavorite
                                          select hotDog;

            return hotDogs.ToList<HotDog>();
        }



    }


}
