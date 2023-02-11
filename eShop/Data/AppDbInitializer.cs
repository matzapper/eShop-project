using eShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) 
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Shops
                if (!context.Shops.Any()) //If there are no shops in the database, we add some new shops
                {
                    context.Shops.AddRange(new List<Shop>()
                    {
                        new Shop()
                        {
                            Name = "Shop 1",
                            Logo = "https://c8.alamy.com/comp/AX22G2/i-night-time-video-rental-shop-in-limoux-in-the-south-of-france-AX22G2.jpg",
                            Description = "This is the description of the first shop"
                        },
                        new Shop()
                        {
                            Name = "Shop 2",
                            Logo = "https://patch.com/img/cdn/users/35551/2011/02/raw/2b1bb9f097ccc930dfa38dac11306d4e.jpg",
                            Description = "This is the description of the second shop"
                        },
                        new Shop()
                        {
                            Name = "Shop 3",
                            Logo = "https://i.cbc.ca/1.6410537.1649270012!/fileImage/httpImage/nick-prueher-kim-s-video.jpeg",
                            Description = "This is the description of the third shop"
                        },
                        new Shop()
                        {
                            Name = "Shop 4",
                            Logo = "https://www.cnet.com/a/img/resize/4774decee005eadb790d755345efea954180eb85/hub/2012/12/05/717b2668-f0e3-11e2-8c7c-d4ae52e62bcc/High-Res-Storefront-(1).jpg?auto=webp&fit=crop&height=900&width=1200",
                            Description = "This is the description of the fourth shop"
                        },
                        new Shop()
                        {
                            Name = "Shop 5",
                            Logo = "https://securecdn.pymnts.com/wp-content/uploads/2021/01/Family-Video-rental-closing.jpg",
                            Description = "This is the description of the fifth shop"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any()) //If there are no actors in the database
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the third actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the fourth actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the fifth actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Directors
                if (!context.Directors.Any()) //If there are no directors in the database
                {
                    context.Directors.AddRange(new List<Director>()
                    {
                        new Director()
                        {
                            FullName = "Director 1",
                            Bio = "This is the Bio of the first director",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Director()
                        {
                            FullName = "Director 2",
                            Bio = "This is the Bio of the second director",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Director()
                        {
                            FullName = "Director 3",
                            Bio = "This is the Bio of the third director",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Director()
                        {
                            FullName = "Director 4",
                            Bio = "This is the Bio of the fourth director",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Director()
                        {
                            FullName = "Director 5",
                            Bio = "This is the Bio of the fifth director",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any()) //If there are no movies in the database
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "https://m.media-amazon.com/images/I/81M62a9wTTL._SL1500_.jpg",
                            ShopId = 3,
                            DirectorId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "https://m.media-amazon.com/images/I/91PvpcWHD7L._AC_SL1500_.jpg",
                            ShopId = 1,
                            DirectorId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "https://cdn.shopify.com/s/files/1/0024/9803/5810/products/253861-Product-0-I_c2f830ce-086a-4b61-b401-bab053757357.jpg?v=1572273200",
                            ShopId = 4,
                            DirectorId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://www.gruv.com/assets/images/0/0/2/5/8/mm00258021.jpg",
                            ShopId = 1,
                            DirectorId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "https://m.media-amazon.com/images/I/81lAgRjm25L._AC_SL1500_.jpg",
                            ShopId = 1,
                            DirectorId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Souls",
                            Description = "This is the Cold Souls movie description",
                            Price = 39.50,
                            ImageURL = "https://m.media-amazon.com/images/I/51Ol9wQMZsL._SY445_.jpg",
                            ShopId = 1,
                            DirectorId = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Actors and Movies (Relationship between actors and movies)
                if (!context.Actors_Movies.Any()) //If there are no Actors & movies in the database
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
