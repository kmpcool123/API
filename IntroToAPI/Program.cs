using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/1").Result;
            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                //Console.ReadKey();

                Pokemon pokemoneRespone = response.Content.ReadAsAsync<Pokemon>().Result;
                Console.WriteLine(pokemoneRespone.name);

                foreach(var ability in pokemoneRespone.abilities)
                {
                    Console.WriteLine(ability.ability.name);
                }
                
            }

            POKEAPIService service = new POKEAPIService();
            Pokemon numberTwo = service.GetPokemonAsync("https://pokeapi.co/api/v2/pokemon/2").Result;
            if(numberTwo != null)
            {
                Console.WriteLine(numberTwo.name);

            }


            Pokemon anotherPokemon = service.GetAsync<Pokemon>("https://pokeapi.co/api/v2/pokemon/42").Result;
            var test = service.GetAsync<Move>("https://pokeapi.co/api/v2/pokemone/42").Result;
            Console.WriteLine(anotherPokemon.name);
            

            var listOfPokemon = service.GetAsync<ListOfPokemon>("https://pokeapi.co/api/v2/pokemon?offset=0&limit=40").Result;
            foreach(var pokemon in listOfPokemon.results)
            {
                Console.WriteLine(pokemon.name);
            }
            
            Console.ReadKey();
        }
    }
}
