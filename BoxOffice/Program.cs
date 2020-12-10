using System;
using System.Collections.Generic;
using System.IO;

namespace BoxOffice
{
    class Program
    {
        class Movie
        {
            int id;
            string title;
            long lifetimegross;
            

            public Movie(int _id, string _title, long _lifetimegross)
            {
                id = _id;
                title = _title;
                lifetimegross = _lifetimegross;
            }

            public int Id {get { return id; } }
            public string Title { get { return title; } }
            
            public long Lifetimegross { get { return lifetimegross; } }

            
        }
        
        class MovieList
        {
           List<Movie> movies;
           long totallifegross = 0;

           public MovieList()
           {
               movies = new List<Movie>();
               totallifegross = 0;
           }
           public void AddMoviesToList(int id,string title,long gross)
           {
               Movie newMovie = new Movie(id, title, gross);
               movies.Add(newMovie);
           }
           public void PrintAllMovies()
           {
              foreach(Movie movie in movies)
              {
                 Console.WriteLine($"{movie.Id}. {movie.Title} has earned {movie.Lifetimegross}");
              }
           }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Good Morning!");
            Console.WriteLine("How Ya Doing!");
            string filePath = @"C:\Users\opilane\Samples";
            string fileName = @"boxoffice.txt";
            string fullFilePath = Path.Combine(filePath, fileName);
            //create an array of records from file
            string[] linesFromFile = File.ReadAllLines(fullFilePath);
            //create a list o movies to store the movies objects from file
            MovieList myMovies = new MovieList();
            foreach(string line in linesFromFile)
            {
                //split the line to get the movie data
                string[] tempArray = line.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                int movieId = int.Parse(tempArray[0]);
                string movieTitle = tempArray[1];
                string TotalGrossTemp = tempArray[2].Substring(1);
                Console.WriteLine(TotalGrossTemp);

                long movieGross = long.Parse(TotalGrossTemp);
                myMovies.AddMoviesToList(movieId, movieTitle, movieGross);

            }
            myMovies.PrintAllMovies();
        }
    }
}
