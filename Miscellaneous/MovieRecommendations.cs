using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System;
using System.Collections.Generic;

namespace MyCollections
{
    public class Movie : IComparable 
    {
        private readonly int movieId;
        private readonly float rating;
        private List<Movie> similarMovies; // Similarity is bidirectional

        public Movie(int movieId, float rating)
        {
            this.movieId = movieId;
            this.rating = rating;
            similarMovies = new List<Movie>();
        }

        public int getId()
        {
            return movieId;
        }

        public float getRating()
        {
            return rating;
        }

        public void addSimilarMovie(Movie movie)
        {
            similarMovies.Add(movie);
            movie.similarMovies.Add(this);
        }

        public List<Movie> getSimilarMovies()
        {
            return similarMovies;
        }

        /*
         * Implement a function to return top rated movies in the network of movies 
         * reachable from the current movie
         * eg:            A(Rating 1.2)
         *               /   \
         *            B(2.4)  C(3.6)
         *              \     /
         *               D(4.8)
         * In the above example edges represent similarity and the number is rating.
         * getMovieRecommendations(A,2)should return C and D (sorting order doesn't matter so it can also return D and C)
         * getMovieRecommendations(A,4) should return A, B, C, D (it can also return these in any order eg: B,C,D,A)
         * getMovieRecommendations(A,1) should return D. Note distance from A to D doesn't matter, 
         *                            return the highest  rated.
         *     
         *     @param movie
         *     @param numTopRatedSimilarMovies 
         *                      number of movies we want to return
         *     @return List of top rated similar movies
         */
        public static IList<Movie> getMovieRecommendations(Movie movie, int numTopRatedSimilarMovies)
        {
            int movieCount = 0;
            IList<Movie> OrderedMovieList = new List<Movie>();


            if (numTopRatedSimilarMovies <= 0)
            {
                Console.WriteLine("Only positive numbers are expected.");
                return OrderedMovieList;
            }

            SortedDictionary<Movie, float> movieOrder = new SortedDictionary<Movie, float>();
            var visited = new HashSet<Movie>();
            Stack<Movie> stack = new Stack<Movie>();
            stack.Push(movie);

            while (stack.Count != 0)
            {
                Movie current = stack.Pop();
                IList<Movie> movieList = current.getSimilarMovies();

                 if (!visited.Add(current))
                    continue;

                if (!movieOrder.ContainsKey(current))
                    movieOrder.Add(current, current.getRating());

                foreach (var movei in movieList)
                    stack.Push(movei);

            }

            foreach (Movie item in (movieOrder.Keys.Reverse()))
            {
                if(movieCount < numTopRatedSimilarMovies)
                {
                    OrderedMovieList.Add(item);
                    movieCount++;
                }

                //Console.WriteLine("{0}={1}", item.getId(), item.getRating());
            }

            return OrderedMovieList;
        }

       public int CompareTo(object obj)
          {
              if (obj is Movie)
              {
                  var movie = obj as Movie;
                  return this.getRating().CompareTo(movie.getRating());
              }
              else
              {
                  throw new ArgumentException("Object is not of type Movie");
              }
          }

        class MovieRating
        {
            static void Main(string[] args)
            {
                Movie movieA = new Movie(1, 1.2f);
                Movie movieB = new Movie(2, 2.4f);
                Movie movieC = new Movie(3, 3.6f);
                Movie movieD = new Movie(4, 4.8f);

                movieA.addSimilarMovie(movieB);
                movieA.addSimilarMovie(movieC);
                movieA.addSimilarMovie(movieD);


                IList<Movie> movieList1 = getMovieRecommendations(movieA, 0);
                IList<Movie> movieList2 = getMovieRecommendations(movieA, 2);
             //IList<Movie> movieList3 =  getMovieRecommendations(movieA, 3);



             foreach (Movie mov in movieList1)
             {
                 Console.WriteLine(mov.getId());
             }

             Console.ReadLine();
            }
        }
    }
}
