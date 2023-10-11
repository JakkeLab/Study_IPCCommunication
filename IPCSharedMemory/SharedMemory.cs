using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Collections.Concurrent;

namespace IPCSharedMemory
{
    public class SharedMemory : MarshalByRefObject
    {
        static private ConcurrentDictionary<string, string> _sharedMemoryDic;

        public SharedMemory()
        {
            _sharedMemoryDic = new ConcurrentDictionary<string, string>();
        }

        public ConcurrentDictionary<string, string> GetSharedMemoryDic()
        {
            return new ConcurrentDictionary<string, string>(_sharedMemoryDic);
        }

        public bool SetSharedMemoryValue(string strName, string strValue)
        {
            bool bRet = false;
            if(_sharedMemoryDic != null)
            {
                if(_sharedMemoryDic.ContainsKey(strName) == false)
                {
                    _sharedMemoryDic.TryAdd(strName, strValue);
                    bRet = true;
                }
                else
                {
                    _sharedMemoryDic[strName] = strValue;
                    bRet = true;
                }
            }
            return bRet;
        }

        public List<string> GetSharedMemoryValues()
        {
            return _sharedMemoryDic.Select(kv => kv.Value).ToList();
        }

        public void MemoryClear()
        {
            _sharedMemoryDic.Clear();
        }
    }
}
