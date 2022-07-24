using System.Collections.Generic;
using Application.RepositoryInterfaces;

namespace Application.Common
{
    public class ConfigManager: IConfigManager
    {
        private IOriginRepository _originRepository;
        public ConfigManager(IOriginRepository originRepository)
        {
            _originRepository = originRepository;
        }

        public List<string> GetOrigin()
        {
            return _originRepository.GetOrigins();
        }
    }
}