using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Movie
        {
            public const int GenreMinLength = 5;
            public const int TitleMaxLength = 50;
            public const int GenreMaxLength = 20;
            public const int DurationMinValue = 1;
            public const int DurationMaxValue = 999;
            public const int DirectorNameMinLength = 2;
            public const int DirectorNameMaxLength = 80;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;
            public const string ReleaseDateFormat = "MM/yyyy";
            public const int MovieImageUrlMaxLength = 250;
            public const int MovieImageUrlMinLength = 5;
        }

        public static class Cinema
        {
            public const int CinemaNameMaxLength = 50;
            public const int CinemaNameMinLength = 3;
            public const int LocationMinLength = 3;
            public const int LOcationMaxLength = 120;
        }
    }
}
