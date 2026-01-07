using Mono.Cecil;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public class Item
    {
        public string name;
        public int damage = 5;
        public bool isMagical = false;
        public bool isRare = false;

        public class Builder
        {
            private Item item;

            public Builder(string name)
            {
                item = new Item();
                item.name = name;
            }

            public Builder WithDamage(int damage)
            {
                item.damage = damage;
                return this;
            }

            public Builder WithIsMagical(bool isMagical)
            {
                item.isMagical = isMagical;
                return this;
            }

            public Builder WithIsRare(bool isRare)
            {
                item.isRare = isRare;
                return this;
            }

            public Item Build()
            {
                return item;
            }
        }
    }

    public class Pokemon
    {
        public enum types
        {
            Fire,
            Water,
            Plant,
            Normal
        }
        
        public string name;
        public int hp = 10;
        public bool isBig = false;
        public types type = types.Normal;

        public class Builder
        {
            public Pokemon pokemon;

            public Builder(string name)
            {
                pokemon = new Pokemon();
                pokemon.name = name;
            }

            public Builder WithHealth(int health)
            {
                pokemon.hp = health;
                return this;
            }

            public Builder WithIsBig(bool isBig)
            {
                pokemon.isBig = isBig;
                return this;
            }

            public Builder WithType(types type)
            {
                pokemon.type = type;
                return this;
            }
            
            public Pokemon Build()
            {
                return pokemon;
            }
        }
    }
    
    
    public Item obo = new Item.Builder("Extracto de obo")
        .WithDamage(2000)
        .WithIsRare(true)
        .Build();

    public Pokemon wailord = new Pokemon.Builder("Wailord")
        .WithIsBig(true)
        .WithType(Pokemon.types.Water)
        .Build();
    
    public enum PokemonPets
    {
        Flareon,
        Vaporeon,
        Leafeon,
        Eevee
    }
    
    public class PokemonPetsFactory
    {
        public Pokemon Create(PokemonPets pet)
        {
            switch (pet)
            {
                 case PokemonPets.Flareon:
                     return new Pokemon.Builder("Flareon")
                         .WithHealth(70)
                         .WithType(Pokemon.types.Fire)
                         .Build();
                 case PokemonPets.Vaporeon:
                     return new Pokemon.Builder("Vaporeon")
                         .WithHealth(20)
                         .WithType(Pokemon.types.Water)
                         .Build();
                 case PokemonPets.Leafeon:
                     return new Pokemon.Builder("Leafeon")
                         .WithHealth(43)
                         .WithType(Pokemon.types.Water)
                         .Build();
                 case PokemonPets.Eevee:
                     return new Pokemon.Builder("Eevee")
                         .WithHealth(50)
                         .Build();
                 default:
                     return null;
            }
        }
    }
}
