using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utils;

namespace Puzzles
{
    //should not be static but injectable
    public static class PuzzleFactory
    {
        /* All components are either:
         *  - public and unit-tested
         *  - private and dependent on other class.
         *  What should we?:
         *  - for sure inject ClassFactory as dependency, so we can mock it and:
         *      -- make CreateInstance public and unit test:
         *          --- both CreateInstance and GetPuzzle
         *          --- only CreateInstance
         *      -- keep CreateInstance private and unit test GetPuzzle
         *      
         *      IMO mock ClassFactory, keep CreateInstance private and only test GetPuzzle
         */
        public static Puzzle GetPuzzle(int dayNumber, string daySuffix)
        {
            ValidateArguments(dayNumber, daySuffix);
            var className = CreatePuzzleDayClassName(dayNumber, daySuffix);

            return CreateInstance(className);
        }
        public static void ValidateArguments(int dayNumber, string daySuffix)
        {
            if (dayNumber <= 0)
                throw new ArgumentException("Day number must be greater than 0.", "dayNumber");

            if (dayNumber > 25)
                throw new ArgumentException("There are only 25 days in Advent.", "dayNumber");

            if (string.IsNullOrWhiteSpace(daySuffix))
                throw new ArgumentException("Suffix must not be empty.", "daySuffix");

            if (daySuffix.Length > 3)
                throw new ArgumentException("Suffix cannot be that ulong.", "daySuffix");

            if (daySuffix.Any(c => char.IsWhiteSpace(c)))
                throw new ArgumentException("Suffix cannot be that ulong.", "daySuffix");
        }
        public static string CreatePuzzleDayClassName(int dayNumber, string daySuffix)
        {
            return string.Format("PuzzleDay{0}{1}", dayNumber, daySuffix);
        }

        private static Puzzle CreateInstance(string puzzleClass)
        {
            object obj;

            try
            {
                var assembly = ReflectionUtils.GetAssembly("Puzzles");
                var classType = ReflectionUtils.GetClass(assembly, puzzleClass);
                obj = ReflectionUtils.CreateInstance(classType);
            }
            catch (Exception e)
            {
                throw new TypeInitializationException(typeof(Puzzle).Name, new Exception("Something went wrong at the ClassFactory.", e));
            }

            if (obj is Puzzle puzzle)
                return puzzle;

            throw new TypeInitializationException(typeof(Puzzle).Name, new Exception("Created object was not a puzzle."));
        }
    }
}