using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Basics
{
    
        public class Yeild_Keyword
        {
            private int[] _data = { 1, 2, 3, 4, 5 };

            // Implementing IEnumerable<int> using yield
            public  IEnumerator<int> GetEnumerator()
            {
                foreach (var item in _data)
                {
                    yield return item;
                }
            }

            // Filtering with yield
            public IEnumerable<int> GetFilteredNumbers()
            {
                foreach (var item in _data)
                {
                    if (item > 2)
                    {
                        yield return item * 2;
                    }
                }
            }
        }

        // Usage
       
    }

