using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace sharp_lab6
{
    public class FractionCache
    {
        private readonly MemoryCache _cache;
        private readonly CacheItemPolicy _policy;

        public FractionCache()
        {
            _cache = MemoryCache.Default; // Используем стандартный кэш
            _policy = new CacheItemPolicy
            {
                SlidingExpiration = TimeSpan.FromMinutes(10) 
            };
        }

        // Метод для получения значения из кэша или вычисления его
        public double GetOrAdd(int numerator, int denominator)
        {
            string key = $"{numerator}/{denominator}"; 

            // Проверяем, есть ли значение в кэше
            if (_cache.Contains(key))
            {
                Console.WriteLine($"Значение для дроби {key} взято из кэша.");
                return (double)_cache[key];
            }

            // Если значения нет, вычисляем его
            double result = (double)numerator / denominator;

            // Добавляем значение в кэш
            _cache.Add(key, result, _policy);
            Console.WriteLine($"Значение для дроби {key} вычислено и сохранено в кэше.");

            return result;
        }

        // Метод для удаления значения из кэша
        /*public void Remove(int numerator, int denominator)
        {
            string key = $"{numerator}/{denominator}";
            if (_cache.Contains(key))
            {
                _cache.Remove(key);
                Console.WriteLine($"Значение для дроби {key} удалено из кэша.");
            }
        }*/
    }
}

